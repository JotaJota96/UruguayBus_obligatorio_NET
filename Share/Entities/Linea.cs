using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Linea
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public ICollection<Horario> horarios { get; set; } = new List<Horario>();
        public ICollection<Tramo> tramos { get; set; } = new List<Tramo>();
    }
}
