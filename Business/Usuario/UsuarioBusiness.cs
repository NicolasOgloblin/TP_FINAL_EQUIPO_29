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
                
                var usuarioLogin =  UsuarioDao.Loguear(usuario);
                if(usuarioLogin.Id == 0)
                {
                    return null;
                }

                var login = encrypt.VerifyPassword(usuario.Contrasenia,usuarioLogin.Contrasenia,usuarioLogin.Salt);
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
    }
}
