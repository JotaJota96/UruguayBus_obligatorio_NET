using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    class Conductor
    {
        public int id { get; set; }
        public DateTime vencimiento_libreta { get; set; }
        public Persona persona { get; set; }
        public ICollection<Horario> horarios { get; set; } = new List<Horario>();
    }
}
