using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayerREST.Models
{
    public class ReservarPasajeDTO
    {
        public int idViaje { get; set; }
        public int idParadaOrigen { get; set; }
        public int idParadaDestino { get; set; }
        public int? idUsuario { get; set; } = null;
        public string documento { get; set; } = null;
        public TipoDocumento? tipoDocumento { get; set; } = null;
        public int? asiento { get; set; } = null;
    }
}