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
    public class SuperadminProxy
    {
        HttpClient client = new HttpClient();
        string basicPath = "/api/Superadmin/";
        string token = null;

        public SuperadminProxy(string tkn = null)
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

        public async Task<ICollection<Vehiculo>> ListarVehiculos()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "Vehiculos");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Vehiculo>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ICollection<Vehiculo>> AsignarRol(int idUsuario, Rol rol, DateTime? fechaVencLibreta = null)
        {
            try
            {
                AsignarRolDTO ar = new AsignarRolDTO()
                {
                    idUsuario = idUsuario,
                    rol = rol,
                    fechaVencLibreta = fechaVencLibreta
                };

                HttpResponseMessage response = await client.PutAsJsonAsync(basicPath + "AsignarRol", ar);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Vehiculo>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}