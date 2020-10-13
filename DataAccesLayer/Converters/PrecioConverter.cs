using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class PrecioConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Precio convert(precio p)
        {
            Precio ret = new Precio()
            {
                id = p.id,
                fecha_validez = p.fecha_validez,
                valor = p.valor,
            };
            return ret;
        }

        public static precio convert(Precio p)
        {
            precio ret = new precio()
            {
                id = p.id,
                fecha_validez = p.fecha_validez,
                valor = p.valor,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Precio> convert(ICollection<precio> p)
        {
            List<Precio> ret = new List<Precio>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<precio> convert(ICollection<Precio> p)
        {
            List<precio> ret = new List<precio>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        
    }
}
