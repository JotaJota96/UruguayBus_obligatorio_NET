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
            List<Vehiculo> ret = new List<Vehiculo>();
            foreach (var item in v)
            {
                ret.Add(convert(item));
            }
            return ret;
        }
        public static ICollection<vehiculo> convert(ICollection<Vehiculo> v)
        {
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
            throw new NotImplementedException("Esta funcion no se ha implementado porque hay que corregir una cosa en la estrutura de la base de datos primero");
        }
        public static void asociarViajes(vehiculo v, ICollection<horario> h)
        {
            throw new NotImplementedException("Esta funcion no se ha implementado porque hay que corregir una cosa en la estrutura de la base de datos primero");
        }
    }
}
