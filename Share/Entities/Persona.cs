using Share.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class Persona
    {
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Apellido")]
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }

        [DisplayName("Tipo de documento")]
        public TipoDocumento tipo_documento { get; set; }

        [DisplayName("Documento")]

        public string documento { get; set; }
        public Admin admin { get; set; }
        public Conductor conductor { get; set; }
        public SuperAdmin superadmin { get; set; }
        public Usuario usuario { get; set; }

    }
}
