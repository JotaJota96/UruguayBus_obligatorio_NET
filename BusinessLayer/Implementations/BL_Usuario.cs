using BusinessLayer.Interfaces;
using DataAccesLayer.Implementations;
using DataAccesLayer.Interfaces;
using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            try
            {
                if (correo == null || correo.Equals("") || contrasenia == null || contrasenia.Equals("")) 
                    return null;

                return dal.IniciarSesion(correo, contrasenia);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo registrar el usuario. " + e.Message);
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
                if (fecha == null) 
                    throw new Exception("La fecha no puede ser NULL");
                
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
                if (u == null) 
                    throw new Exception("El usuario no puede ser NULL");
                if (u.persona == null)
                    throw new Exception("La persona no puede ser NULL");
                if (u.persona.nombre == null || u.persona.nombre.Equals("") 
                    || u.persona.apellido == null || u.persona.apellido.Equals("") 
                    || u.persona.correo == null || u.persona.correo.Equals("") 
                    || u.persona.contrasenia == null || u.persona.contrasenia.Equals("")
                    || u.persona.documento == null || u.persona.documento.Equals("")
                    )                    
                    throw new Exception("Los datos 'nombre', 'apellido', 'documento', 'correo', 'contraseña' no pueden ser NULL o vacios");

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
                if (idParadaOrigen == idParadaDestino)
                    throw new Exception("Las paradas de origen y destino no pueden ser la misma");

                if (asiento <= 0)
                    asiento = null;

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
                if (idParadaOrigen == idParadaDestino)
                    throw new Exception("Las paradas de origen y destino no pueden ser la misma");

                if (documento == null || documento.Equals(""))
                    throw new Exception("El documento no puede ser NULL ni vacio");

                if (asiento <= 0)
                    asiento = null;

                return dal.ReservarPasaje(idViaje, idParadaOrigen, idParadaDestino, documento, tipoDocumento, asiento);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo reservar el pasaje. " + e.Message);
            }
        }
        public bool CorreoExiste(string correo)
        {
            try
            {
                return dal.CorreoExiste(correo);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo saber si el correo existe. " + e.Message);
            }
        }
    }
}
