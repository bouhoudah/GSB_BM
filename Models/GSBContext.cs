using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GSB_BM.Models
{
    public partial class GSBContext : DbContext
    {
        public GSBContext()
        {
        }

        public GSBContext(DbContextOptions<GSBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departement> Departements { get; set; } = null!;
        public virtual DbSet<Medecin> Medecins { get; set; } = null!;
        public virtual DbSet<Specialite> Specialites { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-0190US85;Initial Catalog=GSB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.CodeDepartement)
                    .HasName("PK__Departem__91E224315863DC04");

                entity.ToTable("Departement");

                entity.Property(e => e.CodeDepartement)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("code_departement");

                entity.Property(e => e.CodeRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code_region");

                entity.Property(e => e.NomDepartement)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom_Departement");

                entity.Property(e => e.NomRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom_Region");
            });

            modelBuilder.Entity<Medecin>(entity =>
            {
                entity.HasKey(e => e.Idmedecin)
                    .HasName("PK__Medecin__41DE461D49BB9678");

                entity.ToTable("Medecin");

                entity.Property(e => e.Idmedecin).HasColumnName("IDmedecin");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeDepartement)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("code_departement");

                entity.Property(e => e.Idspecialite).HasColumnName("IDspecialite");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prenom");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeDepartementNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.CodeDepartement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__code_de__5165187F");

                entity.HasOne(d => d.IdspecialiteNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.Idspecialite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__IDspeci__52593CB8");
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasKey(e => e.Idspecialite)
                    .HasName("PK__Speciali__410C43E4F528ED8E");

                entity.ToTable("Specialite");

                entity.Property(e => e.Idspecialite).HasColumnName("IDspecialite");

                entity.Property(e => e.Nomspecialite)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.Idutlisateurs)
                    .HasName("PK__utilisat__16A0495B5BBB3B5C");

                entity.ToTable("utilisateurs");

                entity.Property(e => e.Idutlisateurs)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDutlisateurs");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
