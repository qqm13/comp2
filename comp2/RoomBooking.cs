using System;
using System.Collections.Generic;

namespace comp2;

public partial class RoomBooking
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string UserSid { get; set; } = null!;

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public string? Purpose { get; set; }

    public bool IsConfirmed { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual MeetingRoom Room { get; set; } = null!;

    public virtual Client UserS { get; set; } = null!;
}
