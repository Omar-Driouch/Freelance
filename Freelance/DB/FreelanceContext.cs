using System;
using System.Collections.Generic;
using Freelance.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelance.DB;

public partial class FreelanceContext : DbContext
{
    public FreelanceContext()
    {
    }
    public FreelanceContext(DbContextOptions<FreelanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Competence> Competences { get; set; }

    public virtual DbSet<CompetenceOffre> CompetenceOffres { get; set; }

    public virtual DbSet<ComptenceDmExpertise> ComptenceDmExpertises { get; set; }

    public virtual DbSet<Condidat> Condidats { get; set; }

    public virtual DbSet<CondidatComp> CondidatComps { get; set; }

    public virtual DbSet<ConsultaionProfil> ConsultaionProfils { get; set; }

    public virtual DbSet<DomaineExpertise> DomaineExpertises { get; set; }

    public virtual DbSet<Entreprise> Entreprises { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Formation> Formations { get; set; }

    public virtual DbSet<Messagery> Messageries { get; set; }

    public virtual DbSet<Offre> Offres { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MC0ORJ6\\SQLEXPRESS;Initial Catalog=freelance;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("French_CI_AS");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<CompetenceOffre>(entity =>
        {
            entity.HasIndex(e => e.IdCompetenceNavigationId, "IX_CompetenceOffres_IdCompetenceNavigationId");

            entity.HasIndex(e => e.IdOffreNavigationId, "IX_CompetenceOffres_IdOffreNavigationId");

            entity.HasOne(d => d.IdCompetenceNavigation).WithMany(p => p.CompetenceOffres).HasForeignKey(d => d.IdCompetenceNavigationId);

            entity.HasOne(d => d.IdOffreNavigation).WithMany(p => p.CompetenceOffres).HasForeignKey(d => d.IdOffreNavigationId);
        });

        modelBuilder.Entity<ComptenceDmExpertise>(entity =>
        {
            entity.HasIndex(e => e.IdCompetenceNavigationId, "IX_ComptenceDmExpertises_IdCompetenceNavigationId");

            entity.HasIndex(e => e.IdDmexpertiseNavigationId, "IX_ComptenceDmExpertises_IdDmexpertiseNavigationId");

            entity.HasOne(d => d.IdCompetenceNavigation).WithMany(p => p.ComptenceDmExpertises).HasForeignKey(d => d.IdCompetenceNavigationId);

            entity.HasOne(d => d.IdDmexpertiseNavigation).WithMany(p => p.ComptenceDmExpertises).HasForeignKey(d => d.IdDmexpertiseNavigationId);
        });

        modelBuilder.Entity<CondidatComp>(entity =>
        {
            entity.HasIndex(e => e.CompetenceId, "IX_CondidatComps_CompetenceId");

            entity.HasIndex(e => e.IdCompNavigationId, "IX_CondidatComps_IdCompNavigationId");

            entity.HasIndex(e => e.IdCondNavigationId, "IX_CondidatComps_IdCondNavigationId");

            entity.HasOne(d => d.Competence).WithMany(p => p.CondidatComps).HasForeignKey(d => d.CompetenceId);

            entity.HasOne(d => d.IdCompNavigation).WithMany(p => p.CondidatComps).HasForeignKey(d => d.IdCompNavigationId);

            entity.HasOne(d => d.IdCondNavigation).WithMany(p => p.CondidatComps).HasForeignKey(d => d.IdCondNavigationId);
        });

        modelBuilder.Entity<ConsultaionProfil>(entity =>
        {
            entity.HasIndex(e => e.IdCondidatNavigationId, "IX_ConsultaionProfils_IdCondidatNavigationId");

            entity.HasIndex(e => e.IdEntrepriseNavigationId, "IX_ConsultaionProfils_IdEntrepriseNavigationId");

            entity.HasOne(d => d.IdCondidatNavigation).WithMany(p => p.ConsultaionProfils).HasForeignKey(d => d.IdCondidatNavigationId);

            entity.HasOne(d => d.IdEntrepriseNavigation).WithMany(p => p.ConsultaionProfils).HasForeignKey(d => d.IdEntrepriseNavigationId);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasIndex(e => e.IdCondidatNavigationId, "IX_Experiences_IdCondidatNavigationId");

            entity.HasOne(d => d.IdCondidatNavigation).WithMany(p => p.Experiences).HasForeignKey(d => d.IdCondidatNavigationId);
        });

        modelBuilder.Entity<Formation>(entity =>
        {
            entity.HasIndex(e => e.IdCondidatNavigationId, "IX_Formations_IdCondidatNavigationId");

            entity.HasOne(d => d.IdCondidatNavigation).WithMany(p => p.Formations).HasForeignKey(d => d.IdCondidatNavigationId);
        });

        modelBuilder.Entity<Messagery>(entity =>
        {
            entity.HasIndex(e => e.ExpediteurId, "IX_Messageries_ExpediteurId");

            entity.HasIndex(e => e.ExpediteurNavigationId, "IX_Messageries_ExpediteurNavigationId");

            entity.HasOne(d => d.Expediteur).WithMany(p => p.Messageries).HasForeignKey(d => d.ExpediteurId);

            entity.HasOne(d => d.ExpediteurNavigation).WithMany(p => p.Messageries).HasForeignKey(d => d.ExpediteurNavigationId);
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.HasIndex(e => e.IdCondidatNavigationId, "IX_Projets_IdCondidatNavigationId");

            entity.HasOne(d => d.IdCondidatNavigation).WithMany(p => p.Projets).HasForeignKey(d => d.IdCondidatNavigationId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
