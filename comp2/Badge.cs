using System;
using System.Collections.Generic;

namespace comp2;

public partial class Badge
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? IconUrl { get; set; }

    public string Criteria { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
}
