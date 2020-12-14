using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    public class ParadaConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Parada convert(parada p)
        {
            if (p == null) return null;

            Parada ret = new Parada()
            {
                id = p.id,
                nombre = p.nombre,
                latitud = p.latitud,
                longitud = p.longitud
            };
            return ret;
        }

        public static parada convert(Parada p)
        {
            if (p == null) return null;

            parada ret = new parada()
            {
                id = p.id,
                nombre = p.nombre,
                latitud = p.latitud,
                longitud = p.longitud
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Parada> convert(ICollection<parada> p)
        {
            if (p == null) return null;

            List<Parada> ret = new List<Parada>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<parada> convert(ICollection<Parada> p)
        {
            if (p == null) return null;

            List<parada> ret = new List<parada>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarPasajesOrigen(Parada p, ICollection<Pasaje> po)
        {
            foreach (var item in po)
            {
                item.parada_origen = p;
                p.pasajes_origen.Add(item);
            }
        }
        public static void asociarPasajesOrigen(parada p, ICollection<pasaje> po)
        {
            foreach (var item in po)
            {
                item.parada_origen = p;
                item.parada_id_origen = p.id;
                p.pasajes_origen.Add(item);
            }
        }

        public static void asociarPasajesDestino(Parada p, ICollection<Pasaje> pd)
        {
            foreach (var item in pd)
            {
                item.parada_destino = p;
                p.pasajes_destino.Add(item);
            }
        }
        public static void asociarPasajesDestino(parada p, ICollection<pasaje> pd)
        {
            foreach (var item in pd)
            {
                item.parada_destino = p;
                item.parada_id_destino = p.id;
                p.pasajes_destino.Add(item);
            }
        }

        public static void asociarTramos(Parada p, ICollection<Tramo> t)
        {
            foreach (var item in t)
            {
                item.parada = p;
                p.tramos.Add(item);
            }
        }
        public static void asociarTramos(parada p, ICollection<tramo> t)
        {
            foreach (var item in t)
            {
                item.parada = p;
                item.parada_id = p.id;
                p.tramo.Add(item);
            }
        }
    }
}
