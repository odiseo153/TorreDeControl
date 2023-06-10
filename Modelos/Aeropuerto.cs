using System;
using System.Collections.Generic;

namespace TorreDeControl.Modelos;

public partial class Aeropuerto
{
    public int IdAeropuerto { get; set; }

    public string? Nombre { get; set; }

    public int? LimiteAviones { get; set; }
}
