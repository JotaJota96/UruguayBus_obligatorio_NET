using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Tramo
    {
        // no tiene ID
        [DisplayName("Orden")]
        public int numero { get; set; }
        [DisplayName("Tiempo")]
        public TimeSpan tiempo { get; set; }
        public Linea linea { get; set; }
        public Parada parada { get; set; }
        public ICollection<Precio> precio { get; set; } = new List<Precio>();
    }
}
