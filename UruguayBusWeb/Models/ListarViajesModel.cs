using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class ListarViajesModel
    {
        [DisplayName("Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha { get; set; }

        [DisplayName("Hora")]
        [DisplayFormat(DataFormatString = "{0:mm\\:hh}", ApplyFormatInEditMode = true)]
        public TimeSpan hora { get; set; }

        [DisplayName("Linea")]
        public string nombre_linea { get; set; }

        [DisplayName("Estado")]
        public string estado { get; set; }
    }
}