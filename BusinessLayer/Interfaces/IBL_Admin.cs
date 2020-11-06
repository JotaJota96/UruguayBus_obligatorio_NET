using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Admin
    {
        /// <summary>
        /// Registra un nuevo vehiculo en el sistema
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        Vehiculo RegistrarVehiculo(Vehiculo v);

        /// <summary>
        /// Modifica los datos de un vehiculo
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        Vehiculo ModificarVehiculo(Vehiculo v);

        /// <summary>
        /// Registra una nueva parada en el sistema
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Parada RegistrarParada(Parada p);

        /// <summary>
        /// Modifica una parada especifica
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Parada ModificarParada(Parada p);

        /// <summary>
        /// Registra una nueva linea en el sistema, sus respectivos tramos, y el precio de cada tramo
        /// Vinculos esperados: La linea debe estar vinculada a los tramos, cada tramo a una parada, cada precio a un tramo
        /// </summary>
        /// <param name="l">Linea a crear y sus respectivas asociaciones</param>
        /// <returns></returns>
        Linea RegistrarLinea(Linea l);

        /// <summary>
        /// Registra un nuevo horario en el sistema, y su respectivo conductor, vehiculo y linea
        /// Vinculos esperados: El horario debe estar vinculada a un conductor, un vehiculo y una linea
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        Horario RegistrarHorario(Horario h);

        /// <summary>
        /// Genera viajes asociados a un horario basandose en la fecha de inicio y fin y los dias de la semana
        /// </summary>
        /// <param name="idHorario"></param>
        /// <param name="fInicio"></param>
        /// <param name="fFin"></param>
        /// <param name="dias"></param>
        /// <returns></returns>
        ICollection<Viaje> RegistrarViajes(int idHorario, DateTime fInicio, DateTime fFin, ICollection<DiaSemana> dias);
        ICollection<Horario> ListarHorarios();
        Horario ModificarHorario(Horario h);

        /// <summary>
        /// Lista todos los conductores registrados en el sistema
        /// </summary>
        /// <returns></returns>
        ICollection<Conductor> ListarConductores();

        /// <summary>
        /// Modifica la fecha de vencimiento de la libreta del conductor
        /// </summary>
        /// <returns></returns>
        Conductor ModificarConductor(Conductor c);

        /// <summary>
        /// Lista todos los viajes del sistema
        /// </summary>
        /// <returns></returns>
        ICollection<Viaje> ListarViajes();

        Linea ModificarLinea(Linea l);

        // Faltan un par de funciones para los reportes...


    }
}
