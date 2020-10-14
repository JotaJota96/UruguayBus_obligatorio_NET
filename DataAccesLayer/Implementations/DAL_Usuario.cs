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
    public class DAL_Usuario : IDAL_Usuario
    {
        public Usuario RegistrarUsuario(Usuario u)
        {
            usuario usu = UsuarioConverter.convert(u);
            persona per = PersonaConverter.convert(u.persona);

            usu.persona = per;
            per.usuario = usu;

            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    db.persona.Add(per);
                    db.SaveChanges();

                    Persona personaRet = PersonaConverter.convert(per);
                    Usuario usuarioRet = UsuarioConverter.convert(usu);

                    personaRet.usuario = usuarioRet;
                    usuarioRet.persona = personaRet;

                    return usuarioRet;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
