using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Parada
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }
        public ICollection<Pasaje> pasajes_origen { get; set; } = new List<Pasaje>();
        public ICollection<Pasaje> pasajes_destino { get; set; } = new List<Pasaje>();
        public ICollection<Tramo> tramos { get; set; } = new List<Tramo>();
    }
}
