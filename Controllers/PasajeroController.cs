using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TorreDeControl.Ayudas;
using TorreDeControl.Modelos;

namespace TorreDeControl.Controllers
{
	public class PasajeroController : Controller
	{
		
		private TorreDeControlContext cn;
		private Encontrar encontrador = new Encontrar();

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
					return $"El peso {persona.PesoEquipaje} de su equipaje no cabe en el Avion con el ID:{persona.IdAvion}";
				}

			
				cn.Pasajeros.Add(persona);
				cn.SaveChanges();
			}

			return mensaje;
		}



		[HttpPut("ActualizarPasajeros")]
		public IActionResult ActualizarPasajeros([Required]int IdPasajero,Pasajero persona) 
		{
			
			dynamic mensaje = $"No existe pasajero con el Id:{IdPasajero}";
			
			var pasajero = cn.Pasajeros.ToList();

			foreach (var item in pasajero)
			{
				if (item.IdAvion == IdPasajero)
				{
					item.Nombre = persona.Nombre == null ? item.Nombre : persona.Nombre;
					item.PesoEquipaje = persona.PesoEquipaje == null ? item.PesoEquipaje : persona.PesoEquipaje;

					mensaje = new
					{
						message = $"El Pasajero con el Id:{IdPasajero} fue Actualizado",
						Cambios = item
					};
					//cn.SaveChanges();
				}
			}

			return mensaje;

		}


		[HttpDelete("EliminarPasajero")]
		public string Eliminar([Required] int idPasajero)
		{
			var existe = encontrador.EncontrarPasajero(idPasajero, cn);
			string mensaje = $"No existe pasajero con el Id:{idPasajero}";


			if (!existe)
			{
				return mensaje;
			}

			var pasajero = cn.Pasajeros;

			foreach (var item in pasajero.ToList())
			{
				if (item.IdAvion == idPasajero)
				{
					mensaje = $"El Pasajero con el ID: {idPasajero} fue eliminado";
					pasajero.Remove(item);
					cn.SaveChanges();

				}
			}

			return mensaje;
		}
		
	}
}
