using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class PasajeConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Pasaje convert(pasaje p)
        {
            if (p == null) return null;

            Pasaje ret = new Pasaje()
            {
                id = p.id,
                asiento = p.asiento,
                usado = p.usado,
                documento = p.documento
            };
            if (!p.tipo_documento.Equals(null))
            {
                ret.tipo_documento = (TipoDocumento)p.tipo_documento;
            }
            else
            {
                ret.tipo_documento = null;
            }
            return ret;
        }

        public static pasaje convert(Pasaje p)
        {
            if (p == null) return null;

            pasaje ret = new pasaje()
            {
                id = p.id,
                asiento = p.asiento,
                usado = p.usado,
                documento = p.documento,
            }; 
            if (!p.tipo_documento.Equals(null))
            {
                ret.tipo_documento = (int)p.tipo_documento;
            }
            else
            {
                ret.tipo_documento = null;
            }
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Pasaje> convert(ICollection<pasaje> p)
        {
            if (p == null) return null;

            List<Pasaje> ret = new List<Pasaje>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<pasaje> convert(ICollection<Pasaje> p)
        {
            if (p == null) return null;

            List<pasaje> ret = new List<pasaje>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        
    }
}
