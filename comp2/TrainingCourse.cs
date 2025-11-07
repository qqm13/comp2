using System;
using System.Collections.Generic;

namespace comp2;

public partial class TrainingCourse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public TimeOnly Duration { get; set; }

    public int MaxParticipants { get; set; }

    public int EnrolledCount { get; set; }

    public bool IsPublished { get; set; }

    public string? InstructorSid { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
