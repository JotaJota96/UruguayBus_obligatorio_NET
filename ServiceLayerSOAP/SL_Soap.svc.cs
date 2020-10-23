using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SL_Soap : ISL_Soap
    {
        IBL_Usuario blu;

        public SL_Soap()
        {
            blu = new BL_Usuario();
        }

        public string EchoTest(string mensaje)
        {
            return "Ha enviado el mensaje: '" + mensaje + "'";
        }

        public ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino)
        {
            return blu.ListarViajesDisponibles(fecha, idParadaOrigen, idParadaDestino);
        }

        public decimal PrecioParaElegirAsiento()
        {
            return blu.PrecioParaElegirAsiento();
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null)
        {
            return blu.ReservarPasaje(idViaje, idParadaOrigen, idParadaDestino, documento, tipoDocumento, asiento);
        }
    }
}
