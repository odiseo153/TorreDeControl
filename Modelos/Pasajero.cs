﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorreDeControl.Modelos;

public partial class Pasajero
{
    public int IdPasajero { get; set; }
	[Required]
	public string Nombre { get; set; } = null!;
	[Required]
	public int PesoEquipaje { get; set; }
	[Required]
	public int IdAvion { get; set; }
	[NotMapped]
    public virtual Avione IdAvionNavigation { get; set; } = null!;
}
