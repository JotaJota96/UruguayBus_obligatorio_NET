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

                    if (rol.Equals(null))
                    {
                        throw new Exception("Se deve espesificar el rol.");
                    }

                    if (per.Equals(null))
                    {
                        throw new Exception("El id del usuario es incorecto.");
                    }

                    if (rol.Equals(Rol.CONDUCTOR))
                    {
                        conductor con = new conductor();
                        con.persona = per;

                        if (fechaVencLibreta.Equals(null))
                        {
                            throw new Exception("Se deve ingresar la fecha de vencimiento de la libreta.");
                        }

                        con.vencimiento_libreta = (DateTime) fechaVencLibreta;
                       
                        db.conductor.Add(con);
                    }

                    if (rol.Equals(Rol.ADMIN))
                    {
                        admin adm = new admin();
                        adm.persona = per;
                        db.admin.Add(adm);
                    }

                    if (rol.Equals(Rol.SUPERADMIN))
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

        public ICollection<Vehiculo> ListarVehiculos()
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    ICollection<Vehiculo> ret = VehiculoConverter.convert(db.vehiculo.ToList());
                    return ret;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
