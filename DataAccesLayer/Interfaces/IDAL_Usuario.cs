using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Usuario
    {

        Usuario IniciarSesion(string correo, string contrasenia);
        Usuario RegistrarUsuario(Usuario u);

        List<VehiculoCercanoDTO> ListarVehiculosCercanos(int idParada, int? idUsuario = null);
        ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino);

        decimal PrecioParaElegirAsiento();

        Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, int idUsuario, int? asiento = null);

        Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null);
    }
}
