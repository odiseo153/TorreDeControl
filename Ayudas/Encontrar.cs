using TorreDeControl.Modelos;

namespace TorreDeControl.Ayudas
{
	public class Encontrar
	{

		public bool EncontrarAvion(int IdAvion,TorreDeControlContext cn)
		{
			var existe = cn.Aviones.Where(x => x.IdAvion == IdAvion).FirstOrDefault();

			bool validar = existe switch
			{
				null => false,
				not null => true,
			};

			return validar;
		}

		public bool EncontrarPasajero(int IdPasajero, TorreDeControlContext cn)
		{
			var existe = cn.Pasajeros.Where(x=>x.IdPasajero==IdPasajero).FirstOrDefault();
			bool validar =existe!=null?true:false;

			return validar;
		}

		public bool EncontrarAeropuerto(int IdAeropuerto, TorreDeControlContext cn)
		{
			var existe = cn.Aeropuertos.Find(IdAeropuerto);
			bool validar = existe == null ? true : false;

			return validar;
		}
	}
}
