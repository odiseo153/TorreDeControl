using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TorreDeControl.Ayudas;
using TorreDeControl.Modelos;

namespace TorreDeControl.Controllers
{
	public class AeropuertosController : Controller
	{
		private Encontrar encontrador = new Encontrar();

		private TorreDeControlContext cn;
		public AeropuertosController(TorreDeControlContext cn)
		{
			this.cn = cn;
		}

		[HttpGet("VerAeropuerto")]
		public List<Aeropuerto> VerAeropuertos()
		{
			return cn.Aeropuertos.ToList();			
		}

		[HttpPost("CrearAeropuertos")]
		public IActionResult CrearAeropuertos(Aeropuerto airport)
		{

			cn.Aeropuertos.Add(airport);
			cn.SaveChanges();

			return Ok("Aeropuerto creado con exito");
		}

		[HttpPut("ActualizarAeropuerto")]
		public IActionResult ActualizarAeropuertos([Required]int idA,Aeropuerto airport)
		{
			var existe = encontrador.EncontrarAvion(idA, cn);
			dynamic mensaje = $"No existe aeropuerto con el Id:{idA}";
			var aeropuerto = cn.Aeropuertos;

            foreach (var item in aeropuerto.ToList())
            {
				if (item.IdAeropuerto == idA) 
				{
					item.LimiteAviones = airport.LimiteAviones == null ? item.LimiteAviones : airport.LimiteAviones;
					item.Nombre = airport.Nombre == null ? item.Nombre : airport.Nombre;
				}
				
				mensaje = new
				{
					message = $"El Aeropuerto con el Id:{idA} fue Actualizado exitosamente",
					Cambios = item
				};

				cn.SaveChanges();
            }

            return Ok(mensaje);
		}

		[HttpDelete("BorrarAeropuerto")]
		public string EliminarAeropuertos([Required] int idAeropuerto)
		{
			var existe = encontrador.EncontrarAeropuerto(idAeropuerto, cn);
			string mensaje = $"No existe Aeropuerto con el Id:{idAeropuerto}";


			if (!existe)
			{
				return mensaje;
			}

			var Aeropuerto = cn.Aeropuertos;

			foreach (var item in Aeropuerto.ToList())
			{
				if (item.IdAeropuerto == idAeropuerto)
				{
					mensaje = $"El Aeropuerto con el ID: {idAeropuerto} fue eliminado";
					Aeropuerto.Remove(item);
					cn.SaveChanges();

				}
			}

			return mensaje;
		}
	}
}
