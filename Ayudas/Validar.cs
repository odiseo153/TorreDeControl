using TorreDeControl.Modelos;

namespace TorreDeControl.Ayudas
{
	public class Validar
	{

		public static bool ValidarEstatus(string estatus,TorreDeControlContext cn)
		{

			bool valido = estatus switch 
			{
			"en vuelo" => true,
			"aterrizado" => true,
			"sin salir" =>true,
		     not "en vuelo" and not "aterrizado" and not "sin salir" => false,
			}; 


			return valido;
		}
	}
}
