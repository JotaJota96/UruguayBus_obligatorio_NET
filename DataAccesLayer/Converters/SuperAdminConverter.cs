﻿using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class SuperAdminConverter
    {
        /** Conversion de objetos simples *************************************/
        public static SuperAdmin convert(superadmin s)
        {
            if (s == null) return null;

            SuperAdmin ret = new SuperAdmin()
            {
                id = s.id,
            };
            return ret;
        }

        public static superadmin convert(SuperAdmin s)
        {
            if (s == null) return null;

            superadmin ret = new superadmin()
            {
                id = s.id,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<SuperAdmin> convert(ICollection<superadmin> s)
        {
            if (s == null) return null;

            List<SuperAdmin> ret = new List<SuperAdmin>();
            foreach (var item in s)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<superadmin> convert(ICollection<SuperAdmin> s)
        {
            if (s == null) return null;

            List<superadmin> ret = new List<superadmin>();
            foreach (var item in s)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        
    }
}
