using Business.Usuario;
using Domain.Entities;
using System;

namespace TpFinalEquipo29
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["Login"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
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
                    Session["Login"] = usuarioDB;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblError.Text = "Usuario/Contraseña Incorrectos";
                    lblError.Visible = true;
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
            
        }
    }
}