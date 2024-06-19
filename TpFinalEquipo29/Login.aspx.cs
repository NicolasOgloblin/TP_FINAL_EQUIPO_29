using Business.Usuario;
using Domain.Entities;
using System;

namespace TpFinalEquipo29
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnLogin_Click (object sender, EventArgs e)
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            try
            {
                var usuario = new UsuarioEntity();
                usuario.Usuario = txtUsuario.Text;
                usuario.Contrasenia = txtContrasenia.Text;
                var usuarioDB = usuarioBusiness.Loguear(usuario);

                if (usuarioDB != null)
                {
                    Response.Redirect("Default.aspx");
                }
                


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
            
        }
    }
}