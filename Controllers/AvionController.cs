using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TorreDeControl.Modelos;

namespace TorreDeControl.Controllers
{
	public class AvionController : Controller
	{
		private TorreDeControlContext cn;

		public AvionController(TorreDeControlContext cn)
		{
			this.cn = cn;
		}

		[HttpGet("Obtener")]
		public List<Avione> Obtener()
		{
			return cn.Aviones.ToList();
		}

		[HttpPut("Llego hora de Vuelo")]
		public string CambiarEstatus([Required]int idAvion, [Required] string NuevoEstatus)
		{
			string mensaje = $"No se encontro avion con el ID: {idAvion}";
			var avion = cn.Aviones.FirstOrDefault(x=>x.IdAvion == idAvion);

			avion.Estatus = NuevoEstatus;
			cn.SaveChanges();
			return "Avion actualizado";
		}

		[HttpPost("Agregar")]
		public string Agregar(Avione avio)
		{

			cn.Aviones.Add(avio);
			cn.SaveChanges();


			return "Avion agregado con exito";
		}

		[HttpDelete("Eliminar")]
		public string Eliminar([Required] int id)
		{
			string mensaje = $"No se encontro avion con el ID: {id}";
			var avion = cn.Aviones.ToList();

			foreach (var item in avion)
			{
				if (item.IdAvion == id)
				{
					mensaje = $"El avion con el ID: {id} fue eliminado";
					avion.Remove(item);
					cn.SaveChanges();

				}
			}

			return mensaje;
		}
	}
}
