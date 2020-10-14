using DataAccesLayer.Converters;
using DataAccesLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Implementations
{
    public class DAL_Admin : IDAL_Admin
    {
        public ICollection<Parada> ListarParadas()
        {
            try
            {
                using (uruguay_busEntities db = new uruguay_busEntities())
                {
                    ICollection<parada> lstParadas = (ICollection<parada>) db.parada.ToList();
                    Console.WriteLine(lstParadas.Count());
                    return ParadaConverter.convert(lstParadas);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Vehiculo ModificarVehiculo(Vehiculo v)
        {
            vehiculo veh = VehiculoConverter.convert(v);

            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    db.Entry(veh).State = EntityState.Modified;
                    db.SaveChanges();
                    return VehiculoConverter.convert(veh);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Parada RegistrarParada(Parada p)
        {
            parada par = ParadaConverter.convert(p);

            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    db.parada.Add(par);
                    db.SaveChanges();

                    return ParadaConverter.convert(par);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Vehiculo RegistrarVehiculo(Vehiculo v)
        {
            vehiculo veh = VehiculoConverter.convert(v);

            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    db.vehiculo.Add(veh);
                    db.SaveChanges();

                    return VehiculoConverter.convert(veh);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
