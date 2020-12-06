using Share.Entities;
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
    public class GlobalProxy
    {
        HttpClient client = new HttpClient();
        string basicPath = "/api/Global/";
        string token = null;

        public GlobalProxy(string tkn = null)
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
                HttpResponseMessage response = await client.GetAsync(basicPath + "ListarVehiculos");
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
                HttpResponseMessage response = await client.GetAsync(basicPath + "ListarParadas");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Parada>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ICollection<Linea>> ListarLinea()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ListarLinea");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Linea>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ICollection<Usuario>> ListarUsuario()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "ListarUsuario");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Usuario>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ICollection<Parada>> obtenerParadasDeLinea(int idLinea)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "Lineas/" + idLinea + "/Paradas");
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
                HttpResponseMessage response = await client.GetAsync(basicPath + "ObtenerUsuario/" + correo);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Usuario>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Usuario> ObtenerUsuario(int id)
        {
            try
            {
                Usuario ret = null;
                ICollection<Usuario> lst = await ListarUsuario();

                foreach (var item in lst)
                {
                    if (item.id == id)
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
                AdminProxy ap = new AdminProxy(this.token);
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
                AdminProxy ap = new AdminProxy(this.token);
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
                AdminProxy ap = new AdminProxy(this.token);
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
        public async Task<Linea> obtenerLinea(int idVehiculo)
        {
            try
            {
                Linea ret = null;
                ICollection<Linea> lst = await ListarLinea();

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
    }
}