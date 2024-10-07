# Torre de Control API

**Desarrollador**: Odiseo Esmerlin Rincón Sánchez  
**Teléfono**: 829-789-0766

Esta API para la gestión de aviones ha sido desarrollada en C# utilizando Entity Framework y SQL Server para la administración de los datos.

---

## Descripción

La **Torre de Control API** permite gestionar vuelos, aviones, aeropuertos y pasajeros, proporcionando control sobre los horarios de vuelo, la capacidad de los aviones, el estado de los vuelos, y las restricciones operacionales de los aeropuertos. Está diseñada para cumplir con una serie de requisitos funcionales específicos.

---

## Funcionalidades Implementadas

1. **Gestión de Aviones**:  
   - Endpoints para agregar, eliminar y obtener información sobre aviones.
   - Los aviones incluyen información sobre el aeropuerto de salida y el aeropuerto de destino.

2. **Horarios de Vuelo**:  
   - Control sobre los horarios de salida y llegada de los aviones.
   - Verificación del estado del vuelo: aún en el aeropuerto, en vuelo, o aterrizado.
   - Actualización automática del estado del vuelo cuando se alcanza la hora de aterrizaje.

3. **Creación de Aeropuertos**:  
   - Endpoint para agregar aeropuertos.
   - Los aeropuertos tienen un límite de capacidad para la cantidad de aviones que pueden operar desde ellos.

4. **Control de Pasajeros**:  
   - Endpoint para crear pasajeros.
   - Capacidad para ver qué pasajeros están en cada avión, así como el número total de pasajeros por vuelo.
   - Los aviones tienen un límite de pasajeros, que no puede ser excedido.

5. **Restricciones de Operación en Aeropuertos**:  
   - Solo pueden despegar hasta dos aviones simultáneamente desde un mismo aeropuerto.
   - No pueden aterrizar más de dos aviones a la misma hora en un mismo aeropuerto.

6. **Control de Peso en los Aviones**:  
   - Cada avión tiene un límite de peso máximo.
   - Cada pasajero tiene un peso de equipaje asignado. La suma de los pesos de los equipajes no debe superar el límite de peso del avión.

7. **Monitoreo de Ocupación y Peso**:  
   - Mostrar el número de pasajeros y el peso de equipaje total para cada avión, por ejemplo: `27/40 pasajeros y 37kg/200kg de peso`.

8. **Cálculo de Tiempo de Vuelo**:  
   - Mostrar el tiempo restante para el aterrizaje de un avión en vuelo, ejemplo: `Faltan 3 horas para aterrizar`.

---

## Requerimientos Técnicos

- **Lenguaje**: C#
- **Framework**: .NET Core
- **ORM**: Entity Framework Core
- **Base de Datos**: SQL Server

---

## Endpoints Principales

### Aviones
- **POST /aviones**: Agregar un nuevo avión.
- **DELETE /aviones/{id}**: Eliminar un avión existente.
- **GET /aviones**: Obtener la lista de todos los aviones.
  
### Pasajeros
- **POST /pasajeros**: Crear un nuevo pasajero.
- **GET /pasajeros/{idAvion}**: Ver los pasajeros asignados a un avión específico.

### Aeropuertos
- **POST /aeropuertos**: Crear un nuevo aeropuerto.
- **GET /aeropuertos**: Obtener la lista de aeropuertos.

### Vuelos
- **GET /vuelos/{idAvion}**: Ver el estado de un vuelo, incluyendo horarios de salida y llegada, y estado actual (en vuelo, aterrizado, etc.).

---

Esta API fue desarrollada para cumplir con todas las restricciones y requerimientos detallados en la especificación, proporcionando un sistema robusto y eficiente para la gestión de vuelos y pasajeros.

---
