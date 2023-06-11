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
            entity.HasKey(e => e.IdAvion).HasName("PK__Aviones__76AC44A9C1907292");

            entity.Property(e => e.IdAvion).HasColumnName("Id_Avion");
            entity.Property(e => e.Estatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estatus");
            entity.Property(e => e.HoraAterrizaje).HasColumnName("hora_aterrizaje");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.IdAeropuertoAterrizaje).HasColumnName("IdAeropuerto_aterrizaje");
            entity.Property(e => e.IdAeropuertoSalida).HasColumnName("IdAeropuerto_salida");
            entity.Property(e => e.LimitePasajeros).HasColumnName("limite_pasajeros");
            entity.Property(e => e.LimitePesoKg).HasColumnName("limite_peso_kg");

            entity.HasOne(d => d.IdAeropuertoAterrizajeNavigation).WithMany(p => p.AvioneIdAeropuertoAterrizajeNavigations)
                .HasForeignKey(d => d.IdAeropuertoAterrizaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aviones__IdAerop__797309D9");

            entity.HasOne(d => d.IdAeropuertoSalidaNavigation).WithMany(p => p.AvioneIdAeropuertoSalidaNavigations)
                .HasForeignKey(d => d.IdAeropuertoSalida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aviones__IdAerop__787EE5A0");
        });

        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.IdPasajero).HasName("PK__Pasajero__31162C4663C616A2");

            entity.Property(e => e.IdPasajero).HasColumnName("Id_Pasajero");
            entity.Property(e => e.IdAvion).HasColumnName("id_Avion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PesoEquipaje).HasColumnName("peso_equipaje");

            entity.HasOne(d => d.IdAvionNavigation).WithMany(p => p.Pasajeros)
                .HasForeignKey(d => d.IdAvion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pasajeros__id_Av__7F2BE32F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
