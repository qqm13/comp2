using System;
using System.Collections.Generic;

namespace comp2;

public partial class Vehicle
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public string PlateNumber { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int Capacity { get; set; }

    public bool IsAvailable { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<VehicleBooking> VehicleBookings { get; set; } = new List<VehicleBooking>();
}
