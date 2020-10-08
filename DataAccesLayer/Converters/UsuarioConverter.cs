using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class UsuarioConverter
    {

        /** Conversion de objetos simples *************************************/
        public static Usuario convert(usuario u)
        {
            Usuario ret = new Usuario()
            {
                id = u.id
            };
            return ret;
        }

        public static usuario convert(Usuario u)
        {
            usuario ret = new usuario()
            {
                id = u.id
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Usuario> convert(ICollection<usuario> u)
        {
            List<Usuario> ret = new List<Usuario>();
            foreach (var item in u)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<usuario> convert(ICollection<Usuario> u)
        {
            List<usuario> ret = new List<usuario>();
            foreach (var item in u)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarPasaje(Usuario u, ICollection<Pasaje> p)
        {
            foreach (var item in p)
            {
                item.usuario = u;
                u.pasaje.Add(item);
            }
        }
        public static void asociarPasaje(usuario u, ICollection<pasaje> p)
        {
            foreach (var item in p)
            {
                item.usuario = u;
                item.usuario_id = u.id;
                u.pasaje.Add(item);
            }
        }

    }
}
