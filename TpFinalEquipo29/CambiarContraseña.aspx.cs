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
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        private UsuarioBusiness usuariolog;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["Login"] != null)
                {
                  
                    if (usuariolog == null)
                    {
                        usuariolog = new UsuarioBusiness();
                    }

                   
                    UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

                    
                    lblEmail.Text = usuario.Email;
                }
                else
                {
                    
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

                if (usuario != null)
                {
                    string contraseniaActual = txtContraseniaActual.Value; 
                    string nuevaContrasenia = txtNuevaContrasenia.Value.Trim(); 
                    string confirmarContrasenia = txtConfirmarContrasenia.Value.Trim(); 

                 
                    if (string.IsNullOrEmpty(contraseniaActual) || string.IsNullOrEmpty(nuevaContrasenia) || string.IsNullOrEmpty(confirmarContrasenia))
                    {
                        throw new Exception("Todos los campos son obligatorios.");
                    }

                   
                    if (nuevaContrasenia != confirmarContrasenia)
                    {
                        throw new Exception("Las nuevas contraseñas no coinciden.");
                    }

                    if (usuariolog == null)
                    {
                        usuariolog = new UsuarioBusiness();
                    }

                    // Validar contraseña actual antes de cambiarla
                    bool validacionContraseña = usuariolog.VerificarContraseniaActual(usuario.Id, contraseniaActual);

                    if (!validacionContraseña)
                    {
                        throw new Exception("La contraseña actual no es válida.");
                    }

                   
                    bool actualizacionExitosa = usuariolog.ActualizarContrasenia(usuario, nuevaContrasenia);

                    if (actualizacionExitosa)
                    {
                      
                        lblMensaje.Text = "La contraseña ha sido actualizada exitosamente.";
                        lblMensaje.CssClass = "alert alert-success";
                    }
                    else
                    {
                        throw new Exception("Error al actualizar la contraseña. Por favor, intenta nuevamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("MiCuenta.aspx");
        }
    }
}