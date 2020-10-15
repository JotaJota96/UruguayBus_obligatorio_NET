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
                    if (v.finalizado == true || v.finalizado == null)
                    {
                        throw new Exception("No se pudo marcar como finalizado el viaje.");
                    }
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
                    if (v.finalizado == true || v.finalizado == false)
                    {
                        throw new Exception("No se pudo marcar como iniciado el viaje.");
                    }
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
                    ICollection<viaje> ret = new List<viaje>();
                    conductor c = db.conductor.Find(idConductor);

                    if (c.Equals(null))
                    {
                        throw new Exception("No se pudo encontrar el conductor.");
                    }

                    foreach (var h in c.horario)
                    {

                        foreach (var v in h.viaje)
                        {
                            if(v.fecha.Equals(DateTime.Today))
                            {
                                ret.Add(v);
                            }
                        }
                    }

                    return ViajeConverter.convert(ret);
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
                    viaje v = db.viaje.Find(idViaje);
                    ICollection<usuario> retSinConvertir = new List<usuario>();

                    parada siguienteParada = null;

                    if (v.Equals(null))
                    {
                        throw new Exception("No se pudo encontrar el viaje.");
                    }
                    IDAL_Global blg = new DAL_Global();

                    ICollection<parada> paradasOrdenadas = ParadaConverter.convert(blg.obtenerParadasDeLinea(v.horario.linea.id));

                    for (int i = 0; i < paradasOrdenadas.Count; i++)
                    {
                        if (paradasOrdenadas.ElementAt(i).id == idParada && i+1 < paradasOrdenadas.Count)
                        {
                            siguienteParada = paradasOrdenadas.ElementAt(i + 1);
                        }
                    }
                    if (siguienteParada.Equals(null))
                    {
                        return new List<Usuario>();
                    }

                    siguienteParada = db.parada.Find(siguienteParada.id);

                    foreach (var item in siguienteParada.pasaje1)
                    {
                        retSinConvertir.Add(item.usuario);
                    }

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

                    if (p.Equals(null))
                    {
                        return false;
                    }

                    if (p.usado)
                    {
                        return false;
                    }

                    if (p.parada_id_origen.Equals(idParada))
                    {
                        return false;
                    }

                    if (p.viaje_id.Equals(idViaje))
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }

}
