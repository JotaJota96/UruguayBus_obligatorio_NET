using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Vehiculo
    {
        public int id { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int cant_asientos { get; set; }
        public decimal? latitud { get; set; }
        public decimal? longitud { get; set; }
        public ICollection<Horario> horario { get; set; } = new List<Horario>();

    }
}
