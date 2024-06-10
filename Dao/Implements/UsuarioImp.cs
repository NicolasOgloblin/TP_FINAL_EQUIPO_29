using Dao.DataAccessObject;
using Domain.Entities;
using System;

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

        public int Registrarse(UsuarioEntity usuario)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"INSERT INTO USUARIOS
                                VALUES(@nombre,@apellido,@dni,@usuario,@email,@contrasenia,@rolId,@provincia,@localidad,@calle,@altura,@telefono,GETDATE())
                                SELECT SCOPE_IDENTITY() AS ID";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@dni", usuario.Dni);
                datos.setearParametro("@usuario", usuario.Usuario);
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@contrasenia", usuario.Contrasenia);
                datos.setearParametro("@rolId", usuario.Rol.Id);
                datos.setearParametro("@provincia", usuario.Provincia);
                datos.setearParametro("@localidad", usuario.Localidad);
                datos.setearParametro("@calle", usuario.Calle);
                datos.setearParametro("@altura", usuario.Altura);
                datos.setearParametro("@telefono", usuario.Telefono);


                var result = datos.ejecutarScalar();

                return Convert.ToInt32(result);
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
