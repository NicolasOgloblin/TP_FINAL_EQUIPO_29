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
    public partial class ModificarMail : System.Web.UI.Page
    {
        private UsuarioBusiness datosUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si hay usuario autenticado en sesión
                if (Session["Login"] != null)
                {
                    datosUsuario = new UsuarioBusiness();
                    CargarDatosUsuario();
                }
                else
                {
                    // Si no hay sesión, redirigir a la página de login
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void CargarDatosUsuario()
        {
            UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

            if (usuario != null)
            {
                txtEmailActual.Text = usuario.Email;
            }
        }

        //protected void btnGuardarCambios_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

        //        if (usuario != null)
        //        {
        //            string nuevoEmail = txtNuevoEmail.Text.Trim();
        //            string confirmarEmail = txtConfirmarEmail.Text.Trim();
        //            string contrasenia = txtContrasenia.Text.Trim();

        //            // Validar que los campos obligatorios estén completos
        //            if (string.IsNullOrEmpty(nuevoEmail) || string.IsNullOrEmpty(confirmarEmail) || string.IsNullOrEmpty(contrasenia))
        //            {
        //                lblMensaje.Text = "Todos los campos son obligatorios.";
        //                return;
        //            }

        //            // Validar que los nuevos correos coincidan
        //            if (nuevoEmail != confirmarEmail)
        //            {
        //                lblMensaje.Text = "Los nuevos correos electrónicos no coinciden.";
        //                return;
        //            }

        //            // Validar contraseña actual antes de actualizar el correo
        //     //       bool validacionContraseña = datosUsuario.ValidarContraseña(usuario, contrasenia);

        //            if (!validacionContraseña)
        //            {
        //                lblMensaje.Text = "La contraseña ingresada no es válida.";
        //                return;
        //            }

        //            // Actualizar el correo electrónico del usuario
        //            usuario.Email = nuevoEmail;
        //         //   bool actualizacionExitosa = datosUsuario.ActualizarCorreoElectronico(usuario);

        //            if (actualizacionExitosa)
        //            {
        //                // Actualizar sesión con el usuario modificado
        //                Session["Login"] = usuario;

        //                // Mensaje de éxito
        //                lblMensaje.Text = "El correo electrónico ha sido actualizado exitosamente.";
        //            }
        //            else
        //            {
        //                lblMensaje.Text = "Error al actualizar el correo electrónico. Por favor, intenta nuevamente.";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = "Error: " + ex.Message;
        //    }
        //}

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirigir a la página principal o a donde sea necesario al cancelar
            Response.Redirect("MiCuenta.aspx");
        }
    }
}