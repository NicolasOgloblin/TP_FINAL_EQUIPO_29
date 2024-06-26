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

            private List<string> imagenesUrls
            {
                get
                {
                    if (ViewState["ImagenesUrls"] == null)
                    {
                        ViewState["ImagenesUrls"] = new List<string>();
                    }
                    return (List<string>)ViewState["ImagenesUrls"];
                }
                set
                {
                    ViewState["ImagenesUrls"] = value;
                }
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                articuloBusinessAgregar = new ArticuloBusiness();
                if (!IsPostBack)
                {
                    CargarDropDownListCategorias();
                    CargarDropDownListMarcas();
                   // CargarArticulos();
                }
            }

            protected void btnAgregarImagen_Click(object sender, EventArgs e)
            {
                string urlImagen = txtUrlImagen.Text;
                if (!string.IsNullOrEmpty(urlImagen))
                {
                    imagenesUrls.Add(urlImagen);
                    txtUrlImagen.Text = "";
                    lblMensaje.Text = "Imagen agregada a la lista temporal.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "La URL de la imagen no puede estar vacía.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
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


                        foreach (var url in imagenesUrls)
                        {
                            nuevoArticulo.Imagenes.Add(new ImagenEntity { UrlImagen = url });
                        }

                        int resultado = articuloBusinessAgregar.agregarArticulo(nuevoArticulo);

                        if (resultado > 0)
                        {
                            GuardarArticuloEnSesion(nuevoArticulo);

                            lblMensaje.Text = "Artículo agregado exitosamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                            LimpiarCampos();
                            CargarArticulos();
                            imagenesUrls.Clear();

                        
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

        private void GuardarArticuloEnSesion(ArticuloEntity articulo)
        {
            // Obtener la lista actual de artículos de la sesión
            List<ArticuloEntity> articulosEnSesion = ObtenerArticulosDesdeSesion();

            // Agregar el nuevo artículo a la lista
            articulosEnSesion.Add(articulo);

            // Guardar la lista actualizada en la sesión
            Session["Articulos"] = articulosEnSesion;
        }

        private List<ArticuloEntity> ObtenerArticulosDesdeSesion()
        {
            if (Session["Articulos"] == null)
            {
                Session["Articulos"] = new List<ArticuloEntity>();
            }
            return (List<ArticuloEntity>)Session["Articulos"];
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
        
            private void CargarArticulos()
            {
                try
                {
                    var articulos = articuloBusinessAgregar.GetArticulos();

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
                txtPeso.Text = string.Empty;
                txtAncho.Text = string.Empty;
                txtAlto.Text = string.Empty;
                txtColor.Text = string.Empty;
                txtModelo.Text = string.Empty;
                txtOrigen.Text = string.Empty;
                txtGarantiaAnios.Text = string.Empty;
                txtGarantiaMeses.Text = string.Empty;
                txtUrlImagen.Text = string.Empty;
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
                    TextBox txtDescripcion = (TextBox)row.FindControl("txtDescripcion");
                    DropDownList ddlMarcas = (DropDownList)row.FindControl("ddlMarcas");
                    DropDownList ddlCategorias = (DropDownList)row.FindControl("ddlCategorias");
                    TextBox txtPrecio = (TextBox)row.FindControl("txtPrecio");
                    TextBox txtStock = (TextBox)row.FindControl("txtStock");


                    TextBox txtAlto = (TextBox)row.FindControl("txtAlto");
                    TextBox txtAncho = (TextBox)row.FindControl("txtAncho");
                    TextBox txtColor = (TextBox)row.FindControl("txtColor");
                    TextBox txtModelo = (TextBox)row.FindControl("txtModelo");
                    TextBox txtOrigen = (TextBox)row.FindControl("txtOrigen");
                    TextBox txtPeso = (TextBox)row.FindControl("txtPeso");
                    TextBox txtGarantiaAnios = (TextBox)row.FindControl("txtGarantiaAnios");
                    TextBox txtGarantiaMeses = (TextBox)row.FindControl("txtGarantiaMeses");


                    string codigo = txtCodigo.Text;
                    string nombre = txtNombre.Text;
                    string descripcion = txtDescripcion.Text;
                    int marcaId = Convert.ToInt32(ddlMarcas.SelectedValue);
                    int categoriaId = Convert.ToInt32(ddlCategorias.SelectedValue);
                    decimal precio = Convert.ToDecimal(txtPrecio.Text);
                    int stock = Convert.ToInt32(txtStock.Text);


                    decimal alto = Convert.ToDecimal(txtAlto.Text);
                    decimal ancho = Convert.ToDecimal(txtAncho.Text);
                    string color = txtColor.Text;
                    string modelo = txtModelo.Text;
                    string origen = txtOrigen.Text;
                    decimal peso = Convert.ToDecimal(txtPeso.Text);
                    int garantiaAnios = Convert.ToInt32(txtGarantiaAnios.Text);
                    int garantiaMeses = Convert.ToInt32(txtGarantiaMeses.Text);

                    var articulo = new ArticuloEntity
                    {
                        Id = id,
                        CodArticulo = codigo,
                        Nombre = nombre,
                        Descripcion = descripcion,
                        Marca = new MarcaEntity { Id = marcaId },
                        Categoria = new CategoriaEntity { Id = categoriaId },
                        Precio = precio,
                        Stock = stock,
                        Alto = alto,
                        Ancho = ancho,
                        Color = color,
                        Modelo = modelo,
                        Origen = origen,
                        Peso = peso,
                        Garantia_Anios = garantiaAnios,
                        Garantia_Meses = garantiaMeses
                    };


                    int resultado = articuloBusinessAgregar.ModificarArticulo(articulo);


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
                    bool resultado = articuloBusinessAgregar.Eliminar(id);

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
        }
    }
