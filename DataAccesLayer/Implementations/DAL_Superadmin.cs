using DataAccesLayer.Converters;
using DataAccesLayer.Interfaces;
using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Implementations
{
    public class DAL_Superadmin : IDAL_Superadmin
    {
        public void AsignarRol(int idUsuario, Rol rol, DateTime? fechaVencLibreta)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    persona per = db.usuario.Find(idUsuario).persona;

                    if (per == null)
                        throw new Exception("El ID del usuario es incorecto.");

                    if (rol.Equals(Rol.CONDUCTOR))
                    {
                        if (fechaVencLibreta == null)
                            throw new Exception("Se deve ingresar la fecha de vencimiento de la libreta.");

                        conductor con = new conductor();
                        con.persona = per;
                        con.vencimiento_libreta = (DateTime) fechaVencLibreta;
                       
                        db.conductor.Add(con);
                    }
                    else if (rol.Equals(Rol.ADMIN))
                    {
                        admin adm = new admin();
                        adm.persona = per;
                        db.admin.Add(adm);
                    }
                    else if (rol.Equals(Rol.SUPERADMIN))
                    {
                        superadmin spm = new superadmin();
                        spm.persona = per;
                        db.superadmin.Add(spm);
                    }

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
