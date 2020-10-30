using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using ServiceLayerREST.Models;
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
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener las paradas");
            }
        }

        // POST: api/Admin/RegitrarVehiculo
        [HttpPost]
        [ActionName("RegitrarVehiculo")]
        public Vehiculo RegistrarVehiculo([FromBody]Vehiculo v)
        {
            try
            {
                return bla.RegistrarVehiculo(v);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al registrar un vheiculo");
            }
        }

        // PUT: api/Admin/ModificarVehiculo
        [HttpPut]
        [ActionName("ModificarVehiculo")]
        public Vehiculo ModificarVehiculo([FromBody] Vehiculo v)
        {
            try
            {
                return bla.ModificarVehiculo(v);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al modificar un vheiculo");
            }
        }

        // POST: api/Admin/RegitrarHorario
        [HttpPost]
        [ActionName("RegitrarHorario")]
        public Horario RegistrarHorario([FromBody] Horario h)
        {
            try
            {
                return bla.RegistrarHorario(h);
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error al registrar un horario");
            }
        }

        // POST: api/Admin/RegitrarLinea
        [HttpPost]
        [ActionName("RegitrarLinea")]
        public Linea RegistrarLinea([FromBody] Linea l)
        {
            try
            {
                return bla.RegistrarLinea(l);
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error al registrar una linea");
            }
        }

        // POST: api/Admin/RegitrarParada
        [HttpPost]
        [ActionName("RegitrarParada")]
        public Parada RegistrarParada([FromBody] Parada p)
        {
            try
            {
                return bla.RegistrarParada(p);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al registrar una parada");
            }
        }

        // POST: api/Admin/RegitrarViajes
        [HttpPost]
        [ActionName("RegitrarViajes")]
        public ICollection<Viaje> RegistrarViajes([FromBody] registrarViajeDTO rv)
        {
            try
            {
                return bla.RegistrarViajes(rv.idHorario, rv.fInicio, rv.fFin, rv.dias);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrio un error al registrar los viajes. ");
            }
        }

    }
}
