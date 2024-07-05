using Dao.DataAccessObject;
using Dao.Encrypts;
using Domain.Entities;
using System;
using System.Data.SqlClient;

namespace Dao.Implements
{
    public class UsuarioImp
    {
        public UsuarioEntity Loguear(UsuarioEntity usuario)
        {
            UsuarioEntity usuarioLog = new UsuarioEntity();
            DataAccess datos = new DataAccess();

            string consulta = @"SELECT 
                        U.ID,
                        U.NOMBRE,
                        U.APELLIDO,
                        U.DNI,
                        U.USUARIO,
                        U.EMAIL,
                        U.CONTRASENIA,
                        U.SALT,
                        U.ROLID,
                        R.NOMBRE AS ROL_NOMBRE,
                        U.PROVINCIA,
                        U.LOCALIDAD,
                        U.CALLE,
                        U.ALTURA,
                        U.CODIGO_POSTAL,
                        U.TELEFONO,
                        U.ESTADO,
                        U.FECHA_REGISTRO
                        FROM USUARIOS U
                        INNER JOIN ROLES R ON U.ROLID = R.ID 
                        WHERE U.USUARIO = @usuario";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuario", usuario.Usuario);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    usuarioLog.Id = (long)datos.Reader["ID"];
                    usuarioLog.Nombre = datos.Reader["NOMBRE"] != DBNull.Value ? (string)datos.Reader["NOMBRE"] : null;
                    usuarioLog.Apellido = datos.Reader["APELLIDO"] != DBNull.Value ? (string)datos.Reader["APELLIDO"] : null;
                    usuarioLog.Dni = datos.Reader["DNI"] != DBNull.Value ? (string)datos.Reader["DNI"] : null;
                    usuarioLog.Usuario = datos.Reader["USUARIO"] != DBNull.Value ? (string)datos.Reader["USUARIO"] : null;
                    usuarioLog.Email = datos.Reader["EMAIL"] != DBNull.Value ? (string)datos.Reader["EMAIL"] : null;
                    usuarioLog.Contrasenia = datos.Reader["CONTRASENIA"] != DBNull.Value ? (string)datos.Reader["CONTRASENIA"] : null;
                    usuarioLog.Salt = datos.Reader["SALT"] != DBNull.Value ? (string)datos.Reader["SALT"] : null;
                    usuarioLog.Rol = new RolesEntity
                    {
                       
                        Id = (short)datos.Reader["ROLID"],
                        
                        Nombre = datos.Reader["ROL_NOMBRE"] != DBNull.Value ? (string)datos.Reader["ROL_NOMBRE"] : null

                    };
                    usuarioLog.Provincia = datos.Reader["PROVINCIA"] != DBNull.Value ? (string)datos.Reader["PROVINCIA"] : null;
                    usuarioLog.Localidad = datos.Reader["LOCALIDAD"] != DBNull.Value ? (string)datos.Reader["LOCALIDAD"] : null;
                    usuarioLog.Calle = datos.Reader["CALLE"] != DBNull.Value ? (string)datos.Reader["CALLE"] : null;
                    usuarioLog.Altura = datos.Reader["ALTURA"] != DBNull.Value ? (string)datos.Reader["ALTURA"] : null;
                    usuarioLog.CodPostal = datos.Reader["CODIGO_POSTAL"] != DBNull.Value ? (string)datos.Reader["CODIGO_POSTAL"] : null;
                    usuarioLog.Telefono = datos.Reader["TELEFONO"] != DBNull.Value ? (string)datos.Reader["TELEFONO"] : null;
                    usuarioLog.Estado = (bool)datos.Reader["ESTADO"];
                    usuarioLog.FechaRegistro = (DateTime)datos.Reader["FECHA_REGISTRO"];
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
                                VALUES(@nombre,@apellido,@dni,@usuario,@email,@contrasenia,@salt,@rolId,@provincia,@localidad,@calle,@altura,@codPostal,@telefono,1,GETDATE())
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
                datos.setearParametro("@salt", usuario.Salt);
                datos.setearParametro("@rolId", usuario.Rol.Id);
                datos.setearParametro("@provincia", usuario.Provincia);
                datos.setearParametro("@localidad", usuario.Localidad);
                datos.setearParametro("@calle", usuario.Calle);
                datos.setearParametro("@altura", usuario.Altura);
                datos.setearParametro("@codPostal", usuario.CodPostal);
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

        public bool ActualizarUsuario(UsuarioEntity usuario)
        {
            DataAccess datos = new DataAccess();

            string consulta = @"UPDATE USUARIOS SET
                        NOMBRE = @nombre,
                        APELLIDO = @apellido,
                        DNI = @dni,
                        EMAIL = @correo,
                        TELEFONO = @telefono,
                        PROVINCIA = @provincia,
                        LOCALIDAD = @localidad,
                        CALLE = @calle,
                        ALTURA = @altura,
                        CODIGO_POSTAL = @codigoPostal
                        WHERE ID = @id";
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@dni", usuario.Dni);
                datos.setearParametro("@correo", usuario.Email);
                datos.setearParametro("@telefono", usuario.Telefono);
                datos.setearParametro("@provincia", usuario.Provincia);
                datos.setearParametro("@localidad", usuario.Localidad);
                datos.setearParametro("@calle", usuario.Calle);
                datos.setearParametro("@altura", usuario.Altura);
                datos.setearParametro("@codigoPostal", usuario.CodPostal);
                datos.setearParametro("@id", usuario.Id);

                datos.ejecutarAccion();

                return true;
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

        public bool ActualizarContrasenia(UsuarioEntity usuario, string nuevaContrasenia)
        {
            DataAccess datos = new DataAccess();

            string consulta = @"UPDATE USUARIOS SET
                        CONTRASENIA = @contrasenia,
                        SALT = @salt
                        WHERE ID = @id";
            try
            {
                var encrypt = new Encrypt();
                string newSalt = encrypt.GenerateSalt();
                string hashedPassword = encrypt.HashPasswordWithSalt(nuevaContrasenia, newSalt);

                usuario.Contrasenia = hashedPassword;
                usuario.Salt = newSalt;

                datos.setearConsulta(consulta);
                datos.setearParametro("@contrasenia", usuario.Contrasenia);
                datos.setearParametro("@salt", usuario.Salt);
                datos.setearParametro("@id", usuario.Id);

                datos.ejecutarAccion();

                return true;
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
        public bool ActualizarCorreoElectronico(UsuarioEntity usuario)
        {
            DataAccess datos = new DataAccess();

            string consulta = @"UPDATE USUARIOS SET
                                EMAIL = @correo
                                WHERE ID = @id";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@correo", usuario.Email);
                datos.setearParametro("@id", usuario.Id);

                datos.ejecutarAccion();

                return true;
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
        public bool VerificarContraseniaActual(long usuarioId, string contraseniaActual)
        {
            DataAccess datos = new DataAccess();

            string consulta = "SELECT Contrasenia, Salt FROM Usuarios WHERE Id = @UsuarioId";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@UsuarioId", usuarioId);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    string contraseniaEncriptada = datos.Reader["Contrasenia"] != DBNull.Value ? (string)datos.Reader["Contrasenia"] : null;
                    string salt = datos.Reader["Salt"] != DBNull.Value ? (string)datos.Reader["Salt"] : null;

                    if (contraseniaEncriptada != null && salt != null)
                    {
                        var encrypt = new Encrypt();
                        return encrypt.VerifyPassword(contraseniaActual, contraseniaEncriptada, salt);
                    }
                }

                return false; // Usuario no encontrado o datos incorrectos
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la contraseña actual", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public UsuarioEntity ObtenerUsuarioPorId(long usuarioid)
        {
            UsuarioEntity usuario = null;
            DataAccess datos = new DataAccess();

            string consulta = @"SELECT 
                                U.ID,
                                U.NOMBRE,
                                U.APELLIDO,
                                U.DNI,
                                U.USUARIO,
                                U.EMAIL,
                                U.CONTRASENIA,
                                U.SALT,
                                U.ROLID,
                                R.NOMBRE AS ROL_NOMBRE,
                                U.PROVINCIA,
                                U.LOCALIDAD,
                                U.CALLE,
                                U.ALTURA,
                                U.CODIGO_POSTAL,
                                U.TELEFONO,
                                U.ESTADO,
                                U.FECHA_REGISTRO
                            FROM USUARIOS U
                            INNER JOIN ROLES R ON U.ROLID = R.ID 
                            WHERE U.ID = @usuarioid";
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuarioid", usuarioid);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    usuario = new UsuarioEntity();
                    usuario.Id = (long)datos.Reader["ID"];
                    usuario.Nombre = datos.Reader["NOMBRE"] != DBNull.Value ? (string)datos.Reader["NOMBRE"] : null;
                    usuario.Apellido = datos.Reader["APELLIDO"] != DBNull.Value ? (string)datos.Reader["APELLIDO"] : null;
                    usuario.Dni = datos.Reader["DNI"] != DBNull.Value ? (string)datos.Reader["DNI"] : null;
                    usuario.Usuario = datos.Reader["USUARIO"] != DBNull.Value ? (string)datos.Reader["USUARIO"] : null;
                    usuario.Email = datos.Reader["EMAIL"] != DBNull.Value ? (string)datos.Reader["EMAIL"] : null;
                    usuario.Contrasenia = datos.Reader["CONTRASENIA"] != DBNull.Value ? (string)datos.Reader["CONTRASENIA"] : null;
                    usuario.Salt = datos.Reader["SALT"] != DBNull.Value ? (string)datos.Reader["SALT"] : null;
                    usuario.Rol = new RolesEntity
                    {
                        Id = (short)datos.Reader["ROLID"],
                        Nombre = datos.Reader["ROL_NOMBRE"] != DBNull.Value ? (string)datos.Reader["ROL_NOMBRE"] : null
                    };
                    usuario.Provincia = datos.Reader["PROVINCIA"] != DBNull.Value ? (string)datos.Reader["PROVINCIA"] : null;
                    usuario.Localidad = datos.Reader["LOCALIDAD"] != DBNull.Value ? (string)datos.Reader["LOCALIDAD"] : null;
                    usuario.Calle = datos.Reader["CALLE"] != DBNull.Value ? (string)datos.Reader["CALLE"] : null;
                    usuario.Altura = datos.Reader["ALTURA"] != DBNull.Value ? (string)datos.Reader["ALTURA"] : null;
                    usuario.CodPostal = datos.Reader["CODIGO_POSTAL"] != DBNull.Value ? (string)datos.Reader["CODIGO_POSTAL"] : null;
                    usuario.Telefono = datos.Reader["TELEFONO"] != DBNull.Value ? (string)datos.Reader["TELEFONO"] : null;
                    usuario.Estado = (bool)datos.Reader["ESTADO"];
                    usuario.FechaRegistro = (DateTime)datos.Reader["FECHA_REGISTRO"];
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario por ID desde la base de datos.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

       
    }
}

    

    


    

    

