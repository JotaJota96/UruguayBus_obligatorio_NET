using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    public class HorarioConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Horario convert(horario h)
        {
            Horario ret = new Horario()
            {
                id = h.id,
                hora = h.hora,
            };
            return ret;
        }

        public static horario convert(Horario h)
        {
            horario ret = new horario()
            {
                id = h.id,
                hora = h.hora,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Horario> convert(ICollection<horario> h)
        {
            List<Horario> ret = new List<Horario>();
            foreach (var item in h)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<horario> convert(ICollection<Horario> h)
        {
            List<horario> ret = new List<horario>();
            foreach (var item in h)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarViajes(Horario h, ICollection<Viaje> v)
        {
            foreach (var item in v)
            {
                item.horario = h;
                h.viajes.Add(item);
            }
        }
        public static void asociarViajes(horario h, ICollection<viaje> v)
        {
            foreach (var item in v)
            {
                item.horario = h;
                item.horario_id = h.id;
                h.viaje.Add(item);
            }
        }
    }
}
