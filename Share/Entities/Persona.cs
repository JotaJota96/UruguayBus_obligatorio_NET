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
        [DisplayName("Correo")]
        public string correo { get; set; }
        [DisplayName("Contraseña")]
        public string contrasenia { get; set; }

        [DisplayName("Tipo de documento")]
        public TipoDocumento tipo_documento { get; set; }

        [DisplayName("Documento")]

        public string documento { get; set; }
        public Admin admin { get; set; }
        public Conductor conductor { get; set; }
        public SuperAdmin superadmin { get; set; }
        public Usuario usuario { get; set; }

        // ----------------------------------

        /// <summary>
        /// Devuelve una lista con los roles del usuario. ¡OJO! solo funciona si los punteros estan establecidos, sino puede que devuelva cualquier cosa
        /// </summary>
        /// <returns>Lista de roles del usuario</returns>
        public List<Rol> GetRoles()
        {
            List<Rol> roles = new List<Rol>();
            roles.Add(Rol.USUARIO); // todos son usuarios, asi que no le pongo IF
            if (conductor != null) roles.Add(Rol.CONDUCTOR);
            if (admin != null) roles.Add(Rol.ADMIN);
            if (superadmin!= null) roles.Add(Rol.SUPERADMIN);
            return roles;
        }
    }
}
