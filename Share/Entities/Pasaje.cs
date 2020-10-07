using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    class Pasaje
    {
        public int id { get; set; }
        public Nullable <int> asiento { get; set; }
        public bool usado { get; set; }
        public TipoDocumento tipo_documento { get; set; }
        public string documento { get; set; }

        public Parada paradaOrigen { get; set; }
        public Parada paradaDestino { get; set; }
        public Usuario usuario { get; set; }
        public Viaje viaje { get; set; }
    }
}
