using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{

    public partial class DetalleArticulos : Page
    {
        private List<ArticuloEntity> listArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string articuloID = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(articuloID))
                {
                    CargarDetallesArticulo(int.Parse(articuloID));

                    panelFichaTecnica.Visible = true;
                }
                else
                {

                    panelFichaTecnica.Visible = false;
                }

                ActualizarCarrito();
            }


        }

        private void CargarDetallesArticulo(int id)
        {
            var articuloBusiness = new ArticuloBusiness();
            try
            {
                listArticulos = articuloBusiness.GetArticulos();
                
                foreach (var item in listArticulos)
                {
                    item.Imagenes = articuloBusiness.getImagenByID(item.Id);
                }

                var articuloSeleccionado = listArticulos.FirstOrDefault(a => a.Id == id);

                if (articuloSeleccionado != null)
                {
                    litNombre.Text = articuloSeleccionado.Nombre;
                    litPrecio.Text = articuloSeleccionado.Precio.ToString("F2");

                    litCarouselIndicators.Text = GenerarIndicadoresCarrusel(articuloSeleccionado.Imagenes.Count);
                    litCarouselImages.Text = GenerarImagenesCarrusel(articuloSeleccionado.Imagenes);

                    litMarca.Text = articuloSeleccionado.Marca.Nombre;
                    litCategoria.Text = articuloSeleccionado.Categoria.Nombre;
                    litDescripcion.Text = articuloSeleccionado.Descripcion;
                    LitAlto.Text = articuloSeleccionado.Alto.ToString();
                    LitPeso.Text = articuloSeleccionado.Peso.ToString();
                    LitAncho.Text = articuloSeleccionado.Ancho.ToString();
                    LitColor.Text = articuloSeleccionado.Color.ToString();
                    LitModelo.Text = articuloSeleccionado.Modelo.ToString();
                    LitOrigen.Text = articuloSeleccionado.Origen.ToString();
                    LitGarantia.Text = articuloSeleccionado.Garantia_Meses.ToString();

                    btnAgregarDetalle.CommandArgument = articuloSeleccionado.Id.ToString();

                    StringBuilder indicators = new StringBuilder();
                    StringBuilder images = new StringBuilder();

                    for (int i = 0; i < articuloSeleccionado.Imagenes.Count; i++)
                    {
                        string activeClass = i == 0 ? "active" : "";

                        // Indicadores del carrusel
                        indicators.AppendFormat("<button type=\"button\" data-bs-target=\"#carouselExampleIndicators\" data-bs-slide-to=\"{0}\" class=\"{1}\" aria-current=\"true\" aria-label=\"Slide {2}\"></button>", i, activeClass, i + 1);

                        // Imágenes del carrusel
                        images.AppendFormat("<div class=\"carousel-item {0}\">", activeClass);
                        images.AppendFormat("<img src=\"{0}\" class=\"d-block w-100\" alt=\"Imagen {1}\">", ResolveUrl("~/Imagenes/" + articuloSeleccionado.Imagenes[i].UrlImagen), i + 1);
                        images.Append("</div>");
                    }

                    litCarouselIndicators.Text = indicators.ToString();
                    litCarouselImages.Text = images.ToString();

                }
                else
                {
                    litNombre.Text = "Artículo no encontrado";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener los artículos: " + ex.Message);
            }
        }

        private string GenerarIndicadoresCarrusel(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                    result += "<li data-target=\"#carouselExampleIndicators\" data-slide-to=\"" + i + "\" class=\"active\"></li>";
                else
                    result += "<li data-target=\"#carouselExampleIndicators\" data-slide-to=\"" + i + "\"></li>";
            }
            return result;
        }

        private string GenerarImagenesCarrusel(List<ImagenEntity> imagenes)
        {
            string result = "";
            for (int i = 0; i < imagenes.Count; i++)
            {
                string activeClass = i == 0 ? "active" : "";
                result += $"<div class=\"carousel-item {activeClass}\">";
                result += $"<img class=\"d-block w-100\" src=\"{ResolveUrl("~/Imagenes/" + imagenes[i].UrlImagen)}\" alt=\"Imagen {i + 1}\">";
                result += "</div>";
            }
            return result;
        }

        private void ActualizarCarrito()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                var articuloBusiness = new ArticuloBusiness();

                var articulosSeleccionados = (List<ArticuloEntity>)Session["articulosSeleccionados"];

                int totalItems = 0;

                foreach (var item in articulosSeleccionados)
                {
                    try
                    {
                        totalItems += articuloBusiness.GetReservaStock(item.Id);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ocurrio un error al intentar actualizar el carrito: " + ex.Message);
                    }
                }

                string script = $"document.getElementById('cartItemCount').innerText = '{totalItems}';";
                ScriptManager.RegisterStartupScript(this, GetType(), "updateCartCount", script, true);
            }
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            var linkButton = sender as LinkButton;
            string script = string.Empty;
            var articuloBusiness = new ArticuloBusiness();

            if (linkButton != null)
            {
                if (int.TryParse(linkButton.CommandArgument, out int articuloId))
                {
                    try
                    {
                        listArticulos = articuloBusiness.GetArticulos();

                        var articulo = listArticulos.FirstOrDefault(s => s.Id == articuloId);
                        if (articulo != null)
                        {
                            List<ArticuloEntity> articulosSeleccionados;
                            if (Session["articulosSeleccionados"] == null)
                            {
                                articulosSeleccionados = new List<ArticuloEntity>();
                            }
                            else
                            {
                                articulosSeleccionados = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                            }

                            if (articulosSeleccionados.Where(s => s.Id == articulo.Id).Count() > 0)
                            {
                                Session["articulosSeleccionados"] = articulosSeleccionados;
                                ActualizarCarrito();
                                return;
                            }

                            articulosSeleccionados.Add(articulo);
                            Session["articulosSeleccionados"] = articulosSeleccionados;

                            var usuarioLogueado = (UsuarioEntity)Session["Login"];
                            var reservado = articuloBusiness.ReservarStock(articulo, usuarioLogueado.Id);
                            if (reservado > 0)
                            {
                                ActualizarCarrito();
                            }

                            script = "Swal.fire({ title: 'Éxito', text: 'Artículo agregado correctamente al carrito.', icon: 'success', confirmButtonText: 'OK' });";
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ocurrió un error al intentar obtener los artículos: " + ex.Message);
                    }
                }
            }
        }

    }
}