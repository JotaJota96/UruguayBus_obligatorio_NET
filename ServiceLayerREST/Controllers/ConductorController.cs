using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class ConductorController : ApiController
    {
        IBL_Conductor blc = new BL_Conductor();

        // PUT: api/Conductor/Finalizar
        [HttpPut]
        [ActionName("Finalizar")]
        public void FinalizarViaje(int idViaje)
        {
            try
            {
                blc.FinalizarViaje(idViaje);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al finalizar el viaje");
            }
        }

        // PUT: api/Conductor/Iniciar
        [HttpPut]
        [ActionName("Iniciar")]
        public void IniciarViaje(int idViaje)
        {
            try
            {
                blc.IniciarViaje(idViaje);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al iniciar el viaje");
            }
        }

        // GET: api/Conductor/ViajesDelDia
        [HttpGet]
        [ActionName("ViajesDelDia")]
        public void ListarViajesDelDia(int idConductor)
        {
            try
            {
                blc.ListarViajesDelDia(idConductor);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al listar los viaje del conductor");
            }
        }

        // POST: api/Conductor/RegistrarPasoPorParada
        [HttpPost]
        [ActionName("RegistrarPasoPorParada")]
        public void RegistrarPasoPorParada(int idParada, int idViaje)
        {
            try
            {
                blc.RegistrarPasoPorParada(idParada, idViaje);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al Registrar el Paso Por Parada");
            }
        }

        // get: api/Conductor/ValidarPasaje
        [HttpGet]
        [ActionName("ValidarPasaje")]
        public bool ValidarPasaje(int idPasaje, int idViaje, int idParada)
        {
            try
            {
                return blc.ValidarPasaje(idPasaje, idViaje, idParada);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al validaar el pasaje");
            }
        }
    }
}
