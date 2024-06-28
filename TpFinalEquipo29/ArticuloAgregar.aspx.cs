using Business;
using Business.Articulo;
using Business.Marca;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class ArticuloAgregar : System.Web.UI.Page
    {

        private ArticuloBusiness articuloBusinessAgregar;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            articuloBusinessAgregar = new ArticuloBusiness();
            if (!IsPostBack)
            {
                CargarDropDownListCategorias();
                CargarDropDownListMarcas();
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
                    decimal pesoArticulo = Convert.ToDecimal(txtPeso.Text);
                    decimal anchoArticulo = Convert.ToDecimal(txtAncho.Text);
                    decimal altoArticulo = Convert.ToDecimal(txtAlto.Text);
                    string colorArticulo = txtColor.Text;
                    string modeloArticulo = txtModelo.Text;
                    string origenArticulo = txtOrigen.Text;
                    int garantiaAnios = Convert.ToInt32(txtGarantiaAnios.Text);
                    int garantiaMeses = Convert.ToInt32(txtGarantiaMeses.Text);

                    if (articuloBusinessAgregar.ArticuloExiste(codigoArticulo))
                    {
                        lblMensaje.Text = "El artículo ya existe.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    var nuevoArticulo = new ArticuloEntity
                    {
                        CodArticulo = codigoArticulo,
                        Nombre = nombreArticulo,
                        Descripcion = descripcionArticulo,
                        Categoria = new CategoriaEntity { Id = categoriaId },
                        Marca = new MarcaEntity { Id = marcaId },
                        Precio = precioArticulo,
                        Stock = stockArticulo,
                        Peso = pesoArticulo,
                        Ancho = anchoArticulo,
                        Alto = altoArticulo,
                        Color = colorArticulo,
                        Modelo = modeloArticulo,
                        Origen = origenArticulo,
                        Garantia_Anios = garantiaAnios,
                        Garantia_Meses = garantiaMeses,
                        Imagenes = new List<ImagenEntity>()
                    };

                    int resultado = articuloBusinessAgregar.agregarArticulo(nuevoArticulo);

                    if (resultado > 0)
                    {
                        var articuloAgregado = articuloBusinessAgregar.getByCodArt(nuevoArticulo.CodArticulo);

                        if (fuImagenes.HasFiles)
                        {
                            ImagenEntity imagen = null;
                            foreach (var uploadedFile in fuImagenes.PostedFiles)
                            {
                                // Guardar el archivo en el servidor
                                string filePath = Server.MapPath("~/Imagenes/") + uploadedFile.FileName;
                                uploadedFile.SaveAs(filePath);

                                // Agregar la URL de la imagen a la lista
                                imagen = new ImagenEntity();
                                imagen.ArticuloId = articuloAgregado.Id;
                                imagen.UrlImagen = uploadedFile.FileName;
                                nuevoArticulo.Imagenes.Add(imagen);
                            }
                        }

                        resultado = articuloBusinessAgregar.AgregarImagenes(nuevoArticulo.Imagenes);

                        lblMensaje.Text = "Artículo agregado exitosamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        LimpiarCampos();
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
            ddlMarcas.Items.Insert(0, new ListItem("--Seleccione--", "0"));
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
            txtPeso.Text = string.Empty;
            txtAncho.Text = string.Empty;
            txtAlto.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtOrigen.Text = string.Empty;
            txtGarantiaAnios.Text = string.Empty;
            txtGarantiaMeses.Text = string.Empty;
        }
            
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Gestion.aspx");
        }
    }
}
