using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TorreDeControl.Ayudas;
using TorreDeControl.Modelos;

namespace TorreDeControl.Controllers
{
	public class AvionCRUDController : Controller
	{
		private static TorreDeControlContext cn;
		private Encontrar encontrador = new Encontrar();

		public AvionCRUDController(TorreDeControlContext cns)
		{
			cn = cns;
		}


		[HttpGet("Get")]
		public List<Avione> Obtener()
		{
			return cn.Aviones.ToList();
		}

		[HttpPost("Create")]
		public dynamic Agregar(Avione avio)
		{
			var _avion = (from avion in cn.Aviones
						 where avion.HoraSalida == avio.HoraSalida && avion.AeropuertoEntrada == avio.AeropuertoEntrada
						 select avion).FirstOrDefault();

			if (_avion != null)
			{
				return "no pueden llegar 2 aviones a la misma hora en un mismo aeropuerto";
			}

			if (!Validar.ValidarEstatus(avio.Estatus, cn)) 
			{
				return "Los estados valido del avion son [aterrizado] [en vuelo] [sin salir]";
			}

			cn.Aviones.Add(avio);
			cn.SaveChanges();


			return "Avion agregado Correctamente";
		}

		[HttpPut("Update")]
		public dynamic Actualizar([Required] int IdDeAvionActualizado,Avione avions)
		{
			var avionId = IdDeAvionActualizado;
			var existe = encontrador.EncontrarAvion(avionId, cn);
			dynamic mensaje = $"No existe avion con el Id:{avionId}";
			var avion = cn.Aviones.ToList();

			foreach (var item in avion)
			{
				if (item.IdAvion == avionId)
				{
					item.AeropuertoEntrada = avions.AeropuertoEntrada == null ? item.AeropuertoEntrada: avions.AeropuertoEntrada;
					item.AeropuertoSalida = avions.AeropuertoSalida == null ? item.AeropuertoSalida : avions.AeropuertoSalida;
					item.HoraAterrizaje = avions.HoraAterrizaje == null ? item.HoraAterrizaje : avions.HoraAterrizaje;
					item.HoraSalida = avions.HoraSalida == null ? item.HoraSalida : avions.HoraSalida;
					item.Estatus = avions.Estatus == null ? item.Estatus : avions.Estatus;
					item.LimitePesoKg = avions.LimitePesoKg == null ? item.LimitePesoKg : avions.LimitePesoKg;
					item.LimitePasajeros = avions.LimitePasajeros == null ? item.LimitePasajeros : avions.LimitePasajeros;
					item.Pasajeros = avions.Pasajeros == null ? item.Pasajeros : avions.Pasajeros;

					mensaje = new
					{
						message = $"El avion con el Id:{avionId} fue Actualizado",
						Cambios=item
					};
					//cn.SaveChanges();
				}
			}

			return mensaje;
		}

		[HttpDelete("Delete")]
		public string Eliminar([Required] int idAvion)
		{
			var existe = encontrador.EncontrarAvion(idAvion, cn);
			string mensaje = $"No existe avion con el Id:{idAvion}";


			if (!existe)
			{
				return mensaje;
			}

			var avion = cn.Aviones.ToList();

			foreach (var item in avion)
			{
				if (item.IdAvion == idAvion)
				{
					mensaje = $"El avion con el ID: {idAvion} fue eliminado";
					avion.Remove(item);
					cn.SaveChanges();

				}
			}

			return mensaje;
		}
	}
}
