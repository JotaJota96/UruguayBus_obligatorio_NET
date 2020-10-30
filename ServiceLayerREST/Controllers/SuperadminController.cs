using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using ServiceLayerREST.Models;
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

        // GET: api/Superadmin/Vehiculos
        [HttpGet]
        [ActionName("Vehiculos")]
        public void ListarVehiculos()
        {
            try
            {
                blsa.ListarVehiculos();
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener los vehiculos");
            }
        }

        // PUT: api/Superadmin/AsignarRol
        [HttpPut]
        [ActionName("AsignarRol")]
        public void AsignarRol([FromBody] AsignarRolDTO dto)
        {
            try
            {
                blsa.AsignarRol(dto.idUsuario, dto.rol, dto.fechaVencLibreta);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al asignar el rol");
            }
        }
    }
}
