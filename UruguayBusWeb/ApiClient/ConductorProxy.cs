﻿using Share.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace UruguayBusWeb.ApiClient
{
    public class ConductorProxy
    {
        HttpClient client = new HttpClient();
        string basicPath = "/api/Conductor/";
        string token = null;

        public ConductorProxy(string tkn = null)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UruguayBusApiBaseAddress"]);
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

        public async Task FinalizarViaje(int idViaje)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync(basicPath + "Finalizar/" + idViaje, null);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task IniciarViaje(int idViaje)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync(basicPath + "Iniciar/" + idViaje, null);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Viaje> ObtenerViajeActual(int idConductor)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ObtenerViajeActual/" + idConductor);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Viaje>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<Viaje>> ListarViajesDelDia(int idConductor)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ViajesDelDia/" + idConductor);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Viaje>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ValidarPasaje(int idPasaje, int idViaje, int idParada)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ValidarPasaje/" + idPasaje + "/" + idViaje + "/" + idParada);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task RegistrarPasoPorParada(int idParada, int idViaje)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(basicPath + "RegistrarParada/" + idParada + "/" + idViaje, null);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}