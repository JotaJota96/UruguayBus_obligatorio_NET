using BusinessLayer.Implementations;
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
    public class GlobalController : ApiController
    {
        IBL_Global blg = new BL_Global();


        [HttpGet]
        [Route("api/Global/Paradas")]
        public ICollection<Parada> listarParadas()
        {
            try
            {
                return blg.ListarParadas();
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al obtener las paradas"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al obtener las paradas"));
            }
        }

    }
}
