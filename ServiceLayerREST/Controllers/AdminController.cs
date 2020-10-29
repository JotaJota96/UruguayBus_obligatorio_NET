using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class AdminController : ApiController
    {
        IBL_Admin bla = new BL_Admin();

        // GET: api/Admin/Paradas
        [HttpGet]
        [ActionName("Paradas")]
        public ICollection<Parada> listarParadas()
        {
            try
            {
                return bla.ListarParadas();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // POST: api/Admin/RegitrarVehiculo
        [HttpPost]
        [ActionName("RegitrarVehiculo")]
        public Vehiculo RegistrarVehiculo([FromBody]Vehiculo v)
        {
            try
            {
                return v;
            }
            catch (Exception)
            {
                throw;
            }
        }   

    }
}
