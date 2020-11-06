using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace UruguayBusWeb.ApiClient
{
    public class GlobalProxy
    {
        HttpClient client = new HttpClient();
        string basicPath = "/api/Global/";
        public GlobalProxy()
        {
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<ICollection<Parada>> ListarParadasAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "Paradas");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Parada>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ICollection<Vehiculo>> ListarVehiculos()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "/ListarVehiculos");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Vehiculo>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ICollection<Parada>> ListarParadas()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "/ListarParadas");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Parada>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Usuario> ObtenerUsuario(string correo)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "/ObtenerUsuario" + correo);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Usuario>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Parada> obtenerParada(int idParada)
        {
            try
            {
                Parada ret = null;
                ICollection<Parada> lst = await ListarParadas();

                foreach (var item in lst)
                {
                    if (item.id == idParada)
                    {
                        ret = item;
                    }
                }

                return ret;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<Conductor> obtenerConductor(int idConductor)
        {
            try
            {
                AdminProxy ap = new AdminProxy();
                Conductor ret = null;
                ICollection<Conductor> lst = await ap.ListarConductores();

                foreach (var item in lst)
                {
                    if (item.id == idConductor)
                    {
                        ret = item;
                    }
                }

                return ret;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<Viaje> obtenerViaje(int idViaje)
        {
            try
            {
                AdminProxy ap = new AdminProxy();
                Viaje ret = null;
                ICollection<Viaje> lst = await ap.ListarViajes();

                foreach (var item in lst)
                {
                    if (item.id == idViaje)
                    {
                        ret = item;
                    }
                }

                return ret;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<Horario> obtenerHorario(int idHorario)
        {
            try
            {
                AdminProxy ap = new AdminProxy();
                Horario ret = null;
                ICollection<Horario> lst = await ap.ListarHorarios();

                foreach (var item in lst)
                {
                    if (item.id == idHorario)
                    {
                        ret = item;
                    }
                }

                return ret;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<Vehiculo> obtenerVehiculo(int idVehiculo)
        {
            try
            {
                Vehiculo ret = null;
                ICollection<Vehiculo> lst = await ListarVehiculos();

                foreach (var item in lst)
                {
                    if (item.id == idVehiculo)
                    {
                        ret = item;
                    }
                }

                return ret;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //linea
    }
}