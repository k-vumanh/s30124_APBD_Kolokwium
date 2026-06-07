using s30124_APBD_Kolokwium.DTOs;

namespace s30124_APBD_Kolokwium.Services;

public interface IKolokwiumService
{
    Task<IEnumerable<LessonResponseDto>> GetLessonsAsync(int? courseId,string? title);
    Task DeleteAssignmentAsync(int assignmentId);
}