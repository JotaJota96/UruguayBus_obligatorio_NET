using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayerREST.Models
{
    public class AsignarRolDTO
    {
        public int idUsuario { get; set; }
        public Rol rol { get; set; }
        public DateTime? fechaVencLibreta { get; set; } = null;

    }
}