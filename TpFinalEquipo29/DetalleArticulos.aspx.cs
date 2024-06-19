using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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


        private bool CargarImagen(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch
            {
                return false;
            }
        }

        private void CargarDetallesArticulo(int id)
        {
            var articuloBusiness = new ArticuloBusiness();
            try
            {
                listArticulos = articuloBusiness.GetArticulos();
                var listImagenesArt = articuloBusiness.GetImagenes();

                foreach (var item in listImagenesArt)
                {
                    if (!CargarImagen(item.UrlImagen))
                    {
                        item.UrlImagen = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais";
                    }
                }

                var agruparImagenes = listImagenesArt.GroupBy(s => s.ArticuloId);

                foreach (var item in agruparImagenes)
                {
                    var articulo = listArticulos.FirstOrDefault(a => a.Id == item.Key);
                    if (articulo != null)
                    {
                        articulo.Imagenes = item.ToList();
                    }
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

                    btnAgregarDetalle.CommandArgument = articuloSeleccionado.Id.ToString();
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
                if (i == 0)
                    result += "<div class=\"carousel-item active\">";
                else
                    result += "<div class=\"carousel-item\">";
                result += "<img class=\"d-block w-100\" src=\"" + imagenes[i].UrlImagen + "\" alt=\"Imagen " + (i + 1) + "\">";
                result += "</div>";
            }
            return result;
        }

        private void ActualizarCarrito()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                var articulosSeleccionados = (List<ArticuloEntity>)Session["articulosSeleccionados"];

                int totalItems = 0;

                foreach (var item in articulosSeleccionados)
                {
                    totalItems += item.Cantidad;
                }

                string script = $"document.getElementById('cartItemCount').innerText = '{totalItems}';";
                ScriptManager.RegisterStartupScript(this, GetType(), "updateCartCount", script, true);
            }
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            var linkButton = sender as LinkButton;
            if (linkButton != null)
            {
                if (int.TryParse(linkButton.CommandArgument, out int articuloId))
                {
                    var articuloBusinees = new ArticuloBusiness();

                    try
                    {
                        listArticulos = articuloBusinees.GetArticulos();

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

                            articulosSeleccionados.Add(articulo);
                            Session["articulosSeleccionados"] = articulosSeleccionados;

                            string script = "Swal.fire({ title: 'Éxito', text: 'Artículo agregado correctamente al carrito.', icon: 'success', confirmButtonText: 'OK' });";
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ocurrió un error al intentar obtener los artículos: " + ex.Message);
                    }
                }
            }

            ActualizarCarrito();
        }
    }
}