using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class PersonaConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Persona convert(persona p)
        {
            Persona ret = new Persona()
            {
                id = p.id,
                correo = p.correo,
                documento = p.documento,
                //tipo_documento = p.tipo_documento,
                nombre = p.nombre,
                apellido = p.apellido,
                contrasenia = p.contrasenia,
            };
            return ret;
        }

        public static persona convert(Persona p)
        {
            persona ret = new persona()
            {
                id = p.id,
                correo = p.correo,
                documento = p.documento,
                //tipo_documento = p.tipo_documento,
                nombre = p.nombre,
                apellido = p.apellido,
                contrasenia = p.contrasenia,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Persona> convert(ICollection<persona> p)
        {
            List<Persona> ret = new List<Persona>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<persona> convert(ICollection<Persona> p)
        {
            List<persona> ret = new List<persona>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        
    }
}
