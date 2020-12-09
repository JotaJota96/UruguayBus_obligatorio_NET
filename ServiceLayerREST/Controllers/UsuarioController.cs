using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccesLayer.Interfaces;
using ServiceLayerREST.Auth;
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
    [Authorize(Roles = "usuario")]
    public class UsuarioController : ApiController
    {
        IBL_Usuario blu = new BL_Usuario();

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/RegistrarUsuario")]
        public Usuario RegistrarUsuario([FromBody] Usuario u)
        {
            try
            {
                u = blu.RegistrarUsuario(u);

                if (u == null) return null;
                u.persona.contrasenia = null;

                var token = TokenGenerator.GenerateTokenJwt(u);
                u.persona.contrasenia = token;

                return u;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/IniciarSesion")]
        public Usuario IniciarSesion([FromBody] IniciarSesionDTO dto)
        {
            try
            {
                Usuario u = blu.IniciarSesion(dto.correo, dto.contrasenia);

                if (u == null) return null;
                u.persona.contrasenia = null;

                var token = TokenGenerator.GenerateTokenJwt(u);
                u.persona.contrasenia = token;

                return u;
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
                // si idUsuario es distino de null, entonces se trata de un usuario registrado
                if (dto.idUsuario != null)
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

        [HttpPut]
        [Route("api/Usuario/CancelarPasaje/{idPasaje}")]
        public Pasaje CancelarPasaje([FromUri] int idPasaje)
        {
            try
            {
                return blu.CancelarPasaje(idPasaje);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Usuario/CorreoExiste/{correo}")]
        public bool CorreoExiste([FromUri] string correo)
        {
            try
            {
                correo = correo.Replace("~", ".");
                return blu.CorreoExiste(correo);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
