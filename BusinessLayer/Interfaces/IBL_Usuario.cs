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
    public interface IBL_Usuario
    {
        /// <summary>
        /// Registra un nuevo usuario en el sistema
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        Usuario RegistrarUsuario(Usuario u);

        /// <summary>
        /// Valida los datos de inicio de sesion de un usuario
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="contrasenia"></param>
        /// <returns>Devuelve el usuario o null si los datos no son correctos</returns>
        Usuario IniciarSesion(string correo, string contrasenia);

        /// <summary>
        /// Devuelve informacion sobre los viajes disponibles en una fecha, que pasan por el origen y destino especificado
        /// Para cada viaje que cumpla la conducion se devuelve los ID de viaje, parada de origen y destino, la hora, el precio y la lista de asientos disponibles
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="idParadaOrigen"></param>
        /// <param name="idParadaDestino"></param>
        /// <returns></returns>
        ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino);

        /// <summary>
        /// Reserva de pasaje para usuario registrado
        /// </summary>
        /// <param name="idViaje">ID del viaje</param>
        /// <param name="idParadaOrigen">ID de la parada de origen</param>
        /// <param name="idParadaDestino">ID de la parada de destino</param>
        /// <param name="idUsuario">ID del usuario que realiza la reserva</param>
        /// <param name="asiento">(Opcional) Numero de asiento elegido</param>
        /// <returns>Pasaje creado</returns>
        Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, int idUsuario, int? asiento = null);

        /// <summary>
        /// Reserva de pasaje para usuario NO registrado
        /// </summary>
        /// <param name="idViaje">ID del viaje</param>
        /// <param name="idParadaOrigen">ID de la parada de origen</param>
        /// <param name="idParadaDestino">ID de la parada de destino</param>
        /// <param name="documento">Documento del que saca el pasaje</param>
        /// <param name="tipoDocumento">Tipo de documento ingresado</param>
        /// <param name="asiento">(Opcional) Numero de asiento elegido</param>
        /// <returns></returns>
        Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null);


        /// <summary>
        /// Cancela la reservacion de un pasaje
        /// </summary>
        /// <param name="idPasaje">ID del pasaje a cancelar</param>
        /// <returns></returns>
        Pasaje CancelarPasaje(int idPasaje);

        /// <summary>
        /// Devuelve el costo minimo a partir del cual el usuario puede elegir asiento
        /// </summary>
        /// <returns></returns>
        decimal PrecioParaElegirAsiento();

        /// <summary>
        /// Devuelve ID y la ubicacion de los vehiculos que tienen como proxima parada la parada especificada
        /// Si se indica un usuario, tambien se devuelve si el usuario tiene un pasaje reservado para dicho viaje
        /// </summary>
        /// <param name="idParada">ID de la parada</param>
        /// <param name="idUsuario">(Opcional) ID del usuario que consulta</param>
        /// <returns></returns>
        ICollection<VehiculoCercanoDTO> ListarVehiculosCercanos(int idParada, int? idUsuario = null);

        bool CorreoExiste(string correo);

    }
}
