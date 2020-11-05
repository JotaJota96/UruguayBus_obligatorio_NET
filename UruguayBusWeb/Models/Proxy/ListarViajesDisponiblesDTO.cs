using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models.Proxy
{
    public class ListarViajesDisponiblesDTO
    {
        public DateTime fecha { get; set; }
        public int idParadaOrigen { get; set; }
        public int idParadaDestino { get; set; }
    }
}