using Business;
using Business.Articulo;
using Business.Marca;
using Domain.Entities;
using System;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class Articulo : System.Web.UI.Page
    {

        private ArticuloBusiness articuloBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            articuloBusiness = new ArticuloBusiness();
            if (!IsPostBack)
            {
                CargarArticulos();
            }
        }
        
        private void CargarArticulos()
        {
            try
            {
                var articulos = articuloBusiness.GetArticulos();

                gvArticulos.DataSource = articulos;
                gvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los artículos: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvArticulos.EditIndex = e.NewEditIndex;
            CargarArticulos();
        }

        protected void gvArticulos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvArticulos.Rows[e.RowIndex];
                long id = Convert.ToInt64(gvArticulos.DataKeys[e.RowIndex].Value);
                
                TextBox txtCodigo = (TextBox)row.FindControl("txtCodigo");
                TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
                DropDownList ddlMarcas = (DropDownList)row.FindControl("ddlMarcas");
                DropDownList ddlCategorias = (DropDownList)row.FindControl("ddlCategorias");
                TextBox txtPrecio = (TextBox)row.FindControl("txtPrecio");
                TextBox txtStock = (TextBox)row.FindControl("txtStock");

                
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                int marcaId = Convert.ToInt32(ddlMarcas.SelectedValue);
                int categoriaId = Convert.ToInt32(ddlCategorias.SelectedValue);
                int stock = Convert.ToInt32(txtStock.Text);

                var articulo = new ArticuloEntity
                {
                    Id = id,
                    CodArticulo = codigo,
                    Nombre = nombre,
                   
                    Marca = new MarcaEntity { Id = marcaId },
                    Categoria = new CategoriaEntity { Id = categoriaId },
                   
                    Stock = stock,
                   
                };
                
                int resultado = articuloBusiness.ModificarArticulo(articulo);
                
                if (resultado > 0)
                {
                    lblMensaje.Text = "Artículo actualizado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    gvArticulos.EditIndex = -1;
                    CargarArticulos();
                }
                else
                {
                    lblMensaje.Text = "Hubo un problema al actualizar el artículo.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void gvArticulos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvArticulos.EditIndex = -1;
            CargarArticulos();
        }
        protected void gvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var articuloBusiness = new ArticuloBusiness();
            try
            {
                long id = Convert.ToInt64(gvArticulos.DataKeys[e.RowIndex].Value);
                
                if (articuloBusiness.GetReservaStock(id) > 0) 
                {
                    var script = "Swal.fire({ title: 'Advertencia', text: 'Este articulo actualmente tiene reserva.', icon: 'warning', confirmButtonText: 'OK' });";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                    return;
                }

                bool resultado = articuloBusiness.Eliminar(id);


                if (resultado)
                {
                    lblMensaje.Text = "Artículo eliminado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    CargarArticulos();
                }
                else
                {
                    lblMensaje.Text = "Hubo un problema al eliminar el artículo.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (gvArticulos.EditIndex == e.Row.RowIndex || e.Row.RowIndex == -1))
            {
                DropDownList ddlMarcas = (DropDownList)e.Row.FindControl("ddlMarcas");
                if (ddlMarcas != null)
                {
                    ddlMarcas.DataSource = new MarcaBusiness().GetMarcas();
                    ddlMarcas.DataTextField = "Nombre";
                    ddlMarcas.DataValueField = "Id";
                    ddlMarcas.DataBind();

                    Label lblMarcaId = (Label)e.Row.FindControl("lblMarcaId");
                    if (lblMarcaId != null)
                    {
                        ddlMarcas.SelectedValue = lblMarcaId.Text;
                    }
                }

                DropDownList ddlCategorias = (DropDownList)e.Row.FindControl("ddlCategorias");
                if (ddlCategorias != null)
                {
                    ddlCategorias.DataSource = new CategoriaBusiness().GetCategorias();
                    ddlCategorias.DataTextField = "Nombre";
                    ddlCategorias.DataValueField = "Id";
                    ddlCategorias.DataBind();

                    Label lblCategoriaId = (Label)e.Row.FindControl("lblCategoriaId");
                    if (lblCategoriaId != null)
                    {
                        ddlCategorias.SelectedValue = lblCategoriaId.Text;
                    }
                }
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Gestion.aspx");
        }
    }
}