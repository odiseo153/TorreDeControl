using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorreDeControl.Modelos;

public partial class Avione
{
    public int IdAvion { get; set; }

    public string? AeropuertoSalida { get; set; }

    public string? AeropuertoEntrada { get; set; }

    public int? HoraSalida { get; set; }

    public int? HoraAterrizaje { get; set; }

    public string? Estatus { get; set; }

    public int? LimitePesoKg { get; set; }

    public int? LimitePasajeros { get; set; }

    [NotMapped]
    public virtual ICollection<Pasajero> Pasajeros { get; set; } = new List<Pasajero>();
}
