using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using ServiceLayerREST.Models;
using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class UsuarioController : ApiController
    {
        IBL_Usuario blu = new BL_Usuario();

        // POST: api/Usuario/RegistrarUsuario
        [HttpPost]
        [ActionName("RegistrarUsuario")]
        public Usuario RegistrarUsuario([FromBody] Usuario u)
        {
            try
            {
                return blu.RegistrarUsuario(u);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al registrar el usuario");
            }
        }

        // POST: api/Usuario/IniciarSesion
        [HttpPost]
        [ActionName("IniciarSesion")]
        public Usuario IniciarSesion([FromBody] IniciarSesionDTO dto)
        {
            try
            {
                return blu.IniciarSesion(dto.correo, dto.contrasenia);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al intentar iniciar sesion");
            }
        }

        // GET: api/Usuario/VehiculosCercanos
        [HttpPost]
        [ActionName("VehiculosCercanos")]
        public ICollection<VehiculoCercanoDTO> ListarVehiculosCercanos(int idParada, int? idUsuario = null)
        {
            try
            {
                return blu.ListarVehiculosCercanos(idParada, idUsuario);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener los vheiculos cercanos");
            }
        }

        // GET: api/Usuario/PrecioAsiento
        [HttpGet]
        [ActionName("PrecioAsiento")]
        public decimal PrecioParaElegirAsiento()
        {
            try
            {
                return blu.PrecioParaElegirAsiento();
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener el precio minimo para los asientos");
            }
        }

        // GET: api/Usuario/ViajesDisponibles
        [HttpGet]
        [ActionName("ViajesDisponibles")]
        public ICollection<ViajeDisponibleDTO> ListarViajesDisponibles([FromBody] ListarViajesDisponiblesDTO dto)
        {
            try
            {
                return blu.ListarViajesDisponibles(dto.fecha, dto.idParadaOrigen, dto.idParadaDestino);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener los viajes disponibles");
            }
        }

        // GET: api/Usuario/ReservarPasaje
        [HttpPost]
        [ActionName("ReservarPasaje")]
        public Pasaje ReservarPasaje([FromBody] ReservarPasajeDTO dto)
        {
            try
            {
                if (dto.documento == null && dto.tipoDocumento == null && dto.idUsuario != null)
                {
                    return blu.ReservarPasaje(dto.idViaje, dto.idParadaOrigen, dto.idParadaDestino, (int)dto.idUsuario, dto.asiento);
                }
                else
                {
                    return blu.ReservarPasaje(dto.idViaje, dto.idParadaOrigen, dto.idParadaDestino, dto.documento, (TipoDocumento)dto.tipoDocumento, dto.asiento); 
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener el precio minimo para los asientos");
            }
        }
    }
}
