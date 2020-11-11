using DataAccesLayer.Converters;
using DataAccesLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

                    vehiculo veh = db.vehiculo.Find(v.id);

                    veh.cant_asientos = v.cant_asientos;
                    veh.marca = v.marca;
                    veh.modelo = v.modelo;
                    veh.matricula = v.matricula;

                    db.SaveChanges();
                    return VehiculoConverter.convert(veh);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Conductor> ListarConductores()
        {
            try
            {
                using (uruguay_busEntities db = new uruguay_busEntities())
                {
                    ICollection<Conductor> ret = new List<Conductor>();
                    ICollection<conductor> conductores = (ICollection<conductor>)db.conductor.ToList();
                    foreach (var item in conductores)
                    {
                        Conductor c = ConductorConverter.convert(item);
                        c.persona = PersonaConverter.convert(item.persona);
                        ret.Add(c);
                    }
                    return ret;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Horario RegistrarHorario(Horario h)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    horario hor = HorarioConverter.convert(h);
                    hor.conductor = db.conductor.Find(h.conductor.id);
                    hor.linea = db.linea.Find(h.linea.id);
                    hor.vehiculo = db.vehiculo.Find(h.vehiculo.id);

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

                        t.parada = ParadaConverter.convert(tra.parada);

                        precio pre = db.precio.FirstOrDefault(x => x.linea_id == l.id && x.parada_id == t.parada.id);
                        Precio p = PrecioConverter.convert(pre);
                        t.precio.Add(p);
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

        public Parada ModificarParada(Parada p)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    if (p == null || db.parada.Find(p.id) == null)
                        throw new Exception("No se encontro ninguna parada con ese ID");

                    parada par = db.parada.Find(p.id);
                    par.nombre = p.nombre;
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
                    ICollection<viaje> viajesGuardados = new List<viaje>();

                    foreach (var via in viajes)
                    {
                        via.horario = hor;
                        viajesGuardados.Add(via);
                        db.viaje.Add(via);
                    }
                    db.SaveChanges();

                    //-------- para retornar
                    ICollection<Viaje> viajesRet = new List<Viaje>();
                    
                    foreach (var item in viajesGuardados)
                    {
                        Viaje v = ViajeConverter.convert(item);
                        v.horario = HorarioConverter.convert(item.horario);
                        v.horario.vehiculo = VehiculoConverter.convert(item.horario.vehiculo);
                        v.horario.conductor = ConductorConverter.convert(item.horario.conductor);
                        v.horario.linea = LineaConverter.convert(item.horario.linea);
                        viajesRet.Add(v);
                    }

                    return viajesRet;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public Conductor ModificarConductor(Conductor c)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    if (c == null)
                        throw new Exception("No se encontro ningun conductor con ese ID");

                    conductor con = db.conductor.Find(c.id);
                    if (con == null)
                        throw new Exception("No se encontro ningun conductor con ese ID");

                    con.vencimiento_libreta = c.vencimiento_libreta;
                    db.SaveChanges();

                    c = ConductorConverter.convert(con);
                    c.persona = PersonaConverter.convert(con.persona);

                    return c;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public ICollection<Horario> ListarHorarios()
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    ICollection<Horario> ret = new List<Horario>();
                    ICollection<horario> horarios = (ICollection<horario>)db.horario.ToList();

                    foreach (var item in horarios)
                    {
                        Horario h = HorarioConverter.convert(item);
                        h.vehiculo = VehiculoConverter.convert(item.vehiculo);
                        h.conductor = ConductorConverter.convert(item.conductor);
                        h.linea = LineaConverter.convert(item.linea);
                        ret.Add(h);
                    }

                    return ret;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Viaje> ListarViajes()
        {
            try
            {
                using (uruguay_busEntities db = new uruguay_busEntities())
                {
                    ICollection<Viaje> ret = new List<Viaje>();
                    ICollection<viaje> viajes = (ICollection<viaje>)db.viaje.ToList();
                    foreach (var item in viajes)
                    {
                        Viaje v = ViajeConverter.convert(item);
                        v.horario = HorarioConverter.convert(item.horario);
                        v.horario.vehiculo = VehiculoConverter.convert(item.horario.vehiculo);
                        v.horario.conductor = ConductorConverter.convert(item.horario.conductor);
                        v.horario.linea = LineaConverter.convert(item.horario.linea);
                        ret.Add(v);
                    }
                    return ret;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Horario ModificarHorario(Horario h)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    horario horarioModificado = db.horario.Find(h.id);

                    if (h.hora != null)
                    {
                        horarioModificado.hora = h.hora;
                    }

                    if (h.conductor != null)
                    {
                        conductor conductor = db.conductor.Find(h.conductor.id);

                        if (conductor.Equals(null))
                        {
                            throw new Exception("El conductor que se desa asociar al horario no existe");
                        }

                        horarioModificado.conductor = conductor;
                    }

                    if (h.vehiculo != null)
                    {

                        vehiculo vehiculo = db.vehiculo.Find(h.vehiculo.id);

                        if (vehiculo.Equals(null))
                        {
                            throw new Exception("El vehiculo que se desa asociar al horario no existe");
                        }

                        horarioModificado.vehiculo = vehiculo;
                    }


                    db.Entry(horarioModificado).State = EntityState.Modified;
                    db.SaveChanges();
                    return HorarioConverter.convert(horarioModificado);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Linea ModificarLinea(Linea l)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    if (l == null)
                    {
                        throw new Exception("Se deve enviar el objeto que deceas modificar");
                    }

                    if (l.nombre == null)
                    {
                        throw new Exception("El nombre que se desa modificar no puede estar vacio");
                    }

                    linea lineaModificada = db.linea.Find(l.id);
                    lineaModificada.nombre = l.nombre;
                    db.SaveChanges();

                    return LineaConverter.convert(lineaModificada); ;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    
    }
}
