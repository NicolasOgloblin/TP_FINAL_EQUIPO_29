using Business;
using Business.Articulo;
using Business.Marca;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace TpFinalEquipo29
{
    public partial class EditarCompleto : System.Web.UI.Page
    {
        private ArticuloBusiness articuloBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            articuloBusiness = new ArticuloBusiness();
            if (!IsPostBack)
            {
                
                CargarMarcas();
                CargarCategorias();

                if (Request.QueryString["id"] != null)
                {
                    int articuloId = Convert.ToInt32(Request.QueryString["id"]);
                    CargarArticulo(articuloId);
                }
            }
        }

        private void CargarMarcas()
        {
            try
            {
                ddlMarcas.DataSource = new MarcaBusiness().GetMarcas();
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataValueField = "Id";
                ddlMarcas.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar las marcas: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void CargarCategorias()
        {
            try
            {
                ddlCategorias.DataSource = new CategoriaBusiness().GetCategorias();
                ddlCategorias.DataTextField = "Nombre";
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar las categorías: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void CargarArticulo(int articuloId)
        {
            try
            {
                 var articulo = articuloBusiness.getByID(articuloId);

                if (articulo != null)
                {
                    lblMensaje.Text = "";
                    
                    txtCodigo.Text = articulo.CodArticulo;
                    txtNombre.Text = articulo.Nombre;
                    ddlMarcas.SelectedValue = articulo.Marca.Id.ToString(); 
                    ddlCategorias.SelectedValue = articulo.Categoria.Id.ToString(); 
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtStock.Text = articulo.Stock.ToString();
                    txtAlto.Text = articulo.Alto.ToString();
                    txtAncho.Text = articulo.Ancho.ToString();
                    txtColor.Text = articulo.Color;
                    txtModelo.Text = articulo.Modelo;
                    txtOrigen.Text = articulo.Origen;
                    txtPeso.Text = articulo.Peso.ToString();
                    txtGarantiaAnios.Text = articulo.Garantia_Anios.ToString();
                    txtGarantiaMeses.Text = articulo.Garantia_Meses.ToString();

                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                }
                else
                {
                    lblMensaje.Text = "El artículo con ID " + articuloId + " no existe.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar el artículo: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int articuloId = Convert.ToInt32(Request.QueryString["id"]);

                var articulo = new ArticuloEntity
                {
                    Id = articuloId,
                    CodArticulo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Marca = new MarcaEntity { Id = Convert.ToInt32(ddlMarcas.SelectedValue) },
                    Categoria = new CategoriaEntity { Id = Convert.ToInt32(ddlCategorias.SelectedValue) },
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    Alto = Convert.ToDecimal(txtAlto.Text),
                    Ancho = Convert.ToDecimal(txtAncho.Text),
                    Color = txtColor.Text,
                    Modelo = txtModelo.Text,
                    Origen = txtOrigen.Text,
                    Peso = Convert.ToDecimal(txtPeso.Text),
                    Garantia_Anios = Convert.ToInt32(txtGarantiaAnios.Text),
                    Garantia_Meses = Convert.ToInt32(txtGarantiaMeses.Text),
                    Imagenes = new List<ImagenEntity>() 
                };

                int resultado = articuloBusiness.ModificarArticuloCompleto(articulo);

                if (resultado > 0)
                {
                    lblMensaje.Text = "Artículo actualizado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Articulo.aspx");
        }
    }
}
