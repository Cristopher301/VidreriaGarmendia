using Microsoft.EntityFrameworkCore;
using VidreriaGarmendia.Models;

namespace VidreriaGarmendia.Data;

public class VidreriaDbContext : DbContext
{
    public VidreriaDbContext(DbContextOptions<VidreriaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contacto> Contactos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.ToTable("Contactos");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.Nombre).HasColumnType("varchar(100)").IsRequired();
            entity.Property(c => c.Correo).HasColumnType("varchar(150)").IsRequired();
            entity.Property(c => c.Telefono).HasColumnType("varchar(30)");
            entity.Property(c => c.Mensaje).HasColumnType("varchar(max)").IsRequired();
            entity.Property(c => c.FechaRegistro).HasColumnType("datetime");
        });
    }
}
