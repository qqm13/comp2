using System;
using System.Collections.Generic;

namespace comp2;

public partial class UserBadge
{
    public int Id { get; set; }

    public string UserSid { get; set; } = null!;

    public int BadgeId { get; set; }

    public DateTime AwardedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Badge Badge { get; set; } = null!;

    public virtual Client UserS { get; set; } = null!;
}
