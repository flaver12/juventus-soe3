using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace linq.Model;

public partial class JuveTestContext : DbContext
{
    public JuveTestContext()
    {
    }

    public JuveTestContext(DbContextOptions<JuveTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abteilung> Abteilungs { get; set; }

    public virtual DbSet<Mitarbeiter> Mitarbeiters { get; set; }

    public virtual DbSet<Projekte> Projektes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=JuveTest;User ID=sa;Password=\"YourStrong(!)Password\";Trusted_Connection=False;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abteilung>(entity =>
        {
            entity.ToTable("Abteilung");

            entity.Property(e => e.AbteilungId).HasColumnName("AbteilungID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mitarbeiter>(entity =>
        {
            entity.ToTable("Mitarbeiter");

            entity.Property(e => e.MitarbeiterId).HasColumnName("MitarbeiterID");
            entity.Property(e => e.AbteilungId).HasColumnName("AbteilungID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjektId).HasColumnName("ProjektID");
            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Abteilung).WithMany(p => p.Mitarbeiters)
                .HasForeignKey(d => d.AbteilungId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mitarbeiter_Abteilung");

            entity.HasOne(d => d.Projekt).WithMany(p => p.Mitarbeiters)
                .HasForeignKey(d => d.ProjektId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mitarbeiter_Projekte");
        });

        modelBuilder.Entity<Projekte>(entity =>
        {
            entity.ToTable("Projekte");

            entity.Property(e => e.ProjekteId).HasColumnName("ProjekteID");
            entity.Property(e => e.ProjektName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
