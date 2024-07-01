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
    public partial class DatosPersonales : System.Web.UI.Page
    {

        private UsuarioBusiness datosusuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if (Session["Login"] != null)
                {
                    datosusuario = new UsuarioBusiness();
                    CargarDatosUsuario();
                }
                else
                {
                  
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void CargarDatosUsuario()
        {
            UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDNI.Text = usuario.Dni;
                txtTelefono.Text = usuario.Telefono;
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

                if (usuario != null)
                {
                    
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.Dni = txtDNI.Text;
                    usuario.Telefono = txtTelefono.Text;

                    
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
            // Redirigir a la página principal o a donde sea necesario al cancelar
            Response.Redirect("MiCuenta.aspx");
        }
    }
}
