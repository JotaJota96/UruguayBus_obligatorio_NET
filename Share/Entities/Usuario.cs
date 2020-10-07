using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    class Usuario
    {
        public int id { get; set; }
        public ICollection<Pasaje> pasaje { get; set; } = new List<Pasaje>();
        public Persona persona { get; set; }
    }
}
