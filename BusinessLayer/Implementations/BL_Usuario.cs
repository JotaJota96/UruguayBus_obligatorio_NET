using BusinessLayer.Interfaces;
using DataAccesLayer.Implementations;
using DataAccesLayer.Interfaces;
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
        private IDAL_Usuario dal = new DAL_Usuario();
        private IDAL_Global dalg = new DAL_Global();

        public BL_Usuario()
        {
            //
        }

        public Usuario IniciarSesion(string correo, string contrasenia)
        {
            {
                try
                {
                    return dal.IniciarSesion(correo, contrasenia);
                }
                catch (Exception e)
                {
                    throw new Exception("No se pudo registrar el usuario. " + e.Message);
                }
            }
        }

        public ICollection<VehiculoCercanoDTO> ListarVehiculosCercanos(int idParada, int? idUsuario = null)
        {
            try
            {
                return dal.ListarVehiculosCercanos(idParada, idUsuario);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo listar los vehiculos disponibles. " + e.Message);
            }
        }

        public ICollection<ViajeDisponibleDTO> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino)
        {
            try
            {
                return dal.ListarViajesDisponibles(fecha,idParadaOrigen,idParadaDestino);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo listar los viajes disponiblies. " + e.Message);
            }
        }

        public decimal PrecioParaElegirAsiento()
        {
            try
            {
                return dal.PrecioParaElegirAsiento();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el dato. " + e.Message);
            }
        }

        public Usuario RegistrarUsuario(Usuario u)
        {
            try
            {
                return dal.RegistrarUsuario(u);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo registrar el usuario. " + e.Message);
            }
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, int idUsuario, int? asiento = null)
        {
            try
            {
                return dal.ReservarPasaje(idViaje, idParadaOrigen, idParadaDestino, idUsuario,asiento);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo reservar el pasaje. " + e.Message);
            }
        }

        public Pasaje ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, string documento, TipoDocumento tipoDocumento, int? asiento = null)
        {
            try
            {
                return dal.ReservarPasaje(idViaje, idParadaOrigen, idParadaDestino, documento, tipoDocumento, asiento);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo reservar el pasaje. " + e.Message);
            }
        }
    }
}
