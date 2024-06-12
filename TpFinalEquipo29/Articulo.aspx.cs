using Business;
using Business.Articulo;
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
        }

        private void CargarDropDownListMarcas()
        {
            var marcaBusiness = new MarcaBusiness();
            var marcas = marcaBusiness.GetMarcas();

            ddlMarcas.DataSource = marcas;
            ddlMarcas.DataTextField = "Nombre";
            ddlMarcas.DataValueField = "Id";
            ddlMarcas.DataBind();
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
    }
}


