using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using ServiceLayerREST.Models;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class AdminController : ApiController
    {
        IBL_Admin bla = new BL_Admin();


        [HttpPost]
        [Route("api/Admin/RegitrarVehiculo")]
        public Vehiculo RegistrarVehiculo([FromBody]Vehiculo v)
        {
            try
            {
                return bla.RegistrarVehiculo(v);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/Admin/ModificarVehiculo")]
        public Vehiculo ModificarVehiculo([FromBody] Vehiculo v)
        {
            try
            {
                return bla.ModificarVehiculo(v);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/Admin/RegitrarHorario")]
        public Horario RegistrarHorario([FromBody] Horario h)
        {
            try
            {
                return bla.RegistrarHorario(h);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/Admin/RegitrarLinea")]
        public Linea RegistrarLinea([FromBody] Linea l)
        {
            try
            {
                return bla.RegistrarLinea(l);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/Admin/RegitrarParada")]
        public Parada RegistrarParada([FromBody] Parada p)
        {
            try
            {
                return bla.RegistrarParada(p);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/Admin/RegitrarViajes")]
        public ICollection<Viaje> RegistrarViajes([FromBody] registrarViajeDTO rv)
        {
            try
            {
                return bla.RegistrarViajes(rv.idHorario, rv.fInicio, rv.fFin, rv.dias);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

    }
}
