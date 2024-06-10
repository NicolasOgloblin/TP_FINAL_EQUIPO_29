using Business.Usuario;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var usuarioBusiness = new UsuarioBusiness();
            var usuario = new UsuarioEntity();

            try
            {
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Dni = txtDNI.Text;
                usuario.Usuario = txtUsuario.Text;
                usuario.Contrasenia = txtContrasenia.Text;
                usuario.Email= txtEmail.Text;
                usuario.Calle = txtCalle.Text;
                usuario.Altura = txtAltura.Text;
                usuario.Telefono = txtTelefono.Text;
                usuario.Provincia = "asd";
                usuario.Localidad = "asdd";
                usuario.Rol = new RolesEntity();
                usuario.Rol.Id = 1;
                usuario.Rol.Nombre = "CLIENTE";

                usuarioBusiness.Registrarse(usuario);

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}