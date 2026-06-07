using System;
using System.Collections.Generic;

namespace s30124_APBD_Kolokwium.Models;

public partial class Enrollment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public int ProgressPercent { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
