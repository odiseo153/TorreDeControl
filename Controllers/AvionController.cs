using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using TorreDeControl.Ayudas;
using TorreDeControl.Modelos;

namespace TorreDeControl.Controllers
{
	public class AvionController : Controller
	{
		private static TorreDeControlContext cn;
		private Encontrar encontrador = new Encontrar();

		public AvionController(TorreDeControlContext cns)
		{
		   cn = cns;
		}

		[HttpGet("LimitesDelAvionPasajerosPeso")]
		public dynamic CantidadPasajerosPeso(int IdAvion)
		{
			var existeAvion = encontrador.EncontrarAvion(IdAvion, cn);
			if (!existeAvion)
			{
				return $"No existe avion con el Id:{IdAvion}";
			}

			var pasajeros = (from p in cn.Pasajeros where p.IdAvion == IdAvion select p).Count();
			var avionPasajerosLimite =cn.Aviones.Where(x=>x.IdAvion==IdAvion).FirstOrDefault().LimitePasajeros;
			var PasajeroLimites = $"{pasajeros}/{avionPasajerosLimite}";

			var pesoPasajeros= (from p in cn.Pasajeros select p.PesoEquipaje).Sum(); 
			var avionPesoLimite = cn.Aviones.Where(x => x.IdAvion == IdAvion).FirstOrDefault().LimitePesoKg;
			var PesoLimite = $"{pesoPasajeros}kg/{avionPesoLimite}kg";

			var Limites = new
			{
			Pasajeros=PasajeroLimites,
			Peso = PesoLimite,
			};


			return Limites;
		}

		[HttpGet("LapsoDeTiempoDeLlegada")]
		public dynamic CalculoTiempo(int IdAvion) 
		{
			var existeAvion = encontrador.EncontrarAvion(IdAvion, cn);
			if (!existeAvion)
			{
				return $"No existe avion con el Id:{IdAvion}";
			}

			var avionTiempo = from a in cn.Aviones where a.IdAvion ==IdAvion select new {
			HoraDeSalida = a.HoraSalida,
			HoraDeLlegada = a.HoraAterrizaje,
			TiempoRestanteParaAterizaje=Math.Abs((decimal)(a.HoraSalida-a.HoraAterrizaje))+" hora"
			};


        
						   
						  
		return avionTiempo;
		}


		[HttpPut("AbordarPasajeroExistente")]
		public string CambiarEstatus([Required] int idAvion, [Required] int IdPasajero)
		{
			var existeAvion = encontrador.EncontrarAvion(idAvion, cn);
			var existePasajero = encontrador.EncontrarPasajero(IdPasajero, cn);

			string mensaje = $"Pasajero Abordado en el avion con el ID: {idAvion}";

			if (!existeAvion)
			{
				mensaje = $"No existe avion con el Id:{idAvion}";
			}
			else if (!existePasajero)
			{
				mensaje = $"No existe pasajero con el Id: {IdPasajero}";
			}

			var PasajerosEnAvion = cn.Pasajeros.Where(x=>x.IdAvion == idAvion);
			var Avion = cn.Aviones.Where(x => x.IdAvion == idAvion).FirstOrDefault();

			if (PasajerosEnAvion.Count() >= Avion.LimitePasajeros)
			{
				mensaje = "El avion llego a su limite de pasajeros debe de buscar otro avion";
			}



            var pasajero = cn.Pasajeros.FirstOrDefault(x => x.IdPasajero == IdPasajero);

			if(pasajero.IdAvion == idAvion) 
			{
				mensaje = "El pasajero ya aborda ese avion";
			}
			else if(Avion.Estatus == "en vuelo")
			{
				return $"El avion con el Id: {idAvion} esta en vuelo no se puede montar al pasajero";			
			}
			else 
			{
				pasajero.IdAvion = idAvion;
				cn.SaveChanges();
			}



			return mensaje;
		}

		[HttpGet("MostrarPasajerosAbordoEnAvion")]
		public dynamic MostrarPasajeros([Required]int IdAvion)
		{
			
			var existe = encontrador.EncontrarAvion(IdAvion,cn);

			if (!existe) 
			{
				return $"No existe avion con el Id:{IdAvion}";
			}

			var pasajerosAbordo = from pasajeros in cn.Pasajeros  where pasajeros.IdAvion == IdAvion
								   select new
								   {
									   IdDelAvion = IdAvion,
									   PasajeroAbordo = pasajeros.Nombre,
								   };

		return pasajerosAbordo;
		}




	

		[HttpPut("LlegoHoraDeVuelo")]
		public string CambiarEstatus([Required] int idAvion, [Required] string NuevoEstatus)
		{
			var existe = encontrador.EncontrarAvion(idAvion, cn);
			

			if (!Validar.ValidarEstatus(NuevoEstatus,cn))
			{
				return "Los estados valido del avion son [aterrizado] [en vuelo] [sin salir]";
			}																					

			if (!existe)
			{
				return $"No existe avion con el Id:{idAvion}";
			}

			var avion = cn.Aviones.FirstOrDefault(x => x.IdAvion == idAvion);

			avion.Estatus = NuevoEstatus;
			cn.SaveChanges();

			return "Avion actualizado";
		}

		
	}
}
