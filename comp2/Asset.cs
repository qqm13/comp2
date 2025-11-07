using System;
using System.Collections.Generic;

namespace comp2;

public partial class Asset
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string InventoryNumber { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Location { get; set; }

    public string? Notes { get; set; }

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

    public virtual AssetCategory Category { get; set; } = null!;
}
