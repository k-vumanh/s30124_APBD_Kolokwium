using System;
using System.Collections.Generic;

namespace s30124_APBD_Kolokwium.Models;

public partial class Review
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int UserId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
