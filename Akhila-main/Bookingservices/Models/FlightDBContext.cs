using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bookingservices.Models
{
    public partial class FlightDBContext : DbContext
    {
        public FlightDBContext()
        {
        }

        public FlightDBContext(DbContextOptions<FlightDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminTb> AdminTbs { get; set; }
        public virtual DbSet<AirlineTb> AirlineTbs { get; set; }
        public virtual DbSet<BookingTb> BookingTbs { get; set; }
        public virtual DbSet<ScheduledTb> ScheduledTbs { get; set; }
        public virtual DbSet<UserTb> UserTbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET375;Initial Catalog=FlightDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminTb>(entity =>
            {
                entity.ToTable("AdminTb");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<AirlineTb>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.ToTable("AirlineTb");

                entity.Property(e => e.Address).HasMaxLength(10);

                entity.Property(e => e.AirlineLogo)
                    .HasMaxLength(10)
                    .HasColumnName("AirlineLOGO");

                entity.Property(e => e.AirlineName).HasMaxLength(100);

                entity.Property(e => e.ContactNum)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<BookingTb>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("BookingTb");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Airlinename).HasMaxLength(100);

                entity.Property(e => e.Contact).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(100);

                entity.Property(e => e.Pnr)
                    .HasMaxLength(100)
                    .HasColumnName("PNR");

                entity.Property(e => e.Seatnum).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<ScheduledTb>(entity =>
            {
                entity.HasKey(e => e.FlightIdnum);

                entity.ToTable("ScheduledTb");

                entity.Property(e => e.Airlinename).HasMaxLength(100);

                entity.Property(e => e.Enddatetime).HasColumnType("datetime");

                entity.Property(e => e.Fromplace).HasMaxLength(100);

                entity.Property(e => e.Meal).HasMaxLength(100);

                entity.Property(e => e.Scheduledays)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Startdatetime).HasColumnType("datetime");

                entity.Property(e => e.Ticketprice).HasMaxLength(100);

                entity.Property(e => e.Toplace).HasMaxLength(100);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.ScheduledTbs)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK_ScheduledTb_AirlineTb");
            });

            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTb");

                entity.Property(e => e.AirlineName).HasMaxLength(100);

                entity.Property(e => e.Cancelled).HasMaxLength(100);

                entity.Property(e => e.Emailid).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.Meal).HasMaxLength(100);

                entity.Property(e => e.Pnr)
                    .HasMaxLength(100)
                    .HasColumnName("PNR");

                entity.Property(e => e.Seatno).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
