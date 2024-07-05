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
    public partial class EditarDireccion : System.Web.UI.Page
    {
        private UsuarioBusiness datosusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Login"] != null)
                {
                    datosusuario = new UsuarioBusiness();
                    CargarDireccion();
                }
                else
                {

                   
                }
            }
        }

        private void CargarDireccion()
        {
            UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

            if (usuario != null)
            {
             
                txtCalle.Text = usuario.Calle;
                txtNumero.Text = usuario.Altura;
                txtCodigoPostal.Text = usuario.CodPostal;
                txtCiudad.Text = usuario.Localidad;
                txtTelefono.Text = usuario.Telefono;
                txtProvincia.Text = usuario.Provincia;
                
       
            }
        }

        protected void btnGuardarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

                if (usuario != null)
                {

                    usuario.Calle = txtCalle.Text;
                    usuario.Altura = txtNumero.Text;
                    usuario.CodPostal = txtCodigoPostal.Text;
                    usuario.Localidad = txtCiudad.Text;
                    usuario.Telefono = txtTelefono.Text;
                    usuario.Provincia = txtProvincia.Text;


                    if (datosusuario == null)
                    {
                        datosusuario = new UsuarioBusiness();
                    }

                    bool actualizado = datosusuario.ActualizarUsuario(usuario);

                    if (actualizado)
                    {

                        Session["Login"] = usuario;

                        lblMensaje.Text = "Datos actualizados correctamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMensaje.Text = "Error al actualizar los datos del usuario.";
                    }
                }
                else
                {
                    lblMensaje.Text = "No se encontró usuario en sesión.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }

        }

            protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Direccion.aspx");
        }
    }
}
        
    
