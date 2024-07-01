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
    public partial class miCuenta : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si hay usuario autenticado en sesión
                if (Session["Login"] != null)
                {
                    var usuario = (Domain.Entities.UsuarioEntity)Session["Login"];
                    lblEmail.Text = usuario.Email; // Mostrar el correo electrónico del usuario
                }
                else
                {
                    // Si no hay sesión, redirigir a la página de login
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}