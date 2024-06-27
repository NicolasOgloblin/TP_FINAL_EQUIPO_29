using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si el usuario está autenticado
                if (Session["Login"] != null)
                {
                    // Obtener el nombre de usuario de la sesión, asegurándote de que esté almacenado correctamente
                    var username = (UsuarioEntity)Session["Login"];

                    // Mostrar el nombre de usuario en el Label del navbar si está disponible
                    if (!string.IsNullOrEmpty(username.Usuario))
                    {
                        lblUsername.Text = username.Usuario;
                        lblUsername.Visible = true;
                       
                        liLogin.Visible = false;
                    }
                    else
                    {
                        lblUsername.Text = "";
                        lblUsername.Visible = false;
                    }
                }
                else
                {
                    // Si no está autenticado, ocultar o limpiar el Label
                    lblUsername.Text = "";
                    lblUsername.Visible = false;
                }
            }
        }


    }
}