using Business;
using Business.Articulo;
using Business.Marca;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
                CargarDropDownListCategorias();
                CargarDropDownListMarcas();
                CargarArticulos();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string codigoArticulo = txtCodigoArticulo.Text;
                    string nombreArticulo = txtNombre.Text;
                    string descripcionArticulo = txtDescripcion.Text;
                    int categoriaId = Convert.ToInt32(ddlCategorias.SelectedValue);
                    int marcaId = Convert.ToInt32(ddlMarcas.SelectedValue);
                    decimal precioArticulo = Convert.ToDecimal(txtPrecio.Text);
                    int stockArticulo = Convert.ToInt32(txtStock.Text);

                    if (articuloBusiness.ArticuloExiste(codigoArticulo))
                    {
                        lblMensaje.Text = "El artículo ya existe.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    var nuevoArticulo = new ArticuloEntity();
                    nuevoArticulo.CodArticulo = codigoArticulo;
                    nuevoArticulo.Nombre = nombreArticulo;
                    nuevoArticulo.Descripcion = descripcionArticulo;
                    nuevoArticulo.Categoria = new CategoriaEntity();
                    nuevoArticulo.Categoria.Id = categoriaId;
                    nuevoArticulo.Marca = new MarcaEntity();
                    nuevoArticulo.Marca.Id = marcaId;
                    nuevoArticulo.Precio = precioArticulo;
                    nuevoArticulo.Stock = stockArticulo;

                    int resultado = articuloBusiness.agregarArticulo(nuevoArticulo);

                    if (resultado > 0)
                    {
                        lblMensaje.Text = "Artículo agregado exitosamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        LimpiarCampos();
                        CargarArticulos();
                    }
                    else
                    {
                        lblMensaje.Text = "Hubo un problema al agregar el artículo.";
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

        private void CargarDropDownListCategorias()
        {
            var categoriaBusiness = new CategoriaBusiness();
            var categorias = categoriaBusiness.GetCategorias();

            ddlCategorias.DataSource = categorias;
            ddlCategorias.DataTextField = "Nombre";
            ddlCategorias.DataValueField = "Id";
            ddlCategorias.DataBind();

            // Agregar un elemento vacío para selección inicial
            ddlCategorias.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarDropDownListMarcas()
        {
            var marcaBusiness = new MarcaBusiness();
            var marcas = marcaBusiness.GetMarcas();

            ddlMarcas.DataSource = marcas;
            ddlMarcas.DataTextField = "Nombre";
            ddlMarcas.DataValueField = "Id";
            ddlMarcas.DataBind();

            // Agregar un elemento vacío para selección inicial
            ddlMarcas.Items.Insert(0, new ListItem("--Seleccione--", "0"));
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

        private void LimpiarCampos()
        {
            txtCodigoArticulo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlCategorias.SelectedIndex = 0;
            ddlMarcas.SelectedIndex = 0;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
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
                string codigo = ((TextBox)row.FindControl("txtCodigo")).Text;
                string nombre = ((TextBox)row.FindControl("txtNombre")).Text;
                string descripcion = ((TextBox)row.FindControl("txtDescripcion")).Text;
                int marcaId = Convert.ToInt32(((DropDownList)row.FindControl("ddlMarcas")).SelectedValue);
                int categoriaId = Convert.ToInt32(((DropDownList)row.FindControl("ddlCategorias")).SelectedValue);
                decimal precio = Convert.ToDecimal(((TextBox)row.FindControl("txtPrecio")).Text);
                int stock = Convert.ToInt32(((TextBox)row.FindControl("txtStock")).Text);

                var articulo = new ArticuloEntity
                {
                    Id = id,
                    CodArticulo = codigo,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Marca = new MarcaEntity { Id = marcaId },
                    Categoria = new CategoriaEntity { Id = categoriaId },
                    Precio = precio,
                    Stock = stock
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
            try
            {
                long id = Convert.ToInt64(gvArticulos.DataKeys[e.RowIndex].Value);
                int resultado = articuloBusiness.Eliminar(id);

                if (resultado > 0)
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
            if (e.Row.RowType == DataControlRowType.DataRow && gvArticulos.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlMarcas = (DropDownList)e.Row.FindControl("ddlMarcas");
                if (ddlMarcas != null)
                {
                    ddlMarcas.DataSource = new MarcaBusiness().GetMarcas();
                    ddlMarcas.DataTextField = "Nombre";
                    ddlMarcas.DataValueField = "Id";
                    ddlMarcas.DataBind();

                    DataRowView drv = e.Row.DataItem as DataRowView;
                    ddlMarcas.SelectedValue = drv["Marca.Id"].ToString();
                }

                DropDownList ddlCategorias = (DropDownList)e.Row.FindControl("ddlCategorias");
                if (ddlCategorias != null)
                {
                    ddlCategorias.DataSource = new CategoriaBusiness().GetCategorias();
                    ddlCategorias.DataTextField = "Nombre";
                    ddlCategorias.DataValueField = "Id";
                    ddlCategorias.DataBind();

                    DataRowView drv = e.Row.DataItem as DataRowView;
                    ddlCategorias.SelectedValue = drv["Categoria.Id"].ToString();
                }
            }
        }
    }
}