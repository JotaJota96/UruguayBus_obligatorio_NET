using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Vehiculo
    {
        public int id { get; set; }

        [DisplayName("Matricula")]
        public string matricula { get; set; }

        [DisplayName("Marca")]
        public string marca { get; set; }
        
        [DisplayName("Modelo")]
        public string modelo { get; set; }
        public int cant_asientos { get; set; }
        public decimal? latitud { get; set; }
        public decimal? longitud { get; set; }
        public ICollection<Horario> horario { get; set; } = new List<Horario>();

    }
}
