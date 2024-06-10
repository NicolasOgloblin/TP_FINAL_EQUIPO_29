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
