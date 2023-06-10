using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TorreDeControl.Modelos;

public partial class TorreDeControlContext : DbContext
{
    public TorreDeControlContext()
    {
    }

    public TorreDeControlContext(DbContextOptions<TorreDeControlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Avione> Aviones { get; set; }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=odiseo\\ODISEO;Database=TorreDeControl;User Id=sa;Password=1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasKey(e => e.IdAeropuerto).HasName("PK__Aeropuer__1080B8BA3667418A");

            entity.Property(e => e.IdAeropuerto).HasColumnName("Id_Aeropuerto");
            entity.Property(e => e.LimiteAviones).HasColumnName("limite_aviones");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Avione>(entity =>
        {
            entity.HasKey(e => e.IdAvion).HasName("PK__Aviones__76AC44A9CD5BDF4F");

            entity.Property(e => e.IdAvion).HasColumnName("Id_Avion");
            entity.Property(e => e.AeropuertoEntrada)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aeropuerto_entrada");
            entity.Property(e => e.AeropuertoSalida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aeropuerto_salida");
            entity.Property(e => e.Estatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estatus");
            entity.Property(e => e.HoraEntrada).HasColumnName("hora_entrada");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.LimitePasajeros).HasColumnName("limite_pasajeros");
            entity.Property(e => e.LimitePesoKg).HasColumnName("limite_peso_kg");
        });

        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.IdPasajero).HasName("PK__Pasajero__31162C46E388882B");

            entity.Property(e => e.IdPasajero).HasColumnName("Id_Pasajero");
            entity.Property(e => e.IdAvion).HasColumnName("id_Avion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PesoEquipaje).HasColumnName("peso_equipaje");

            entity.HasOne(d => d.IdAvionNavigation).WithMany(p => p.Pasajeros)
                .HasForeignKey(d => d.IdAvion)
                .HasConstraintName("FK__Pasajeros__id_Av__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
