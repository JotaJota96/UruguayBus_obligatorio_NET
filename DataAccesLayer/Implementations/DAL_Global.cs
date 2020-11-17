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
    public class DAL_Global : IDAL_Global
    {
        public ICollection<Parada> obtenerParadasDeLinea(int idLinea)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    ICollection<parada> ret = new List<parada>();
                    IDictionary<int, parada> dicParada = new SortedDictionary<int,parada>();

                    linea l = db.linea.Where(x => x.id == idLinea).FirstOrDefault();
                    
                    if (l == null)
                        throw new Exception("No se encontró ninguna linea con ese ID");

                    foreach (var item in l.tramo)
                    {
                        dicParada.Add(item.numero,item.parada);
                    }

                    ret = dicParada.Values;

                    return ParadaConverter.convert(ret);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Parada> ListarParadas()
        {
            try
            {
                using (uruguay_busEntities db = new uruguay_busEntities())
                {
                    ICollection<parada> lstParadas = (ICollection<parada>)db.parada.ToList();
                    Console.WriteLine(lstParadas.Count());
                    return ParadaConverter.convert(lstParadas);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ICollection<Vehiculo> ListarVehiculos()
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    return VehiculoConverter.convert(db.vehiculo.ToList());
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Usuario ObtenerUsuario(string correo)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    usuario u = db.usuario.Where(x => x.persona.correo.Equals(correo)).FirstOrDefault();
                    if (u == null)
                        return null;

                    Usuario ret = UsuarioConverter.convert(u);
                    ret.persona = PersonaConverter.convert(u.persona);
                    ret.persona.conductor = ConductorConverter.convert(u.persona.conductor);
                    ret.persona.admin = AdminConverter.convert(u.persona.admin);
                    ret.persona.superadmin = SuperAdminConverter.convert(u.persona.superadmin);

                    return ret;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Linea> ListarLinea()
        {
            try
            {
                using (uruguay_busEntities db = new uruguay_busEntities())
                {
                    ICollection<linea> lst = (ICollection<linea>)db.linea.ToList();
                    
                    return LineaConverter.convert(lst);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ICollection<Usuario> ListarUsuario()
        {
            try
            {
                using (uruguay_busEntities db = new uruguay_busEntities())
                {
                    ICollection<usuario> lst = (ICollection<usuario>)db.usuario.ToList();
                    ICollection<Usuario> ret = new List<Usuario>();

                    foreach (var item in lst)
                    {
                        Usuario u = UsuarioConverter.convert(item);
                        u.persona = PersonaConverter.convert(item.persona);
                        u.persona.admin = item.persona.admin == null ? null : AdminConverter.convert(item.persona.admin);
                        u.persona.superadmin = item.persona.superadmin == null ? null : SuperAdminConverter.convert(item.persona.superadmin);
                        u.persona.conductor = item.persona.conductor == null ? null : ConductorConverter.convert(item.persona.conductor);

                        ret.Add(u);
                    }
                    
                    return ret;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
