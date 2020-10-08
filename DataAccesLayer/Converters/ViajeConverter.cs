using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class ViajeConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Viaje convert(viaje v)
        {
            Viaje ret = new Viaje()
            {
                id = v.id,
                fecha = v.fecha,
                finalizado = v.finalizado,
            };
            return ret;
        }

        public static viaje convert(Viaje v)
        {
            viaje ret = new viaje()
            {
                id = v.id,
                fecha = v.fecha,
                finalizado = v.finalizado,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Viaje> convert(ICollection<viaje> v)
        {
            List<Viaje> ret = new List<Viaje>();
            foreach (var item in v)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<viaje> convert(ICollection<Viaje> v)
        {
            List<viaje> ret = new List<viaje>();
            foreach (var item in v)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarPasajes(Viaje v, ICollection<Pasaje> p)
        {
            foreach (var item in p)
            {
                item.viaje = v;
                v.pasajes.Add(item);
            }
        }
        public static void asociarPasajes(viaje v, ICollection<pasaje> p)
        {
            foreach (var item in p)
            {
                item.viaje = v;
                item.viaje_id = v.id;
                v.pasaje.Add(item);
            }
        }
    }
}
