using Share.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UruguayBusWeb.Models
{
    public class PasoParadaModel
    {
        public int idViaje{ get; set; }
        public int idUltimaParada { get; set; }
    }
}