using System;
using System.Collections.Generic;

namespace comp2;

public partial class ServiceRequest
{
    public int Id { get; set; }

    public string UserSid { get; set; } = null!;

    public int ServiceTypeId { get; set; }

    public string Details { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime SubmittedAt { get; set; }

    public string? CompletionNotes { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ServiceType ServiceType { get; set; } = null!;

    public virtual Client UserS { get; set; } = null!;
}
