using System;
using System.Collections.Generic;

namespace s30124_APBD_Kolokwium.Models;

public partial class Assignment
{
    public int Id { get; set; }

    public int LessonsId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public int MaxScore { get; set; }

    public virtual Lesson Lessons { get; set; } = null!;

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
