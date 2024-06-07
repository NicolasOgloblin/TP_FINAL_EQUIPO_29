using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.DataAccessObject;
using Domain.Entities;

namespace Dao.Implements
{
    public class UsuarioImp
    {
        public UsuarioEntity Loguear(UsuarioEntity usuario)
        {
            UsuarioEntity usuarioLog = new UsuarioEntity();
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"SELECT 
                                U.ID,
                                U.ROLID,
                                R.NOMBRE,
                                U.USUARIO
                                FROM USUARIOS U
                                inner join ROLES R on U.ROLID = R.ID 
                                WHERE  USUARIO = @usuario
                                AND CONTRASENIA = @contrasenia";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuario",usuario.Usuario);
                datos.setearParametro("@contrasenia",usuario.Contrasenia);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    usuarioLog.Id = (int)datos.Reader["ID"];
                    usuarioLog.Rol = new RolesEntity();
                    usuarioLog.Rol.Id = (short)(datos.Reader["ROLID"]); 
                    usuarioLog.Rol.Nombre = (string)(datos.Reader["NOMBRE"]);
                    usuarioLog.Usuario = (string)(datos.Reader["USUARIO"]);
                }
                return usuarioLog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.cerrarConexion(); 
            }
        }
    }
}
