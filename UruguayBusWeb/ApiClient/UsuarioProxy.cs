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
    public class UsuarioProxy
    {
        HttpClient client = new HttpClient();

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
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/Usuario/RegistrarUsuario", u);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Usuario>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}