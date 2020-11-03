using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayerREST.Models
{
    public class registrarViajeDTO
    {
        public int idHorario { get; set; }
        public DateTime fInicio { get; set; }
        public DateTime fFin { get; set; }
        public ICollection<DiaSemana> dias { get; set; } = new List<DiaSemana>();

    }
}