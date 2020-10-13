using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Precio
    {
        public int id { get; set; }
        public decimal valor { get; set; }
        public DateTime fecha_validez { get; set; }
        public Tramo tramo { get; set; }
    }
}
