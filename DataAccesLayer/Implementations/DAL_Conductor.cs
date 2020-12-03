using DataAccesLayer.Converters;
using DataAccesLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Implementations
{
    public class DAL_Conductor : IDAL_Conductor
    {
        public void FinalizarViaje(int idViaje)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    viaje v = db.viaje.Find(idViaje);

                    if (v == null)
                        throw new Exception("No se encontro ningun viaje con ese ID");

                    if (v.finalizado == null)
                        throw new Exception("No se pudo marcar el viaje como finalizado porque no está marcado como iniciado.");

                    v.finalizado = true;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public void IniciarViaje(int idViaje)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    viaje v = db.viaje.Find(idViaje);

                    if (v == null)
                        throw new Exception("No se encontro ningun viaje con ese ID");

                    if (v.finalizado == true)
                        throw new Exception("No se pudo marcar el viaje como iniciado porque ya está marcado como finalizado.");

                    v.finalizado = false;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Viaje> ListarViajesDelDia(int idConductor)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    ICollection<Viaje> ret = new List<Viaje>();
                    conductor c = db.conductor.Find(idConductor);

                    if (c == null)
                        throw new Exception("No se pudo encontrar el conductor.");

                    foreach (var h in c.horario)
                    {
                        foreach (var v in h.viaje)
                        {
                            if(v.fecha.CompareTo(DateTime.Today) == 0 && v.finalizado == null)
                            {
                                Viaje Vi = ViajeConverter.convert(v);
                                Vi.horario = HorarioConverter.convert(v.horario);
                                Vi.horario.linea = LineaConverter.convert(v.horario.linea);
                                
                                ret.Add(Vi);
                            }
                        }
                    }

                    return ret;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Usuario> RegistrarPasoPorParada(int idParada, int idViaje)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    IDAL_Global blg = new DAL_Global();
                    ICollection<usuario> retSinConvertir = new List<usuario>();
                    viaje v = db.viaje.Find(idViaje);
                    parada p = db.parada.Find(idParada);
                    
                    if (v == null)
                        throw new Exception("No se encontro ningun viaje con ese ID");

                    if (p == null)
                        throw new Exception("No se encontro ninguna parada con ese ID");
                    
                    vehiculo vh = v.horario.vehiculo;

                    paso_por_parada ppp = new paso_por_parada()
                    {
                        fecha_hora = DateTime.Now,
                        viaje = v,
                        parada = p
                    };

                    db.paso_por_parada.Add(ppp);

                    vh.latitud = p.latitud;
                    vh.longitud = p.longitud;
                    db.SaveChanges();


                    ICollection<parada> paradasOrdenadas = ParadaConverter.convert(blg.obtenerParadasDeLinea(v.horario.linea.id));

                    parada siguienteParada = null;
                    for (int i = 0; i < paradasOrdenadas.Count; i++)
                    {
                        if (paradasOrdenadas.ElementAt(i).id == idParada && i+1 < paradasOrdenadas.Count)
                        {
                            siguienteParada = paradasOrdenadas.ElementAt(i + 1);
                        }
                    }

                    if (siguienteParada == null)
                        return new List<Usuario>();

                    retSinConvertir = siguienteParada.pasajes_origen
                        .Where(x => x.usuario != null)
                        .Select(x => x.usuario).ToList();

                    //foreach (var item in siguienteParada.pasaje1)
                    //{
                    //    retSinConvertir.Add(item.usuario);
                    //}

                    ICollection<Usuario> retConvertido = new List<Usuario>();

                    foreach (var item in retSinConvertir)
                    {
                        Usuario nuevo = UsuarioConverter.convert(item);
                        nuevo.persona = PersonaConverter.convert(item.persona);
                        retConvertido.Add(nuevo);
                    }

                    return retConvertido;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public bool ValidarPasaje(int idPasaje, int idViaje, int idParada)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    pasaje p = db.pasaje.Find(idPasaje);

                    if (p == null)
                        return false;

                    if (p.usado)
                        return false;

                    if ( ! p.parada_id_origen.Equals(idParada))
                        return false;

                    if ( ! p.viaje_id.Equals(idViaje))
                        return false;

                    p.usado = true;
                    db.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Viaje ObtenerViajeActual(int idConductor)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    viaje v = db.viaje.Where(x => x.finalizado == false && x.horario.conductor_id == idConductor).First();

                    return ViajeConverter.convert(v);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }

}
