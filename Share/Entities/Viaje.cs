﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Viaje
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public bool? finalizado { get; set; }
        public Horario horario { get; set; }
        public ICollection<Pasaje> pasajes { get; set; } = new List<Pasaje>();
    }
}
