using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class ModificarLineaModel
    {
        [DisplayName("Nombre")]
        [Required]
        public string nombre { get; set; }
    }
}