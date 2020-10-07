using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public TipoDocumento tipo_documento { get; set; }
        public string documento { get; set; }

        public Admin admin { get; set; }
        public Conductor conductor { get; set; }
        public SuperAdmin superadmin { get; set; }
        public Usuario usuario { get; set; }

    }
}
