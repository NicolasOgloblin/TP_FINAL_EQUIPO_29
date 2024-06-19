using Business.Usuario;
using Domain.Entities;
using System;
using System.Web;

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
                usuario.Provincia = txtProvincia.Text;
                usuario.Localidad = txtLocalidad.Text;
                usuario.CodPostal = txtCodPostal.Text;
                usuario.Rol = new RolesEntity();
                usuario.Rol.Id = 2;

                var usuarioRegistrado = usuarioBusiness.Registrarse(usuario);

                Session["Login"] = usuarioRegistrado;

                Response.Redirect("Default.aspx",false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}