﻿using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    [AllowAnonymous]
    public class GlobalController : ApiController
    {
        IBL_Global blg = new BL_Global();

        [HttpGet]
        [Route("api/")]
        public string test()
        {
            return "API funcionando";
        }

        [HttpGet]
        [Route("api/Global/Paradas")]
        public ICollection<Parada> listarParadas()
        {
            try
            {
                return blg.ListarParadas();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Global/ListarLinea")]
        public ICollection<Linea> ListarLinea()
        {
            try
            {
                return blg.ListarLinea();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Global/Lineas/{idLinea}/Paradas")]
        public ICollection<Parada> obtenerParadasDeLinea([FromUri] int idLinea)
        {
            try
            {
                return blg.obtenerParadasDeLinea(idLinea);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Global/ObtenerUsuario/{correo}")]
        public Usuario ObtenerUsuario([FromUri] string correo)
        {
            try
            {
                Usuario u = blg.ObtenerUsuario(correo);
                if (u != null && u.persona != null) u.persona.contrasenia = null;
                return u;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Global/ListarVehiculos")]
        public ICollection<Vehiculo> ListarVehiculos()
        {
            try
            {
                return blg.ListarVehiculos();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        [HttpGet]
        [Route("api/Global/ListarParadas")]
        public ICollection<Parada> ListarParadas()
        {
            try
            {
                return blg.ListarParadas();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Global/ListarUsuario")]
        public ICollection<Usuario> ListarUsuario()
        {
            try
            {
                ICollection<Usuario> ret = blg.ListarUsuario();

                foreach (var item in ret)
                {
                    if (item.persona != null) item.persona.contrasenia = null;
                }

                return ret;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
