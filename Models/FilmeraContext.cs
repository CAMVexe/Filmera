using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Filmera.Models;

public partial class FilmeraContext : DbContext
{
    public FilmeraContext()
    {
    }

    public FilmeraContext(DbContextOptions<FilmeraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CAMVCHAR\\SQLEXPRESS;Database=Filmera;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__Pelicula__60537FD03C04EBF6");

            entity.ToTable("Pelicula");

            entity.Property(e => e.IdPelicula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Director)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Publico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sinopsis)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
