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

        [HttpPut]
        [Route("api/Admin/ModificarParada")]
        public Parada ModificarParada([FromBody] Parada p)
        {
            try
            {
                return bla.ModificarParada(p);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Admin/ListarConductores")]
        public ICollection<Conductor> ListarConductores()
        {
            try
            {
                return bla.ListarConductores();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/Admin/ModificarConductor")]
        public Conductor ModificarConductor([FromBody] Conductor c)
        {
            try
            {
                return bla.ModificarConductor(c);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Admin/ListarHorarios")]
        public ICollection<Horario> ListarHorarios()
        {
            try
            {
                return bla.ListarHorarios();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/Admin/ModificarHorario")]
        public Horario ModificarHorario([FromBody] Horario h)
        {
            try
            {
                return bla.ModificarHorario(h);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Admin/ListarViajes")]
        public ICollection<Viaje> ListarViajes()
        {
            try
            {
                return bla.ListarViajes();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/Admin/ModificarLinea")]
        public Linea ModificarLinea([FromBody] Linea l)
        {
            try
            {
                return bla.ModificarLinea(l);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/Admin/ModificarTramo")]
        public Tramo ModificarTramo([FromBody] Precio p)
        {
            try
            {
                return bla.ModificarTramo(p);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
