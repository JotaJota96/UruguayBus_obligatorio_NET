using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class ConductorConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Conductor convert(conductor c)
        {
            if (c == null) return null;

            Conductor ret = new Conductor()
            {
                id = c.id,
                vencimiento_libreta = c.vencimiento_libreta
               
            };
            return ret;
        }

        public static conductor convert(Conductor c)
        {
            if (c == null) return null;

            conductor ret = new conductor()
            {
                id = c.id,
                vencimiento_libreta = c.vencimiento_libreta

            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Conductor> convert(ICollection<conductor> c)
        {
            if (c == null) return null;

            List<Conductor> ret = new List<Conductor>();
            foreach (var item in c)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<conductor> convert(ICollection<Conductor> c)
        {
            if (c == null) return null;

            List<conductor> ret = new List<conductor>();
            foreach (var item in c)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarHorarios(Conductor c, ICollection<Horario> h)
        {
            foreach (var item in h)
            {
                item.conductor = c;
                c.horarios.Add(item);
            }
        }
        public static void asociarHorarios(conductor c, ICollection<horario> h)
        {
            foreach (var item in h)
            {
                item.conductor = c;
                item.conductor_id = c.id;
                c.horario.Add(item);
            }
        }

    }
}
