using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class AdminConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Admin convert(admin a)
        {
            if (a == null) return null;

            Admin ret = new Admin()
            {
                id = a.id
            };
            return ret;
        }

        public static admin convert(Admin a)
        {
            if (a == null) return null;

            admin ret = new admin()
            {
                id = a.id
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Admin> convert(ICollection<admin> a)
        {
            if (a == null) return null;

            List<Admin> ret = new List<Admin>();
            foreach (var item in a)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<admin> convert(ICollection<Admin> a)
        {
            if (a == null) return null;

            List<admin> ret = new List<admin>();
            foreach (var item in a)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

    }
}
