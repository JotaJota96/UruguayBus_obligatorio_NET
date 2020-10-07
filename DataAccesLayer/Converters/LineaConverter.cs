using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class LineaConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Linea convert(linea l)
        {
            Linea ret = new Linea()
            {
                id = l.id,
                nombre = l.nombre

            };
            return ret;
        }

        public static linea convert(Linea l)
        {
            linea ret = new linea()
            {
                id = l.id,
                nombre = l.nombre

            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Linea> convert(ICollection<linea> l)
        {
            List<Linea> ret = new List<Linea>();
            foreach (var item in l)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<linea> convert(ICollection<Linea> l)
        {
            List<linea> ret = new List<linea>();
            foreach (var item in l)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarHorarios(Linea l, ICollection<Horario> h)
        {
            foreach (var item in h)
            {
                item.linea = l;
                l.horarios.Add(item);
            }
        }
        public static void asociarHorarios(linea l, ICollection<horario> h)
        {
            foreach (var item in h)
            {
                item.linea = l;
                item.linea_id = l.id;
                l.horario.Add(item);
            }
        }

        public static void asociarTramos(Linea l, ICollection<Tramo> t)
        {
            foreach (var item in t)
            {
                item.linea = l;
                l.tramos.Add(item);
            }
        }
        public static void asociarTramos(linea l, ICollection<tramo> t)
        {
            foreach (var item in t)
            {
                item.linea = l;
                item.linea_id = l.id;
                l.tramo.Add(item);
            }
        }
    }
}
