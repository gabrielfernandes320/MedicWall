using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Agendator.Models
{
    public partial class agendatorContext : DbContext
    {
        public agendatorContext()
        {
        }

        public agendatorContext(DbContextOptions<agendatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=medicwall;Username=postgres;Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Email })
                    .HasName("pk_Client");

                entity.ToTable("Client", "public");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('public.\"Client_ID_seq\"'::regclass)");

                entity.Property(e => e.Email).HasColumnType("character varying");

                entity.Property(e => e.CellPhone)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Client_Role");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Email })
                    .HasName("pk_Employee");

                entity.ToTable("Employee", "public");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('public.\"Employee_ID_seq\"'::regclass)");

                entity.Property(e => e.Email).HasColumnType("character varying");

                entity.Property(e => e.AppointmentTime).HasColumnType("time without time zone");

                entity.Property(e => e.AppointmentValue).HasColumnType("money");

                entity.Property(e => e.CellPhone)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.EndWorkTime).HasColumnType("time without time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.StartWorkTime).HasColumnType("time without time zone");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Employee_Role");

                entity.HasOne(d => d.SpecialtyNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Specialty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Employee_Specialty");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "public");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('public.\"Role_ID_seq\"'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule", "public");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('public.\"Schedule_ID_seq\"'::regclass)");

                entity.Property(e => e.AppointmentEndTime).HasColumnType("time without time zone");

                entity.Property(e => e.AppointmentStartTime).HasColumnType("time without time zone");

                entity.Property(e => e.Appointmentdate)
                    .HasColumnName("appointmentdate")
                    .HasColumnType("date");

                entity.Property(e => e.CanceledReason)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.ExpectedPrice).HasColumnType("money");

                entity.Property(e => e.FinalPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.ToTable("Specialty", "public");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('public.\"Specialty_ID_seq\"'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.HasSequence<int>("Client_ID_seq");

            modelBuilder.HasSequence<int>("Employee_ID_seq");

            modelBuilder.HasSequence<int>("Role_ID_seq");

            modelBuilder.HasSequence<int>("Schedule_ID_seq");

            modelBuilder.HasSequence<int>("Specialty_ID_seq");

        }
    }
}
