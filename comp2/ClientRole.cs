using System;
using System.Collections.Generic;

namespace comp2;

public partial class ClientRole
{
    public string ClientId { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime AssignedAt { get; set; }

    public string AssignedBy { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
