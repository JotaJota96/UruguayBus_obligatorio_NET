using Share.DTOs;
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
    public class UsuarioProxy
    {
        HttpClient client = new HttpClient();
        string basePath = "/api/Usuario/";
        public UsuarioProxy()
        {
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
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

        public async Task<Pasaje> ReservarPasaje(int idViaje, int idParadaOrigen, int idParadaDestino, int idUsuario, int? asiento = null)
        {
            try
            {
                ReservarPasajeDTO rv = new ReservarPasajeDTO()
                {
                    idViaje = idViaje,
                    idParadaOrigen = idParadaOrigen,
                    idParadaDestino = idParadaDestino,
                    idUsuario = idUsuario,
                    asiento = asiento,
                    documento = null,
                    tipoDocumento = null,
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(basePath + "ReservarPasaje", rv);
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