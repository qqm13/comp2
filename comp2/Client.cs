using System;
using System.Collections.Generic;

namespace comp2;

public partial class Client
{
    public string Sid { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<AccessRequest> AccessRequests { get; set; } = new List<AccessRequest>();

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual ICollection<ClientRole> ClientRoles { get; set; } = new List<ClientRole>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    public virtual ICollection<KnowledgeArticle> KnowledgeArticles { get; set; } = new List<KnowledgeArticle>();

    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<PrintJob> PrintJobs { get; set; } = new List<PrintJob>();

    public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();

    public virtual ICollection<VehicleBooking> VehicleBookings { get; set; } = new List<VehicleBooking>();
}
