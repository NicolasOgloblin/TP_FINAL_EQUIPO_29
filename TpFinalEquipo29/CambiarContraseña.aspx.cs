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
                // Verificar si hay usuario autenticado en sesión
                if (Session["Login"] != null)
                {
                    usuariolog = new UsuarioBusiness();

                    // Obtener usuario de sesión
                    UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

                    // Mostrar correo electrónico del usuario
                    lblEmail.Text = usuario.Email;
                }
                else
                {
                    // Si no hay sesión, redirigir a la página de login
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
                    string contraseniaActual = txtContraseniaActual.Value; // Obtener valor de contraseña actual
                    string nuevaContrasenia = txtNuevaContrasenia.Value.Trim(); // Obtener valor de nueva contraseña y quitar espacios en blanco
                    string confirmarContrasenia = txtConfirmarContrasenia.Value.Trim(); // Obtener valor de confirmación de contraseña y quitar espacios en blanco

                    // Validar que los campos obligatorios estén completos
                    if (string.IsNullOrEmpty(contraseniaActual) || string.IsNullOrEmpty(nuevaContrasenia) || string.IsNullOrEmpty(confirmarContrasenia))
                    {
                        throw new Exception("Todos los campos son obligatorios.");
                    }

                    // Validar que la nueva contraseña coincida con la confirmación
                    if (nuevaContrasenia != confirmarContrasenia)
                    {
                        throw new Exception("Las nuevas contraseñas no coinciden.");
                    }

                    // Validar contraseña actual antes de cambiarla
                    bool validacionContraseña = usuariolog.VerificarContraseniaActual(usuario, contraseniaActual);

                    if (!validacionContraseña)
                    {
                        throw new Exception("La contraseña actual no es válida.");
                    }

                    // Actualizar la contraseña del usuario
                    bool actualizacionExitosa = usuariolog.ActualizarContrasenia(usuario, nuevaContrasenia);

                    if (actualizacionExitosa)
                    {
                        // Mensaje de éxito
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
            // Redirigir a la página principal o a donde sea necesario al cancelar
            Response.Redirect("MiCuenta.aspx");
        }
    }
}