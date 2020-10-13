using BusinessLayer.Interfaces;
using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class BL_Usuario : IBL_Usuario
    {
        public BL_Usuario()
        {
            //
        }

        public Usuario IniciarSesion(string correo, string contrasenia)
        {
            throw new NotImplementedException();
        }

        public ICollection<VehiculoCercanoDTO> ListarVehiculosCercanos(int idParada, int? idUsuario = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino)
        {
            throw new NotImplementedException();
        }

        public decimal PrecioParaElegirAsiento()
        {
            throw new NotImplementedException();
        }

        public Usuario RegistrarUsuario(Usuario u)
        {
            throw new NotImplementedException();
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, int idUsuario, int? asiento = null)
        {
            throw new NotImplementedException();
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null)
        {
            throw new NotImplementedException();
        }
    }
}
