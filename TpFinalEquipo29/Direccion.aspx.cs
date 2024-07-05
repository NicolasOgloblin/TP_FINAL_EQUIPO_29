using Business.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class Direccion : System.Web.UI.Page
    {
        private UsuarioBusiness datosusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Login"] != null)
                {
                    datosusuario = new UsuarioBusiness();
                   
                }
                else
                {
                    Response.Redirect("Login.aspx");

                }
            }

        }


        protected void btnGuardarDireccion_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditarDireccion.aspx");
        }
    }
}
    
