using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AESessionFourApi.Model;

public partial class AlbertFourContext : DbContext
{
    public AlbertFourContext()
    {
    }

    public AlbertFourContext(DbContextOptions<AlbertFourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<ProgramPoint> ProgramPoints { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WIN-ALU304ORJ02;Initial Catalog=albertFour;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2370F727E0313B1C");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.End)
                .HasColumnType("datetime")
                .HasColumnName("end");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Start)
                .HasColumnType("datetime")
                .HasColumnName("start");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.PictureId).HasName("PK__Pictures__BD28190C1B992602");

            entity.Property(e => e.PictureId).HasColumnName("picture_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Picture1)
                .HasMaxLength(50)
                .HasColumnName("picture");

            entity.HasOne(d => d.Event).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pictures__event___3F466844");
        });

        modelBuilder.Entity<ProgramPoint>(entity =>
        {
            entity.HasKey(e => e.ProgramPointId).HasName("PK__ProgramP__4ABE861DCC357FE6");

            entity.Property(e => e.ProgramPointId).HasColumnName("program_point_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");

            entity.HasOne(d => d.Event).WithMany(p => p.ProgramPoints)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgramPo__event__403A8C7D");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketNr).HasName("PK__Tickets__D596C19468DAC30E");

            entity.Property(e => e.TicketNr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ticket_nr");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Persons).HasColumnName("persons");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Event).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__event_i__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__user_id__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F17A3675B");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
