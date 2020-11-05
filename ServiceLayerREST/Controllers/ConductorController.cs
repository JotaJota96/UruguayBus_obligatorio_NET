using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class ConductorController : ApiController
    {
        IBL_Conductor blc = new BL_Conductor();


        [HttpPut]
        [Route("api/Conductor/Finalizar/{idViaje}")]
        public void FinalizarViaje([FromUri] int idViaje)
        {
            try
            {
                blc.FinalizarViaje(idViaje);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        [HttpPut]
        [Route("api/Conductor/Iniciar/{idViaje}")]
        public void IniciarViaje([FromUri] int idViaje)
        {
            try
            {
                blc.IniciarViaje(idViaje);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        [HttpGet]
        [Route("api/Conductor/ViajesDelDia/{idConductor}")]
        public ICollection<Viaje> ListarViajesDelDia([FromUri] int idConductor)
        {
            try
            {
                return blc.ListarViajesDelDia(idConductor);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        [HttpPost]
        [Route("api/Conductor/RegistrarParada/{idParada}/{idViaje}")]
        public void RegistrarPasoPorParada([FromUri] int idParada, [FromUri] int idViaje)
        {
            try
            {
                blc.RegistrarPasoPorParada(idParada, idViaje);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        [HttpGet]
        [Route("api/Conductor/ValidarPasaje/{idPasaje}/{idViaje}/{idParada}")]
        public bool ValidarPasaje([FromUri] int idPasaje, [FromUri] int idViaje, [FromUri] int idParada)
        {
            try
            {
                return blc.ValidarPasaje(idPasaje, idViaje, idParada);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/Conductor/ObtenerViajeActual/{idConductor}")]
        public Viaje ObtenerViajeActual([FromUri] int idConductor)
        {
            try
            {
                return blc.ObtenerViajeActual(idConductor);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
