using Share.Entities;
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
        public AdminProxy()
        {
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
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

        public async Task<Viaje> RegistrarViajes(int idHorario, DateTime fInicio, DateTime fFin, ICollection<DiaSemana> dias)
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

                return await response.Content.ReadAsAsync<Viaje>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}