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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al finalizar el viaje"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al iniciar el viaje"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al listar los viaje del conductor"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al Registrar el Paso Por Parada"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al validar el pasaje"));
            }
        }
    }
}
