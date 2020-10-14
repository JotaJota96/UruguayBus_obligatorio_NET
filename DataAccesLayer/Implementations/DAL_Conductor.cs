using DataAccesLayer.Interfaces;
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

    }

}
