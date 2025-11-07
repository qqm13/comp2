using System;
using System.Collections.Generic;

namespace comp2;

public partial class AccessRequest
{
    public int Id { get; set; }

    public string UserSid { get; set; } = null!;

    public int ResourceId { get; set; }

    public string Status { get; set; } = null!;

    public string? ApproverSid { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public string? RejectionReason { get; set; }

    public DateTime RequestedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual SystemResource Resource { get; set; } = null!;

    public virtual Client UserS { get; set; } = null!;
}
