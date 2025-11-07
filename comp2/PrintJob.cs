using System;
using System.Collections.Generic;

namespace comp2;

public partial class PrintJob
{
    public int Id { get; set; }

    public int PrinterId { get; set; }

    public string UserSid { get; set; } = null!;

    public int Pages { get; set; }

    public bool IsColor { get; set; }

    public DateTime PrintedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Printer Printer { get; set; } = null!;

    public virtual Client UserS { get; set; } = null!;
}
