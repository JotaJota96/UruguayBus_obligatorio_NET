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

        public GlobalProxy()
        {
            client.BaseAddress = new Uri("https://localhost:44349/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<ICollection<Parada>> ListarParadasAsync()
        {
            ICollection<Parada> ret = new List<Parada>();
            HttpResponseMessage response = await client.GetAsync("api/Global/Paradas");
            if (response.IsSuccessStatusCode)
            {
                ret = await response.Content.ReadAsAsync<ICollection<Parada>>();
            }
            return ret;
        }

    }
}