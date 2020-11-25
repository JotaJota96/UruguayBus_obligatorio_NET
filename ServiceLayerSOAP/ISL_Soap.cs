using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceLayerSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISL_Soap
    {
        [OperationContract]
        string EchoTest(string mensaje);

        /// <summary>
        /// Devuelve informacion sobre los viajes disponibles en una fecha, que pasan por el origen y destino especificado
        /// Para cada viaje que cumpla la conducion se devuelve los ID de viaje, parada de origen y destino, la hora, el precio y la lista de asientos disponibles
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="idParadaOrigen"></param>
        /// <param name="idParadaDestino"></param>
        /// <returns></returns>
        [OperationContract]
        ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino);

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
        [OperationContract]
        Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null);

        /// <summary>
        /// Devuelve el costo minimo a partir del cual el uuario puede elegir asiento
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        decimal PrecioParaElegirAsiento();

        /// <summary>
        /// Lista todas las paradas del sistema
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ICollection<Parada> ListarParadas();
    }

}
