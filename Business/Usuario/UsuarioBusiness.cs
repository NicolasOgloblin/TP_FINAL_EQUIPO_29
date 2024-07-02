using Business.Usuario;
using Dao.Encrypts;
using Dao.Implements;
using Domain.Entities;
using System;

namespace Business.Usuario
{
    public class UsuarioBusiness
    {
        public UsuarioEntity Registrarse(UsuarioEntity usuario)
        {
            var usuarioDao = new UsuarioImp();
            var encrypt = new Encrypt();

            try
            {
                string salt = encrypt.GenerateSalt();

                var pass = encrypt.HashPasswordWithSalt(usuario.Contrasenia, salt);

                usuario.Contrasenia = pass;
                usuario.Salt = salt;

                var result = usuarioDao.Registrarse(usuario);

                var login = usuarioDao.Loguear(usuario);

                return login;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public UsuarioEntity Loguear(UsuarioEntity usuario)
        {
            var UsuarioDao = new UsuarioImp();
            var encrypt = new Encrypt();
            try
            {

                var usuarioLogin = UsuarioDao.Loguear(usuario);
                if (usuarioLogin.Id == 0)
                {
                    return null;
                }

                var login = encrypt.VerifyPassword(usuario.Contrasenia, usuarioLogin.Contrasenia, usuarioLogin.Salt);
                if (login)
                {
                    usuarioLogin.Contrasenia = string.Empty;
                    usuarioLogin.Salt = string.Empty;

                    return usuarioLogin;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarUsuario(UsuarioEntity usuario)
        {
            var usuarioDao = new UsuarioImp();
            try
            {
                return usuarioDao.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarContrasenia(UsuarioEntity usuario, string nuevaContrasenia)
        {
            var usuarioDao = new UsuarioImp();
            var encrypt = new Encrypt();
            try
            {
                string newSalt = encrypt.GenerateSalt();
                string hashedPassword = encrypt.HashPasswordWithSalt(nuevaContrasenia, newSalt);

                usuario.Contrasenia = hashedPassword;
                usuario.Salt = newSalt;

                return usuarioDao.ActualizarContrasenia(usuario, nuevaContrasenia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la contraseña.", ex);
            }
        }

        private UsuarioEntity ObtenerUsuarioPorId(long usuarioid)
        {
            var usuarioDao = new UsuarioImp();
            try
            {
              
                var usuario = usuarioDao.ObtenerUsuarioPorId(usuarioid);

               
                return usuario;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error al obtener usuario por ID.", ex);
            }
        }

        public bool VerificarContraseniaActual(long usuarioId, string contraseniaActual)
        {
            try
            {
                
                UsuarioEntity usuario = ObtenerUsuarioPorId(usuarioId);

                if (usuario != null)
                {
                    // Verificar la contraseña usando la clase Encrypt
                    var encrypt = new Encrypt();
                    return encrypt.VerifyPassword(contraseniaActual, usuario.Contrasenia, usuario.Salt);
                }
                else
                {
                    throw new Exception("Usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la contraseña actual.", ex);
            }
        }


       

    }
}


