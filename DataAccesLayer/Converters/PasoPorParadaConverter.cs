using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class PasoPorParadaConverter
    {
        /** Conversion de objetos simples *************************************/
        public static PasoPorParada convert(paso_por_parada ppp)
        {
            if (ppp == null) return null;

            PasoPorParada ret = new PasoPorParada()
            {
                fechaHora = (DateTime) ppp.fecha_hora,
            };
            return ret;
        }

        public static paso_por_parada convert(PasoPorParada ppp)
        {
            if (ppp == null) return null;

            paso_por_parada ret = new paso_por_parada()
            {
                fecha_hora = ppp.fechaHora,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<PasoPorParada> convert(ICollection<paso_por_parada> ppp)
        {
            if (ppp == null) return null;

            List<PasoPorParada> ret = new List<PasoPorParada>();
            foreach (var item in ppp)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<paso_por_parada> convert(ICollection<PasoPorParada> ppp)
        {
            if (ppp == null) return null;

            List<paso_por_parada> ret = new List<paso_por_parada>();
            foreach (var item in ppp)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

    }
}
