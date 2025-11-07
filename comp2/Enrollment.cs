using System;
using System.Collections.Generic;

namespace comp2;

public partial class Enrollment
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string UserSid { get; set; } = null!;

    public DateTime EnrolledAt { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual TrainingCourse Course { get; set; } = null!;

    public virtual Client UserS { get; set; } = null!;
}
