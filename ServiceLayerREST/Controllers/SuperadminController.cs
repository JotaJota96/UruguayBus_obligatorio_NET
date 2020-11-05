using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using ServiceLayerREST.Models;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class SuperadminController : ApiController
    {
        IBL_Superadmin blsa = new BL_Superadmin();

        [HttpGet]
        [Route("api/Superadmin/Vehiculos")]
        public ICollection<Vehiculo> ListarVehiculos()
        {
            try
            {
               return blsa.ListarVehiculos();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/Superadmin/AsignarRol")]
        public void AsignarRol([FromBody] AsignarRolDTO dto)
        {
            try
            {
                blsa.AsignarRol(dto.idUsuario, dto.rol, dto.fechaVencLibreta);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
