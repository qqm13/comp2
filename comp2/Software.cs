using System;
using System.Collections.Generic;

namespace comp2;

public partial class Software
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Vendor { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string LicenseType { get; set; } = null!;

    public int TotalLicenses { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<License> Licenses { get; set; } = new List<License>();
}
