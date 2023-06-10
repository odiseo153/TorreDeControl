using Microsoft.AspNetCore.Mvc;
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
		public ActionResult<string> CrearPasajero(Pasajero persona)
		{
			string mensaje = "Pasajero Creado Correctamente";
			var validar = cn.Aviones.FirstOrDefault(x => x.IdAvion == persona.IdAvion);
			
			if (validar == null) 
			{
				mensaje = $"no existe Avion Con el ID: {persona.IdAvion}";
			}
			else 
			{
				cn.Pasajeros.Add(persona);
				cn.SaveChanges();
			}

			return mensaje;
		}
	}
}
