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
               
                if (Session["Login"] != null)
                {
                    if (datosUsuario == null)
                    {
                        datosUsuario = new UsuarioBusiness();
                    }
                    

                    UsuarioEntity usuario = (UsuarioEntity)Session["Login"];
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
                txtEmailActual.Text = usuario.Email;
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEntity usuario = (UsuarioEntity)Session["Login"];

                if (usuario != null)
                {
                    string nuevoEmail = txtNuevoEmail.Text.Trim();
                    string confirmarEmail = txtConfirmarEmail.Text.Trim();

                  
                    if (string.IsNullOrEmpty(nuevoEmail) || string.IsNullOrEmpty(confirmarEmail))
                    {
                        lblMensaje.Text = "Todos los campos son obligatorios.";
                        return;
                    }

                  
                    if (nuevoEmail != confirmarEmail)
                    {
                        lblMensaje.Text = "Los nuevos correos electrónicos no coinciden.";
                        return;
                    }

                    
                    if (datosUsuario == null)
                    {
                        datosUsuario = new UsuarioBusiness();
                    }


                    bool actualizacionExitosa = datosUsuario.ActualizarCorreoElectronico(usuario.Id,nuevoEmail);

                    if (actualizacionExitosa)
                    {
                        lblMensaje.Text = "El email ha sido actualizada exitosamente.";
                        lblMensaje.CssClass = "alert alert-success";
                    }
                    else
                    {
                        throw new Exception("Error al actualizar el email.");
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("MiCuenta.aspx");
        }
    }
}