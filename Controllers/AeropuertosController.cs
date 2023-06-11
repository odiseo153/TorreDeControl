using Microsoft.AspNetCore.Mvc;
using TorreDeControl.Modelos;

namespace TorreDeControl.Controllers
{
	public class AeropuertosController : Controller
	{
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
	}
}
