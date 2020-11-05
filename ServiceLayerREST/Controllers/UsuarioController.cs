using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccesLayer.Interfaces;
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

        [HttpPost]
        [Route("api/Usuario/RegistrarUsuario")]
        public Usuario RegistrarUsuario([FromBody] Usuario u)
        {
            try
            {
                return blu.RegistrarUsuario(u);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/Usuario/IniciarSesion")]
        public Usuario IniciarSesion([FromBody] IniciarSesionDTO dto)
        {
            try
            {
                return blu.IniciarSesion(dto.correo, dto.contrasenia);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Usuario/VehiculosCercanos/{idParada}/{idUsuario?}")]
        public ICollection<VehiculoCercanoDTO> ListarVehiculosCercanos([FromUri] int idParada, [FromUri] int? idUsuario = null)
        {
            try
            {
                return blu.ListarVehiculosCercanos(idParada, idUsuario);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Usuario/PrecioAsiento")]
        public decimal PrecioParaElegirAsiento()
        {
            try
            {
                return blu.PrecioParaElegirAsiento();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/Usuario/ViajesDisponibles")]
        public ICollection<ViajeDisponibleDTO> ListarViajesDisponibles([FromBody] ListarViajesDisponiblesDTO dto)
        {
            try
            {
                return blu.ListarViajesDisponibles(dto.fecha, dto.idParadaOrigen, dto.idParadaDestino);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/Usuario/ReservarPasaje")]
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
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Usuario/CorreoExiste/{correo}")]
        public bool CorreoExiste([FromUri] string correo)
        {
            try
            {
                return blu.CorreoExiste(correo);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
