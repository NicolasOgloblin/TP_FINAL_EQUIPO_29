using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Implements;
using Domain;
using Dao;
using Domain.Entities;
using Microsoft.SqlServer.Server;

namespace Business.Usuario
{
    public class UsuarioBusiness
    {
        /*public bool Loguear(UsuarioEntity usuario)
        {
            var Usuario = new UsuarioEntity();
            var UsuarioDao = new UsuarioImp();
            try
            {
                Usuario = UsuarioDao.Loguear(usuario);

                return Usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public UsuarioEntity Loguear(UsuarioEntity usuario)
        {
            var UsuarioDao = new UsuarioImp();
            try
            {
                return UsuarioDao.Loguear(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
