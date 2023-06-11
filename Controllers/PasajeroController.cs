using Microsoft.AspNetCore.Mvc;
using TorreDeControl.Ayudas;
using TorreDeControl.Modelos;

namespace TorreDeControl.Controllers
{
	public class PasajeroController : Controller
	{

		private TorreDeControlContext cn;
		

		public PasajeroController(TorreDeControlContext cn)
		{
			this.cn = cn;
		}

		[HttpGet("VerPasajeros")]
		public List<Pasajero> VerPasajeros()
		{
			return cn.Pasajeros.ToList();
		}



		[HttpPost("CrearPasajero")]
		public dynamic CrearPasajero(Pasajero persona)
		{
			string mensaje = "Pasajero Creado Correctamente";
			var validar = cn.Aviones.FirstOrDefault(x => x.IdAvion == persona.IdAvion);


			if (validar == null) 
			{
				mensaje = $"no existe Avion Con el ID: {persona.IdAvion}";
			}
			else 
			{
				var TotalPesoDeEquipaje = (from p in cn.Pasajeros join a in cn.Aviones on p.IdAvion equals a.IdAvion select p.PesoEquipaje).Sum();
				var LimitePesoDelAvion = (from a in cn.Aviones where a.IdAvion == persona.IdAvion select a.LimitePesoKg).Sum();

				if (TotalPesoDeEquipaje+persona.PesoEquipaje >= LimitePesoDelAvion)
				{
					return $"El peso {persona.PesoEquipaje} de su equipaje no cabe, el avion a llegado a su limite de equipaje";
				}

			
				//cn.Pasajeros.Add(persona);
				//cn.SaveChanges();
			}

			return mensaje;
		}
	}
}
