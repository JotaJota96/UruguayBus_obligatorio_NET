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
                HttpResponseMessage response = await client.GetAsync(basicPath + "/Paradas");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ICollection<Parada>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}