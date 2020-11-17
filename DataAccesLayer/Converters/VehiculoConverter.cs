using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Converters
{
    class VehiculoConverter
    {
        /** Conversion de objetos simples *************************************/
        public static Vehiculo convert(vehiculo v)
        {
            if (v == null) return null;

            Vehiculo ret = new Vehiculo()
            {
                id = v.id,
                marca = v.marca,
                modelo = v.modelo,
                latitud = v.latitud,
                longitud = v.longitud,
                matricula = v.matricula,
                cant_asientos = v.cant_asientos,
            };
            return ret;
        }

        public static vehiculo convert(Vehiculo v)
        {
            if (v == null) return null;

            vehiculo ret = new vehiculo()
            {
                id = v.id,
                marca = v.marca,
                modelo = v.modelo,
                latitud = v.latitud,
                longitud = v.longitud,
                matricula = v.matricula,
                cant_asientos = v.cant_asientos,
            };
            return ret;
        }

        /** Conversion de colecciones *****************************************/
        public static ICollection<Vehiculo> convert(ICollection<vehiculo> v)
        {
            if (v == null) return null;

            List<Vehiculo> ret = new List<Vehiculo>();
            foreach (var item in v)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<vehiculo> convert(ICollection<Vehiculo> v)
        {
            if (v == null) return null;

            List<vehiculo> ret = new List<vehiculo>();
            foreach (var item in v)
            {
                ret.Add(convert(item));
            }
            return ret;
        }

        /** Vinculacion de colecciones ****************************************/
        public static void asociarViajes(Vehiculo v, ICollection<Horario> h)
        {
            foreach (var item in h)
            {
                item.vehiculo = v;
                v.horario.Add(item);
            }
        }
        public static void asociarViajes(vehiculo v, ICollection<horario> h)
        {
            foreach (var item in h)
            {
                item.vehiculo = v;
                item.vehiculo_id = v.id;
                v.horario.Add(item);
            }
        }
    }
}
