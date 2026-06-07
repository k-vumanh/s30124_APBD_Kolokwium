namespace s30124_APBD_Kolokwium.DTOs;

public class LessonResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DurationMinutes {get; set;}
    public CourseDto Course { get; set; } = null!;
    public int AssignmentsCount { get; set; }
}