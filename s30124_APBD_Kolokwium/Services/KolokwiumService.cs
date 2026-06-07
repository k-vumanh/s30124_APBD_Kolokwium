using Microsoft.EntityFrameworkCore;
using s30124_APBD_Kolokwium.DTOs;
using s30124_APBD_Kolokwium.Models;

namespace s30124_APBD_Kolokwium.Services;

public class KolokwiumService : IKolokwiumService
{
    private readonly AppDbContext _context;

    public KolokwiumService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LessonResponseDto>> GetLessonsAsync(int? courseId, string? title)
    {
        var query = _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Assignments)
            .AsQueryable();

        if (courseId.HasValue)
        {
            query = query.Where(l => l.CourseId == courseId.Value);
        }

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(l => EF.Functions.Like(l.Title, $"%{title}%"));
        }
        
        var lessons = await query.Select(l => new LessonResponseDto
        {
            Id = l.Id,
            Title = l.Title,
            DurationMinutes = l.DurationMinutes,
            Course = new CourseDto
            {
                Id = l.Course.Id,
                Title = l.Course.Title,
            },
            AssignmentsCount = l.Assignments.Count
        }).ToListAsync();
        
        return lessons;
    }

    public async Task DeleteAssignmentAsync(int assignmentId)
    {
        var assignment = await _context.Assignments
            .Include(a => a.Submissions)
            .ThenInclude(s => s.User)
            .ThenInclude(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(a => a.Id == assignmentId);

        if (assignment == null)
        {
            throw new KeyNotFoundException($"Zadanie o ID {assignmentId} nie zostało znalezione");
        }
        
        var hasAdminSubmission = assignment.Submissions
            .Any(s => s.User.UserRoles.Any(ur => ur.Role.Name == "Administrator"));

        if (hasAdminSubmission)
        {
            throw new InvalidOperationException("Nie mozna usunac zadania, rozwiązanie przesłane przez Administratora");
        }
        
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            _context.Submissions.RemoveRange(assignment.Submissions);

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}