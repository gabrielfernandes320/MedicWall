using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace medicwall.Models
{
    public partial class medicwallContext : DbContext
    {
        public medicwallContext()
        {
        }

        public medicwallContext(DbContextOptions<medicwallContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ConfDoctor> ConfDoctor { get; set; }
        public virtual DbSet<ConfPatient> ConfPatient { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<DocsecRel> DocsecRel { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Expertise> Expertise { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<User> User { get; set; }

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

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.ToTable("adress", "medicwall");

                entity.ForNpgsqlHasComment("endereço do usuário");

                entity.HasIndex(e => e.Id)
                    .HasName("adress_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.adress_id_seq'::regclass)");

                entity.Property(e => e.Complement)
                    .HasColumnName("complement")
                    .HasMaxLength(100);

                entity.Property(e => e.FkCity).HasColumnName("fk_city");

                entity.Property(e => e.Nbhood)
                    .HasColumnName("nbhood")
                    .HasMaxLength(40);

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Postalcode).HasColumnName("postalcode");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("date");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(40);

                entity.HasOne(d => d.FkCityNavigation)
                    .WithMany(p => p.Adress)
                    .HasForeignKey(d => d.FkCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("adress_city_fk");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city", "medicwall");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IbgeCode).HasColumnName("ibge_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Uf)
                    .HasColumnName("uf")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ConfDoctor>(entity =>
            {
                entity.ToTable("conf_doctor", "medicwall");

                entity.ForNpgsqlHasComment("Configurações do médico");

                entity.HasIndex(e => e.Id)
                    .HasName("conf_medic_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.conf_doctor_id_seq'::regclass)");

                entity.Property(e => e.ConsultTime).HasColumnName("consult_time");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.FkEspec).HasColumnName("fk_espec");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.FkEspecNavigation)
                    .WithMany(p => p.ConfDoctor)
                    .HasForeignKey(d => d.FkEspec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("conf_medic_expertise_id_fk");
            });

            modelBuilder.Entity<ConfPatient>(entity =>
            {
                entity.ToTable("conf_patient", "medicwall");

                entity.ForNpgsqlHasComment("Configurações do paciente");

                entity.HasIndex(e => e.Id)
                    .HasName("conf_patient_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.conf_patient_id_seq'::regclass)");

                entity.Property(e => e.Allergies)
                    .HasColumnName("allergies")
                    .HasColumnType("character varying");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.RegisterDate).HasColumnName("register_date");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact", "medicwall");

                entity.ForNpgsqlHasComment("contact de usuário");

                entity.HasIndex(e => e.Id)
                    .HasName("contact_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.contact_id_seq'::regclass)");

                entity.Property(e => e.Fone)
                    .HasColumnName("fone")
                    .HasMaxLength(16);

                entity.Property(e => e.Fone2)
                    .HasColumnName("fone2")
                    .HasMaxLength(16);

                entity.Property(e => e.FoneAlt)
                    .HasColumnName("fone_alt")
                    .HasMaxLength(16);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.NameAlt)
                    .HasColumnName("name_alt")
                    .HasColumnType("character varying");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<DocsecRel>(entity =>
            {
                entity.ToTable("docsec_rel", "medicwall");

                entity.HasIndex(e => e.Id)
                    .HasName("docsec_rel_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.docsec_rel_id_seq'::regclass)");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.SecId).HasColumnName("sec_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DocsecRelDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("docsec_rel_user_doc_id_fk");

                entity.HasOne(d => d.Sec)
                    .WithMany(p => p.DocsecRelSec)
                    .HasForeignKey(d => d.SecId)
                    .HasConstraintName("docsec_rel_user_sec_id_fk");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("document", "medicwall");

                entity.ForNpgsqlHasComment("documentação do usuário");

                entity.HasIndex(e => e.Cpf)
                    .HasName("document_cpf_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Crm)
                    .HasName("document_crm_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("document_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("document_rg_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.document_id_seq'::regclass)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasColumnType("character varying");

                entity.Property(e => e.Crm)
                    .HasColumnName("crm")
                    .HasColumnType("character varying");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("rg")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Expertise>(entity =>
            {
                entity.ToTable("expertise", "medicwall");

                entity.ForNpgsqlHasComment("expertises medicas");

                entity.HasIndex(e => e.Id)
                    .HasName("expertise_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("expertise_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.expertise_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role", "medicwall");

                entity.ForNpgsqlHasComment("Identificadores de role");

                entity.HasIndex(e => e.Id)
                    .HasName("roles_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("roles_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.role_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule", "medicwall");

                entity.HasIndex(e => e.Id)
                    .HasName("schedule_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.schedule_id_seq'::regclass)");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("appointment_date")
                    .HasColumnType("date");

                entity.Property(e => e.Canceled).HasColumnName("canceled");

                entity.Property(e => e.CanceledReason)
                    .HasColumnName("canceled_reason")
                    .HasColumnType("character varying");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Observation).HasColumnName("observation");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ScheduleDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_user_doctor_id_fk");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.SchedulePatient)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_user_patient_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "medicwall");

                entity.ForNpgsqlHasComment("Login e fk's");

                entity.HasIndex(e => e.Email)
                    .HasName("user_email_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.FkAdress)
                    .HasName("user_fk_adress_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.FkConfmedico)
                    .HasName("user_fk_confmedico_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.FkConfpaciente)
                    .HasName("user_fk_confpaciente_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.FkContact)
                    .HasName("user_fk_contact_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.FkDocument)
                    .HasName("user_fk_document_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("user_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("user_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('medicwall.user_id_seq'::regclass)");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.FkAdress).HasColumnName("fk_adress");

                entity.Property(e => e.FkConfmedico).HasColumnName("fk_confmedico");

                entity.Property(e => e.FkConfpaciente).HasColumnName("fk_confpaciente");

                entity.Property(e => e.FkContact).HasColumnName("fk_contact");

                entity.Property(e => e.FkDocument).HasColumnName("fk_document");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("character varying");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("date");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.FkAdressNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.FkAdress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_adress_fk");

                entity.HasOne(d => d.FkConfmedicoNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.FkConfmedico)
                    .HasConstraintName("user_conf_medic_fk");

                entity.HasOne(d => d.FkConfpacienteNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.FkConfpaciente)
                    .HasConstraintName("user_conf_patient_fk");

                entity.HasOne(d => d.FkContactNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.FkContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_contact_fk");

                entity.HasOne(d => d.FkDocumentNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.FkDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_document_fk");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_roles_id_fk");
            });

            modelBuilder.HasSequence<int>("adress_id_seq");

            modelBuilder.HasSequence<int>("conf_doctor_id_seq");

            modelBuilder.HasSequence<int>("conf_patient_id_seq");

            modelBuilder.HasSequence<int>("contact_id_seq");

            modelBuilder.HasSequence<int>("docsec_rel_id_seq");

            modelBuilder.HasSequence<int>("document_id_seq");

            modelBuilder.HasSequence<int>("expertise_id_seq");

            modelBuilder.HasSequence<int>("role_id_seq");

            modelBuilder.HasSequence<int>("schedule_id_seq");

            modelBuilder.HasSequence<int>("user_id_seq");
        }
    }
}
