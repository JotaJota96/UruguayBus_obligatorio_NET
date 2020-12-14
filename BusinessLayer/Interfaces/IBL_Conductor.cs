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
    public interface IBL_Conductor
    {
        /// <summary>
        /// Devuelve una lista con los viajes que el conductor debera hacer durante el dia
        /// Sirve para e caso de uso de 'Comenzar viaje'
        /// </summary>
        /// <returns></returns>
        ICollection<Viaje> ListarViajesDelDia(int idConductor);

        /// <summary>
        /// Marca el viaje como iniciado
        /// </summary>
        /// <param name="idViaje"></param>
        void IniciarViaje(int idViaje);

        /// <summary>
        /// Marca el viaje como finalizado
        /// </summary>
        /// <param name="idViaje"></param>
        void FinalizarViaje(int idViaje);

        /// <summary>
        /// Valida un pasaje verificando que no haya sido usado antes, que se está usando en el viaje y la parada correctos
        /// </summary>
        /// <param name="idPasaje">ID del pasaje a validar</param>
        /// <param name="idViaje">ID del viaje en el que se presenta el pasaje</param>
        /// <param name="idParada">ID de la parada en la que se presenta el pasaje</param>
        /// <returns></returns>
        bool ValidarPasaje(int idPasaje, int idViaje, int idParada);

        /// <summary>
        /// Devuelve la lista de usuarios que tienen pasajes reservado para el viaje especificado y que subiran en la siguiente parada
        /// Con la lista devuelta se podra notificar a los usuarios que su vehiculo se acerca
        /// </summary>
        /// <param name="idParada">ID de la parada por la que acaba de pasar el vehiculo</param>
        /// <param name="idViaje">ID del viaje que está realizando el vehiculo</param>
        /// <returns></returns>
        ICollection<Usuario> RegistrarPasoPorParada(int idParada, int idViaje);

        Viaje ObtenerViajeActual(int idConductor);
    }
}
