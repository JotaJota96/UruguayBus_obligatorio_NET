using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class PasoPorParada
    {
        public Viaje viaje { get; set; }
        public Parada parada { get; set; }
        public DateTime fechaHora { get; set; }

    }
}
