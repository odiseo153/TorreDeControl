using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorreDeControl.Modelos;

public partial class Aeropuerto
{
    public int IdAeropuerto { get; set; }

    [Required]
    public string? Nombre { get; set; }
    [Required]
    public int? LimiteAviones { get; set; }

    public virtual ICollection<Avione> AvioneIdAeropuertoAterrizajeNavigations { get; set; } = new List<Avione>();

    public virtual ICollection<Avione> AvioneIdAeropuertoSalidaNavigations { get; set; } = new List<Avione>();
}
