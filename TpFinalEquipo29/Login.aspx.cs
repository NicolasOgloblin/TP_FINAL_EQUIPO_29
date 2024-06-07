using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Entities;
using Business.Usuario;

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
                usuario.Usuario = txtUsusario.Text;
                usuario.Contrasenia = txtPassword.Text;
                var usuarioDB = usuarioBusiness.Loguear(usuario);

                if (usuarioDB != null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                     //buscar cartel
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
            
        }
    }
}