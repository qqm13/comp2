using System;
using System.Collections.Generic;

namespace comp2;

public partial class License
{
    public int Id { get; set; }

    public int SoftwareId { get; set; }

    public string LicenseKey { get; set; } = null!;

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public string ActivationStatus { get; set; } = null!;

    public bool IsAssigned { get; set; }

    public string? AssignedToSid { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Client? AssignedToS { get; set; }

    public virtual Software Software { get; set; } = null!;
}
