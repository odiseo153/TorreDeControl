using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorreDeControl.Modelos;

public partial class Avione
{
    public int IdAvion { get; set; }
    [Required]
    public int IdAeropuertoSalida { get; set; }
	[Required]
	public int IdAeropuertoAterrizaje { get; set; }
	[Required]
	public int HoraSalida { get; set; }
	[Required]
	public int HoraAterrizaje { get; set; }
	[Required]
	public string Estatus { get; set; } = null!;
	[Required]
	public int LimitePesoKg { get; set; }
	[Required]
	public int LimitePasajeros { get; set; }

    [NotMapped]
    public virtual Aeropuerto IdAeropuertoAterrizajeNavigation { get; set; } = null!;
	[NotMapped]
	public virtual Aeropuerto IdAeropuertoSalidaNavigation { get; set; } = null!;
	[NotMapped]
	public virtual ICollection<Pasajero> Pasajeros { get; set; } = new List<Pasajero>();
}
