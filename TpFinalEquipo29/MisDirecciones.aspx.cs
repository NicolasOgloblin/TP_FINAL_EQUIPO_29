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
    public partial class MisDirecciones : System.Web.UI.Page
    {

        private UsuarioBusiness datosusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Login"] != null)
                {
                    datosusuario = new UsuarioBusiness();
                    CargarDireccionResidencia();

                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void CargarDireccionResidencia()
        {
            UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

            if (usuario != null)
            {
                lblResidenciaProvincia.Text = usuario.Provincia ?? "N/A";
                    lblResidenciaLocalidad.Text = usuario.Localidad ?? "N/A";
                    lblResidenciaCalle.Text = usuario.Calle ?? "N/A";
                    lblResidenciaAltura.Text = usuario.Altura ?? "N/A";
                    lblResidenciaCodPostal.Text = usuario.CodPostal ?? "N/A";
                }
            }
        }

       
    }

