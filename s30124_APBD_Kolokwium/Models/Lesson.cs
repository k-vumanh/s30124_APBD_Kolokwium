using System;
using System.Collections.Generic;

namespace s30124_APBD_Kolokwium.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual Course Course { get; set; } = null!;
}
