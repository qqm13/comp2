using System;
using System.Collections.Generic;

namespace comp2;

public partial class Incident
{
    public int Id { get; set; }

    public string UserSid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? AssignedToSid { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public string? ResolutionNotes { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Client UserS { get; set; } = null!;
}
