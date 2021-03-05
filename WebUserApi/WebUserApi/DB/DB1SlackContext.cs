using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebuUserApi.DB
{
    public partial class DB1SlackContext : DbContext
    {
        public DB1SlackContext()
        {
        }

        public DB1SlackContext(DbContextOptions<DB1SlackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=DB1Slack;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.HasIndex(e => e.RoomId, "IX_messages_RoomId");

                entity.HasIndex(e => e.UserId, "IX_messages_UserId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.RoomId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasIndex(e => e.RoomId, "IX_Participants_RoomId");

                entity.HasIndex(e => e.UserId, "IX_Participants_UserId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.RoomId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(34);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
