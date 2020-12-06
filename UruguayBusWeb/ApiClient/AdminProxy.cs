﻿using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using UruguayBusWeb.Models.Proxy;

namespace UruguayBusWeb.ApiClient
{
    public class AdminProxy
    {

        HttpClient client = new HttpClient();
        string basicPath = "/api/Admin/";
        string token = null;

        public AdminProxy(string tkn = null)
        {
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            if (tkn != null) this.token = tkn;
            else
                try { this.token = HttpContext.Current == null ? null : (string)HttpContext.Current.Session["token"]; }
                catch { this.token = null; }

            if (!String.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<Vehiculo> RegistrarVehiculo(Vehiculo v)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(basicPath + "RegitrarVehiculo", v);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Vehiculo>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Vehiculo> ModificarVehiculo(Vehiculo v)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(basicPath + "ModificarVehiculo", v);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Vehiculo>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Horario> RegistrarHorario(Horario h)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(basicPath + "RegitrarHorario", h);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Horario>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Linea> RegistrarLinea(Linea l)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(basicPath + "RegitrarLinea", l);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Linea>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Parada> RegistrarParada(Parada p)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(basicPath + "RegitrarParada", p);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Parada>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<Viaje>> RegistrarViajes(int idHorario, DateTime fInicio, DateTime fFin, ICollection<DiaSemana> dias)
        {
            try
            {
                registrarViajeDTO rv = new registrarViajeDTO()
                {
                    idHorario = idHorario,
                    fInicio = fInicio,
                    fFin = fFin,
                    dias = dias
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(basicPath + "RegitrarViajes", rv);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Viaje>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Parada> ModificarParada(Parada p)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(basicPath + "ModificarParada", p);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Parada>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Conductor> ModificarConductor(Conductor c)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(basicPath + "ModificarConductor", c);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Conductor>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Horario> ModificarHorario(Horario h)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(basicPath + "ModificarHorario", h);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Horario>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<Conductor>> ListarConductores()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ListarConductores");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Conductor>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<Horario>> ListarHorarios()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ListarHorarios");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Horario>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<Viaje>> ListarViajes()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ListarViajes");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Viaje>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
        public async Task<Linea> ModificarLinea(Linea l)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(basicPath + "ModificarLinea", l);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Linea>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Tramo> ModificarTramo(Precio p)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(basicPath + "ModificarTramo", p);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Tramo>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}