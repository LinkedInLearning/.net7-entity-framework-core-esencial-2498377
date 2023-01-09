using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EjemploScaffolding;

public partial class WpmContext : DbContext
{
    public WpmContext()
    {
    }

    public WpmContext(DbContextOptions<WpmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=DESKTOP-F1HJ3VT\\SQLEXPRESS;Initial Catalog=Wpm;Integrated Security=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasIndex(e => e.BreedId, "IX_Pets_BreedId");

            entity.HasIndex(e => e.SpeciesId, "IX_Pets_SpeciesId");

            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Breed).WithMany(p => p.Pets).HasForeignKey(d => d.BreedId);

            entity.HasOne(d => d.Species).WithMany(p => p.Pets).HasForeignKey(d => d.SpeciesId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
