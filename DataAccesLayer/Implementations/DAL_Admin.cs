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
        public Vehiculo ModificarVehiculo(Vehiculo v)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    if (v == null || db.vehiculo.Find(v.id) == null)
                        throw new Exception("No se encontro ningun vehiculo con ese ID");

                    vehiculo veh = VehiculoConverter.convert(v);

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

        public Horario RegistrarHorario(Horario h)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    horario hor   = HorarioConverter.convert(h);
                    hor.conductor = db.conductor.Find(h.conductor.id);
                    hor.linea     = db.linea.Find(h.linea.id);
                    hor.vehiculo  = db.vehiculo.Find(h.vehiculo.id);

                    if (hor.conductor == null)
                        throw new Exception("No se encontro ningun conductor con ese ID");
                    if (hor.linea == null)
                        throw new Exception("No se encontro ninguna linea con ese ID");
                    if (hor.vehiculo == null)
                        throw new Exception("No se encontro ningun vehiculo con ese ID");

                    db.horario.Add(hor);
                    db.SaveChanges();

                    return HorarioConverter.convert(hor);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Linea RegistrarLinea(Linea l)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    // convertir linea
                    // convertir tramos y asociarlos a la linea
                    // para cada tramo obtener la parada desde la DB y asociarlo
                    // para cada tramo convertir y asociar el precio
                    linea lin = LineaConverter.convert(l);
                    foreach (var t in l.tramos)
                    {

                        tramo tra = TramoConverter.convert(t);
                        lin.tramo.Add(tra);

                        parada par = db.parada.Find(t.parada.id);
                        if (par == null)
                            throw new Exception("No se encontro ninguna parada con ese ID");
                        tra.parada = par;

                        tra.precio.Add(PrecioConverter.convert(t.precio.First()));
                    }

                    // guardo la linea, sus tramos y sus precios (las paradas no, esas ya estaban en a DB)
                    db.linea.Add(lin);
                    //foreach (var tra in lin.tramo)
                    //{
                    //    db.tramo.Add(tra);
                    //    db.precio.Add(tra.precio.First());
                    //}
                    db.SaveChanges();

                    // Hago las conversiones inversas y las asociaciones 
                    l = LineaConverter.convert(lin);
                    foreach (var tra in lin.tramo)
                    {
                        Tramo t = TramoConverter.convert(tra);
                        l.tramos.Add(t);
                        t.linea = l;

                        t.parada = ParadaConverter.convert(tra.parada);
                        t.parada.tramos.Add(t);

                        precio pre = db.precio.FirstOrDefault(x => x.linea_id == l.id && x.parada_id == t.parada.id);
                        Precio p = PrecioConverter.convert(pre);
                        t.precio.Add(p);
                        p.tramo = t;
                    }

                    return l;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Parada RegistrarParada(Parada p)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    parada par = ParadaConverter.convert(p);

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
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    vehiculo veh = VehiculoConverter.convert(v);

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

        public ICollection<Viaje> RegistrarViajes(ICollection<Viaje> vs, int idHorario)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    horario hor = db.horario.Find(idHorario);
                    if (hor == null)
                        throw new Exception("No se encontro ningun horario con ese ID");
                    
                    ICollection<viaje> viajes = ViajeConverter.convert(vs);

                    foreach (var via in viajes)
                    {
                        via.horario = hor;
                        db.viaje.Add(via);
                    }
                    db.SaveChanges();

                    return ViajeConverter.convert(viajes);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}
