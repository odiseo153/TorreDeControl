# TorreDeControl

By Odiseo esmerlin rincon sanchez 
Phone number:2022-0204

Api de aviones hecha en C# con entityFramework y usando SQL SERVER para la administracion de los datos

//////////////////////////////////////////////////////////////////////////////////////

Esta api fue desarrollada siguiendo los siguientes requerimientos:

//////
1- Utilizar una base de datos local para el almacenamiento de 
informaciones.
Crear siguientes endpoints sobre aviones (agregar, eliminar, obtener).

2- Se debe poder controlar los horarios de los aviones, poder ver a qué 
hora salen del aeropuerto y a qué hora aterrizan. 

3- Información extra que deben contener la entidad avión: De que 
aeropuerto salen y de qué aeropuerto llegan.

4- Debe existir un campo que indique si un avión ya aterrizo, sigue en vuelo 
o aun no sale del aeropuerto.

5- Cuando llegue la hora de aterrizaje, se debe modificar el campo de 
estatus de vuelo en la base de datos.

6- Endpoint para crear pasajeros.

7- Se debe poder ver que pasajeros y cuantos hay en cada avión.

8- Los aviones deben tener un límite de pasajeros.

9- Endpoint de crear aeropuertos.

10- Límite de aviones por aeropuerto.

11- Solo pueden salir 2 aviones a la misma hora del mismo aeropuerto y no 
pueden llegar 2 aviones a la misma hora en un mismo aeropuerto.

12- Debe existir un peso limite por avión y cada pasajero debe tener un peso 
de equipaje, la suma de los equipajes de todos los pasajeros que se 
registraran en el avión no puede exceder el límite de peso del avión.

13- Se deben mostrar a modo de datos la cantidad de pasajeros y peso por 
avión, ejemplo: pasajeros 27/40 y peso 37kg/200kg (Cualquier unidad de 
medida es válida).

14- Mostrar los lapsos de tiempo entre la hora de salida y la de aterrizaje, 
ejemplo: si el avión está en vuelo, mostrar que faltan 3 horas para que 
aterrice






