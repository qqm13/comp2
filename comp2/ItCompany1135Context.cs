using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace comp2;

public partial class ItCompany1135Context : DbContext
{
    public ItCompany1135Context()
    {
    }

    public ItCompany1135Context(DbContextOptions<ItCompany1135Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessRequest> AccessRequests { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetCategory> AssetCategories { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientRole> ClientRoles { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DeviceType> DeviceTypes { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackCategory> FeedbackCategories { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<KnowledgeArticle> KnowledgeArticles { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<MeetingRoom> MeetingRooms { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PrintJob> PrintJobs { get; set; }

    public virtual DbSet<Printer> Printers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoomBooking> RoomBookings { get; set; }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Software> Softwares { get; set; }

    public virtual DbSet<SystemResource> SystemResources { get; set; }

    public virtual DbSet<TrainingCourse> TrainingCourses { get; set; }

    public virtual DbSet<UserBadge> UserBadges { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleBooking> VehicleBookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("userid=student;password=student;database=it_company_1135;server=192.168.200.13", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AccessRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ResourceId, "IX_AccessRequests_ResourceId");

            entity.HasIndex(e => e.Status, "IX_AccessRequests_Status");

            entity.HasIndex(e => e.UserSid, "IX_AccessRequests_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApprovedAt).HasMaxLength(6);
            entity.Property(e => e.ApproverSid).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.RejectionReason).HasMaxLength(255);
            entity.Property(e => e.RequestedAt).HasMaxLength(6);
            entity.Property(e => e.ResourceId).HasColumnType("int(11)");

            entity.HasOne(d => d.Resource).WithMany(p => p.AccessRequests).HasForeignKey(d => d.ResourceId);

            entity.HasOne(d => d.UserS).WithMany(p => p.AccessRequests)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AccessRequests_ibfk_1");
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AssignedToSid, "IX_Assets_AssignedToSid");

            entity.HasIndex(e => e.CategoryId, "IX_Assets_CategoryId");

            entity.HasIndex(e => e.InventoryNumber, "IX_Assets_InventoryNumber").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CategoryId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(255);

            entity.HasOne(d => d.AssignedToS).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssignedToSid)
                .HasConstraintName("Assets_ibfk_1");

            entity.HasOne(d => d.Category).WithMany(p => p.Assets).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<AssetCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Criteria).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IconUrl).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "IX_Clients_Email").IsUnique();

            entity.HasIndex(e => e.Login, "IX_Clients_Login").IsUnique();

            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.LastLoginAt).HasMaxLength(6);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
        });

        modelBuilder.Entity<ClientRole>(entity =>
        {
            entity.HasKey(e => new { e.ClientId, e.RoleId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasIndex(e => e.RoleId, "IX_ClientRoles_RoleId");

            entity.Property(e => e.RoleId).HasColumnType("int(11)");
            entity.Property(e => e.AssignedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.DeletedAt).HasMaxLength(6);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientRoles)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ClientRoles_ibfk_1");

            entity.HasOne(d => d.Role).WithMany(p => p.ClientRoles).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AssignedToSid, "IX_Devices_AssignedToSid");

            entity.HasIndex(e => e.DeviceTypeId, "IX_Devices_DeviceTypeId");

            entity.HasIndex(e => e.InventoryNumber, "IX_Devices_InventoryNumber").IsUnique();

            entity.HasIndex(e => e.SerialNumber, "IX_Devices_SerialNumber").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DeviceTypeId).HasColumnType("int(11)");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.WarrantyExpiresAt).HasMaxLength(6);

            entity.HasOne(d => d.AssignedToS).WithMany(p => p.Devices)
                .HasForeignKey(d => d.AssignedToSid)
                .HasConstraintName("Devices_ibfk_1");

            entity.HasOne(d => d.DeviceType).WithMany(p => p.Devices).HasForeignKey(d => d.DeviceTypeId);
        });

        modelBuilder.Entity<DeviceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.WarrantyMonths).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => new { e.UserSid, e.CourseId }, "AK_Enrollments_UserSid_CourseId").IsUnique();

            entity.HasIndex(e => e.CourseId, "IX_Enrollments_CourseId");

            entity.HasIndex(e => e.UserSid, "IX_Enrollments_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompletedAt).HasMaxLength(6);
            entity.Property(e => e.CourseId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.EnrolledAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.UserS).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Enrollments_ibfk_1");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CategoryId, "IX_Feedbacks_CategoryId");

            entity.HasIndex(e => e.Rating, "IX_Feedbacks_Rating");

            entity.HasIndex(e => e.UserSid, "IX_Feedbacks_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CategoryId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Rating).HasColumnType("int(11)");
            entity.Property(e => e.SubmittedAt).HasMaxLength(6);
            entity.Property(e => e.Text).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Feedbacks).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.UserS).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Feedbacks_ibfk_1");
        });

        modelBuilder.Entity<FeedbackCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Priority, "IX_Incidents_Priority");

            entity.HasIndex(e => e.Status, "IX_Incidents_Status");

            entity.HasIndex(e => e.UserSid, "IX_Incidents_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AssignedToSid).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ResolutionNotes).HasMaxLength(255);
            entity.Property(e => e.ResolvedAt).HasMaxLength(6);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.UserS).WithMany(p => p.Incidents)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Incidents_ibfk_1");
        });

        modelBuilder.Entity<KnowledgeArticle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AuthorSid, "AuthorSid");

            entity.HasIndex(e => e.Category, "IX_KnowledgeArticles_Category");

            entity.HasIndex(e => e.IsPublished, "IX_KnowledgeArticles_IsPublished");

            entity.HasIndex(e => e.PublishedAt, "IX_KnowledgeArticles_PublishedAt");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.PublishedAt).HasMaxLength(6);
            entity.Property(e => e.Tags).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.ViewCount).HasColumnType("int(11)");

            entity.HasOne(d => d.AuthorS).WithMany(p => p.KnowledgeArticles)
                .HasForeignKey(d => d.AuthorSid)
                .HasConstraintName("KnowledgeArticles_ibfk_1");
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AssignedToSid, "IX_Licenses_AssignedToSid");

            entity.HasIndex(e => e.SoftwareId, "IX_Licenses_SoftwareId");

            entity.HasIndex(e => e.ValidTo, "IX_Licenses_ValidTo");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ActivationStatus).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LicenseKey).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.SoftwareId).HasColumnType("int(11)");
            entity.Property(e => e.ValidFrom).HasMaxLength(6);
            entity.Property(e => e.ValidTo).HasMaxLength(6);

            entity.HasOne(d => d.AssignedToS).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.AssignedToSid)
                .HasConstraintName("Licenses_ibfk_1");

            entity.HasOne(d => d.Software).WithMany(p => p.Licenses).HasForeignKey(d => d.SoftwareId);
        });

        modelBuilder.Entity<MeetingRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Capacity).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(255);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CreatedAt, "IX_Notifications_CreatedAt");

            entity.HasIndex(e => e.IsRead, "IX_Notifications_IsRead");

            entity.HasIndex(e => e.UserSid, "IX_Notifications_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LinkUrl).HasMaxLength(255);
            entity.Property(e => e.Message).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Severity).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.UserS).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Notifications_ibfk_1");
        });

        modelBuilder.Entity<PrintJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.PrintedAt, "IX_PrintJobs_PrintedAt");

            entity.HasIndex(e => e.PrinterId, "IX_PrintJobs_PrinterId");

            entity.HasIndex(e => e.UserSid, "IX_PrintJobs_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Pages).HasColumnType("int(11)");
            entity.Property(e => e.PrintedAt).HasMaxLength(6);
            entity.Property(e => e.PrinterId).HasColumnType("int(11)");

            entity.HasOne(d => d.Printer).WithMany(p => p.PrintJobs).HasForeignKey(d => d.PrinterId);

            entity.HasOne(d => d.UserS).WithMany(p => p.PrintJobs)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PrintJobs_ibfk_1");
        });

        modelBuilder.Entity<Printer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Model).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Name, "IX_Roles_Name").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
        });

        modelBuilder.Entity<RoomBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => new { e.RoomId, e.Start, e.End }, "IX_RoomBookings_RoomId_Start_End");

            entity.HasIndex(e => e.UserSid, "IX_RoomBookings_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.End).HasMaxLength(6);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Purpose).HasMaxLength(255);
            entity.Property(e => e.RoomId).HasColumnType("int(11)");
            entity.Property(e => e.Start).HasMaxLength(6);

            entity.HasOne(d => d.Room).WithMany(p => p.RoomBookings).HasForeignKey(d => d.RoomId);

            entity.HasOne(d => d.UserS).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoomBookings_ibfk_1");
        });

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ServiceTypeId, "IX_ServiceRequests_ServiceTypeId");

            entity.HasIndex(e => e.UserSid, "UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompletionNotes).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Details).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ServiceTypeId).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.SubmittedAt).HasMaxLength(6);

            entity.HasOne(d => d.ServiceType).WithMany(p => p.ServiceRequests).HasForeignKey(d => d.ServiceTypeId);

            entity.HasOne(d => d.UserS).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ServiceRequests_ibfk_1");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Software>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LicenseType).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TotalLicenses).HasColumnType("int(11)");
            entity.Property(e => e.Vendor).HasMaxLength(255);
            entity.Property(e => e.Version).HasMaxLength(255);
        });

        modelBuilder.Entity<SystemResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.SystemType).HasMaxLength(255);
        });

        modelBuilder.Entity<TrainingCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Duration).HasMaxLength(6);
            entity.Property(e => e.EnrolledCount).HasColumnType("int(11)");
            entity.Property(e => e.InstructorSid).HasMaxLength(255);
            entity.Property(e => e.MaxParticipants).HasColumnType("int(11)");
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasMaxLength(6);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<UserBadge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => new { e.UserSid, e.BadgeId }, "AK_UserBadges_UserSid_BadgeId").IsUnique();

            entity.HasIndex(e => e.BadgeId, "IX_UserBadges_BadgeId");

            entity.HasIndex(e => e.UserSid, "IX_UserBadges_UserSid");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AwardedAt).HasMaxLength(6);
            entity.Property(e => e.BadgeId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);

            entity.HasOne(d => d.Badge).WithMany(p => p.UserBadges).HasForeignKey(d => d.BadgeId);

            entity.HasOne(d => d.UserS).WithMany(p => p.UserBadges)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserBadges_ibfk_1");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Capacity).HasColumnType("int(11)");
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Model).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.PlateNumber).HasMaxLength(255);
        });

        modelBuilder.Entity<VehicleBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserSid, "IX_VehicleBookings_UserSid");

            entity.HasIndex(e => new { e.VehicleId, e.Start, e.End }, "IX_VehicleBookings_VehicleId_Start_End");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasMaxLength(6);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasMaxLength(6);
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.Destination).HasMaxLength(255);
            entity.Property(e => e.End).HasMaxLength(6);
            entity.Property(e => e.ModifiedAt).HasMaxLength(6);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Purpose).HasMaxLength(255);
            entity.Property(e => e.Start).HasMaxLength(6);
            entity.Property(e => e.VehicleId).HasColumnType("int(11)");

            entity.HasOne(d => d.UserS).WithMany(p => p.VehicleBookings)
                .HasForeignKey(d => d.UserSid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VehicleBookings_ibfk_1");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.VehicleBookings).HasForeignKey(d => d.VehicleId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
