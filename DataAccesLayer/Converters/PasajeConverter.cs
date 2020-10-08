﻿using Share.Entities;
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
            Pasaje ret = new Pasaje()
            {
                id = p.id,
                asiento = p.asiento,
                usado = p.usado,
                documento = p.documento,
                //tipo_documento = p.tipo_documento,
            };
            return ret;
        }

        public static pasaje convert(Pasaje p)
        {
            pasaje ret = new pasaje()
            {
                id = p.id,
                asiento = p.asiento,
                usado = p.usado,
                documento = p.documento,
                //tipo_documento = p.tipo_documento,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Pasaje> convert(ICollection<pasaje> p)
        {
            List<Pasaje> ret = new List<Pasaje>();
            foreach (var item in p)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<pasaje> convert(ICollection<Pasaje> p)
        {
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
