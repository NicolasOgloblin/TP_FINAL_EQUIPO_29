using Business;
using Business.Marca;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class Marca : System.Web.UI.Page
    {
        private MarcaBusiness marcaBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            marcaBusiness = new MarcaBusiness();
            if (!IsPostBack)
            {
                CargarMarcas();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string nombreMarca = txtNombre.Text;

                    if (marcaBusiness.MarcaExiste(nombreMarca))
                    {
                        lblMensaje.Text = "La marca ya existe.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    var nuevaMarca = new MarcaEntity
                    {
                        Nombre = nombreMarca
                    };

                    int resultado = marcaBusiness.AgregarMarca(nuevaMarca);

                    if (resultado > 0)
                    {
                        lblMensaje.Text = "Marca agregada exitosamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        txtNombre.Text = "";
                        CargarMarcas();
                    }
                    else
                    {
                        lblMensaje.Text = "Hubo un problema al agregar la marca.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void CargarMarcas()
        {
            try
            {
                var marcas = marcaBusiness.GetMarcas();
                gvMarcas.DataSource = marcas;
                gvMarcas.DataBind();

                if (marcas == null || marcas.Count == 0)
                {
                    lblMensaje.Text = "No hay marcas disponibles.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvMarcas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMarcas.EditIndex = e.NewEditIndex;
            CargarMarcas();
        }

        protected void gvMarcas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvMarcas.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvMarcas.DataKeys[e.RowIndex].Values[0]);


            TextBox txtNombreEdit = (TextBox)row.FindControl("txtNombreEdit");
            if (txtNombreEdit != null)
            {
                string nombre = txtNombreEdit.Text;

                var marca = new MarcaEntity { Id = id, Nombre = nombre };

                try
                {

                    if (marcaBusiness == null)
                    {
                        marcaBusiness = new MarcaBusiness();
                    }


                    marcaBusiness.ModificarMarca(marca);
                    gvMarcas.EditIndex = -1;
                    CargarMarcas();
                    lblMensaje.Text = "Marca modificada exitosamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {

                lblMensaje.Text = "No se encontró el control de nombre editado.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvMarcas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMarcas.EditIndex = -1;
            CargarMarcas();
        }

        protected void gvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvMarcas.DataKeys[e.RowIndex].Values[0]);

            try
            {
                marcaBusiness.EliminarMarca(id);
                CargarMarcas();
                lblMensaje.Text = "Marca eliminada exitosamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}