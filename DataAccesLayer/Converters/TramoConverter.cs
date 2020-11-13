using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class TramoConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Tramo convert(tramo t)
        {
            if (t == null) return null;

            Tramo ret = new Tramo()
            {
                numero = t.numero,
                tiempo = t.tiempo,
            };
            return ret;
        }

        public static tramo convert(Tramo t)
        {
            if (t == null) return null;

            tramo ret = new tramo()
            {
                numero = t.numero,
                tiempo = t.tiempo,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Tramo> convert(ICollection<tramo> t)
        {
            if (t == null) return null;

            List<Tramo> ret = new List<Tramo>();
            foreach (var item in t)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<tramo> convert(ICollection<Tramo> t)
        {
            if (t == null) return null;

            List<tramo> ret = new List<tramo>();
            foreach (var item in t)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarPrecios(Tramo t, ICollection<Precio> p)
        {
            foreach (var item in p)
            {
                item.tramo = t;
                t.precio.Add(item);
            }
        }
        public static void asociarPrecios(tramo t, ICollection<precio> p)
        {
            foreach (var item in p)
            {
                item.tramo = t;
                item.linea_id = t.linea_id;
                item.parada_id = t.parada_id;
                t.precio.Add(item);
            }
        }
    }
}
