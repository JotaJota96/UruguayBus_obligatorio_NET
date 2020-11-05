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
    public class SuperadminProxy
    {
        HttpClient client = new HttpClient();
        string basicPath = "/api/Superadmin/";
        public SuperadminProxy()
        {
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<ICollection<Vehiculo>> ListarVehiculos()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(basicPath + "/Vehiculos");
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

                HttpResponseMessage response = await client.PutAsync(basicPath + "/AsignarRol", ar);
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