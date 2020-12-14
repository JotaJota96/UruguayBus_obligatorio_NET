using Share.DTOs;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using UruguayBusWeb.Models.Proxy;

namespace UruguayBusWeb.ApiClient
{
    public class UsuarioProxy
    {
        HttpClient client = new HttpClient();
        string basePath = "/api/Usuario/";
        string token = null;

        public UsuarioProxy(string tkn = null)
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

        public async Task<Usuario> RegistrarUsuario(Usuario u)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(basePath + "RegistrarUsuario", u);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Usuario>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Usuario> IniciarSesion(string correo, string contrasenia)
        {
            try
            {
                IniciarSesionDTO ins = new IniciarSesionDTO()
                {
                    correo = correo,
                    contrasenia = contrasenia
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(basePath + "IniciarSesion", ins);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Usuario>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<VehiculoCercanoDTO>> ListarVehiculosCercanos(int idParada, int? idUsuario = null)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basePath + "VehiculosCercanos/" + idParada + "/" + idUsuario);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<VehiculoCercanoDTO>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<decimal> PrecioParaElegirAsiento()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basePath + "PrecioAsiento");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<decimal>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> CorreoExiste(string correo)
        {
            try
            {
                if (String.IsNullOrEmpty(correo))
                    return false;

                correo = correo.Replace(".", "~");
                HttpResponseMessage response = await client.GetAsync(basePath + "CorreoExiste/" + correo);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<ViajeDisponibleDTO>> ListarViajesDisponibles(DateTime fecha, int idParadaOrigen, int idParadaDestino)
        {
            try
            {
                ListarViajesDisponiblesDTO Liv = new ListarViajesDisponiblesDTO()
                {
                    fecha = fecha,
                    idParadaOrigen = idParadaOrigen,
                    idParadaDestino = idParadaDestino
                };
                
                HttpResponseMessage response = await client.PostAsJsonAsync(basePath + "ViajesDisponibles", Liv);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<ViajeDisponibleDTO>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Pasaje> ReservarPasaje(ReservarPasajeDTO rv)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(basePath + "ReservarPasaje", rv);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Pasaje>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Pasaje> CancelarPasaje(int idPasaje)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync(basePath + "CancelarPasaje/" + idPasaje, null);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Pasaje>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}