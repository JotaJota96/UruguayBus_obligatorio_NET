using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Horario
    {
        public int id { get; set; }
        public TimeSpan hora { get; set; }
        public Conductor conductor { get; set; }
        public Linea linea { get; set; }
        public Vehiculo vehiculo { get; set; }
        public ICollection<Viaje> viajes { get; set; } = new List<Viaje>();
    }
}
