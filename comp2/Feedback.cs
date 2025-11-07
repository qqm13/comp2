using System;
using System.Collections.Generic;

namespace comp2;

public partial class Feedback
{
    public int Id { get; set; }

    public string UserSid { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Text { get; set; } = null!;

    public int Rating { get; set; }

    public DateTime SubmittedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual FeedbackCategory Category { get; set; } = null!;

    public virtual Client UserS { get; set; } = null!;
}
