﻿using BusinessLayer.Implementations;
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


        [HttpGet]
        [Route("api/Admin/Paradas")]
        public ICollection<Parada> listarParadas()
        {
            try
            {
                return bla.ListarParadas();
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ha ocurrido un error al obtener las paradas"));
            }
        }

        [HttpPost]
        [Route("api/Admin/RegitrarVehiculo")]
        public Vehiculo RegistrarVehiculo([FromBody]Vehiculo v)
        {
            try
            {
                return bla.RegistrarVehiculo(v);
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ha ocurrido un error al registrar un vheiculo"));

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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ha ocurrido un error al modificar un vheiculo"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ha ocurrido un error al registrar un horario"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ha ocurrido un error al registrar una linea"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ha ocurrido un error al registrar una parada"));
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
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ha ocurrio un error al registrar los viajes"));
            }
        }

    }
}
