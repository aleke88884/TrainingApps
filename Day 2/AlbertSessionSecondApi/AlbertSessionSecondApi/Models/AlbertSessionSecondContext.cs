using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlbertSessionSecondApi.Models;

public partial class AlbertSessionSecondContext : DbContext
{
    public AlbertSessionSecondContext()
    {
    }

    public AlbertSessionSecondContext(DbContextOptions<AlbertSessionSecondContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<RequestedItem> RequestedItems { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WIN-ALU304ORJ02;Initial Catalog=albertSessionSecond;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2370F72718226F13");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.End)
                .HasColumnType("datetime")
                .HasColumnName("end");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Start)
                .HasColumnType("datetime")
                .HasColumnName("start");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Location).WithMany(p => p.Events)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__location__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__user_id__3E52440B");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__771831EA08B20F81");

            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.Property(e => e.OfferId).HasColumnName("offerId");
            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Request).WithMany(p => p.Offers)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Offers_RequestedItems");

            entity.HasOne(d => d.User).WithMany(p => p.Offers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Offers_Users");
        });

        modelBuilder.Entity<RequestedItem>(entity =>
        {
            entity.HasKey(e => e.RequestedItemId).HasName("PK__Requeste__1738385514EE9D6B");

            entity.Property(e => e.RequestedItemId).HasColumnName("requested_item_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Event).WithMany(p => p.RequestedItems)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Requested__event__3F466844");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.ReservationId).HasColumnName("reservationId");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.OfferId).HasColumnName("offerId");
            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.ReservedByUserId).HasColumnName("reservedByUserId");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");

            entity.HasOne(d => d.Offer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OfferId)
                .HasConstraintName("FK_Reservations_Offers");

            entity.HasOne(d => d.Request).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Reservations_RequestedItems");

            entity.HasOne(d => d.ReservedByUser).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ReservedByUserId)
                .HasConstraintName("FK_Reservations_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FE405750F");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
