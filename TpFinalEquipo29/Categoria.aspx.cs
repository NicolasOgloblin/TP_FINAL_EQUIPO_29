using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Marca;
using Domain.Entities;

namespace TpFinalEquipo29
{
    public partial class Categoria : System.Web.UI.Page
    {
        private CategoriaBusiness categoriaBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            categoriaBusiness = new CategoriaBusiness();
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string nombreCategoria = txtNombre.Text;

                    if (categoriaBusiness.CategoriaExiste(nombreCategoria))
                    {
                        lblMensaje.Text = "La categoría ya existe.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    var nuevaCategoria = new CategoriaEntity
                    {
                        Nombre = nombreCategoria
                    };

                    int resultado = categoriaBusiness.AgregarCategoria(nuevaCategoria);

                    if (resultado > 0)
                    {
                        lblMensaje.Text = "Categoría agregada exitosamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        txtNombre.Text = ""; 
                        CargarCategorias();
                    }
                    else
                    {
                        lblMensaje.Text = "Hubo un problema al agregar la categoría.";
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

        private void CargarCategorias()
        {
            try
            {
                var categorias = categoriaBusiness.GetCategorias();
                gvCategorias.DataSource = categorias;
                gvCategorias.DataBind();

                if (categorias == null || categorias.Count == 0)
                {
                    lblMensaje.Text = "No hay categorías disponibles.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategorias.EditIndex = e.NewEditIndex;
            CargarCategorias();
        }

        protected void gvCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvCategorias.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvCategorias.DataKeys[e.RowIndex].Values[0]);

            
            TextBox txtNombreEdit = (TextBox)row.FindControl("txtNombreEdit");
            if (txtNombreEdit != null)
            {
                string nombre = txtNombreEdit.Text;

                var categoria = new CategoriaEntity { Id = id, Nombre = nombre };

                try
                {
                    
                    if (categoriaBusiness == null)
                    {
                        categoriaBusiness = new CategoriaBusiness();
                    }

                    
                    categoriaBusiness.ModificarCategoria(categoria);
                    gvCategorias.EditIndex = -1;
                    CargarCategorias();
                    lblMensaje.Text = "Categoría modificada exitosamente.";
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

        protected void gvCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategorias.EditIndex = -1;
            CargarCategorias();
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCategorias.DataKeys[e.RowIndex].Values[0]);

            try
            {
                categoriaBusiness.EliminarCategoria(id);
                CargarCategorias();
                lblMensaje.Text = "Categoría eliminada exitosamente.";
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