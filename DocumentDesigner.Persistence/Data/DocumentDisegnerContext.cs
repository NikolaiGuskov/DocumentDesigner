using System;
using DocumentDesigner.Persistence.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DocumentDesigner.Persistence.Data
{
    public partial class DocumentDisegnerContext : DbContext
    {
        public DocumentDisegnerContext()
        {
        }

        public DocumentDisegnerContext(DbContextOptions<DocumentDisegnerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<GroupDocuments> GroupDocuments { get; set; }
        public virtual DbSet<HistoryDocuments> HistoryDocuments { get; set; }
        public virtual DbSet<JuridicalPersonIsClient> JuridicalPersonIsClient { get; set; }
        public virtual DbSet<JuridicalPersons> JuridicalPersons { get; set; }
        public virtual DbSet<PhysicalPersons> PhysicalPersons { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<TypeSettings> TypeSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DocumentDisegner;Trusted_Connection=True;");
            }
        }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clients>(entity =>
        {
            entity.HasKey(e => e.ClientId);

            entity.Property(e => e.ClientId).HasColumnName("ClientID");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Patronymic).HasMaxLength(500);

            entity.Property(e => e.Syrname)
                .IsRequired()
                .HasMaxLength(500);
        });

        modelBuilder.Entity<Documents>(entity =>
        {
            entity.HasKey(e => e.DocumentId);

            entity.Property(e => e.DocumentId)
                .HasColumnName("DocumentID")
                .ValueGeneratedNever();

            entity.Property(e => e.GroupId).HasColumnName("GroupID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.ViewName)
                .IsRequired()
                .HasMaxLength(500);

            entity.HasOne(d => d.Group)
                .WithMany(p => p.Documents)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Documents_GroupDocuments");
        });

            modelBuilder.Entity<GroupDocuments>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<HistoryDocuments>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.DocumentId, e.HistoryId });

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.HistoryId)
                    .HasColumnName("HistoryID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.HistoryDocuments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_HistoryDocuments_Clients");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.HistoryDocuments)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK_HistoryDocuments_Documents");
            });

            modelBuilder.Entity<JuridicalPersonIsClient>(entity =>
            {
                entity.HasKey(e => new { e.JuridicalPersonId, e.ClientId });

                entity.Property(e => e.JuridicalPersonId).HasColumnName("JuridicalPersonID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.JuridicalPersonIsClient)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_JuridicalPersonIsClient_Clients");

                entity.HasOne(d => d.JuridicalPerson)
                    .WithMany(p => p.JuridicalPersonIsClient)
                    .HasForeignKey(d => d.JuridicalPersonId)
                    .HasConstraintName("FK_JuridicalPersonIsClient_JuridicalPersons");
            });

            modelBuilder.Entity<JuridicalPersons>(entity =>
            {
                entity.HasKey(e => e.JuridicalPersonId)
                    .HasName("PK_JuridicalPersonIs");

                entity.Property(e => e.JuridicalPersonId).HasColumnName("JuridicalPersonID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasColumnName("INN")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PhysicalPersons>(entity =>
            {
                entity.HasKey(e => e.PhysicalPersonId);

                entity.Property(e => e.PhysicalPersonId).HasColumnName("PhysicalPersonID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Patronymic).HasMaxLength(500);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Syrname)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PhysicalPersons)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_PhysicalPersons_Clients");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.Property(e => e.SettingId).HasColumnName("SettingID");

                entity.Property(e => e.TypeSerringsId).HasColumnName("TypeSerringsID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.TypeSerrings)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.TypeSerringsId)
                    .HasConstraintName("FK_Settings_TypeSettings");
            });

            modelBuilder.Entity<TypeSettings>(entity =>
            {
                entity.HasKey(e => e.TypeSettingId);

                entity.Property(e => e.TypeSettingId)
                    .HasColumnName("TypeSettingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
