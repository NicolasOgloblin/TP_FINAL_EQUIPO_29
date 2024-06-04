using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class _Default : Page
    {
        private List<ArticuloEntity> listArticulos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                ddlFiltroPrecio.Items.Insert(0, new ListItem("Seleccionar opción", "0"));
                ddlFiltroPrecio.Items.Add(new ListItem("De menor a mayor precio", "1"));
                ddlFiltroPrecio.Items.Add(new ListItem("De mayor a menor precio", "2"));
                ddlFiltroPrecio.Items[0].Attributes["disabled"] = "disabled";
                ddlFiltroPrecio.Items[0].Selected = true;


                if (!string.IsNullOrEmpty(Request.QueryString["buscar"]))
                {
                    FiltrarArticulos(Request.QueryString["buscar"], 3);
                }
                BindListView();
                GeneratePagination();
            }
        }

        private void BindListView()
        {
            int pageIndex = 0;
            if (Request.QueryString["page"] != null)
            {
                pageIndex = Convert.ToInt32(Request.QueryString["page"]) - 1;
            }

            var pagedDataSource = new PagedDataSource
            {
                DataSource = listArticulos,
                AllowPaging = true,
                PageSize = 8,
                CurrentPageIndex = pageIndex
            };

            dgvArticulos.DataSource = pagedDataSource;
            dgvArticulos.DataBind();
        }

        private void LoadData()
        {
            var articuloBusinees = new ArticuloBusiness();
            try
            {
                listArticulos = articuloBusinees.GetArticulos();

                var listImagenesArt = articuloBusinees.GetImagenes();

                foreach (var item in listImagenesArt)
                {
                    if (!CargarImagen(item.UrlImagen))
                    {
                        item.UrlImagen = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais";
                    }
                }

                var agruparImagenes = listImagenesArt.GroupBy(s => s.ArticuloId);

                foreach(var item in agruparImagenes)
                {
                    foreach(var elmnt in listArticulos)
                    {
                        if(item.Key == elmnt.Id)
                        {
                            elmnt.Imagenes = new List<ImagenEntity>();
                            elmnt.Imagenes = item.ToList();
                        }
                    }
                }

                ViewState["articulos"] = listArticulos;

                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar obtener los articulos: " + ex.Message);
            }
        }

        private void GeneratePagination()
        {
            int totalPages = (int)Math.Ceiling((double)listArticulos.Count / 8);

            StringBuilder paginationHtml = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                string activeClass = i == GetCurrentPageIndex() ? "active" : "";
                paginationHtml.AppendFormat("<li class='page-item {1}'><a class='page-link' href='?page={0}'>{0}</a></li>", i, activeClass);
            }

            litPagination.Text = paginationHtml.ToString();
        }

        private int GetCurrentPageIndex()
        {
            int pageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                pageIndex = Convert.ToInt32(Request.QueryString["page"]);
            }
            return pageIndex;
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

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            string articuloID = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument;
            Response.Redirect("DetalleArticulos.aspx?id=" + articuloID);
        }

        protected void ddlFiltroPrecio_Click(object sender, EventArgs e)
        {

            int valor = int.Parse(ddlFiltroPrecio.SelectedValue);

            if (valor == 0) { return; }

            if (valor == 1 || valor == 2)
            {
                FiltrarArticulos(string.Empty, valor);
            }

            ddlFiltroPrecio.Items[0].Attributes["disabled"] = "disabled";
        }

        private void ActualizarCarrito()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                var articulosSeleccionados = (List<ArticuloEntity>)Session["articulosSeleccionados"];

                int totalItems = 0;

                foreach (var item in articulosSeleccionados)
                {
                    totalItems += item.Stock;
                }

                string script = $"document.getElementById('cartItemCount').innerText = '{totalItems}';";
                ScriptManager.RegisterStartupScript(this, GetType(), "updateCartCount", script, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);
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
                    if (!articulosSeleccionados.Any(a => a.Id == articuloId))
                    {
                        articulosSeleccionados.Add(articulo);
                        Session["articulosSeleccionados"] = articulosSeleccionados;

                        string script = "Swal.fire({ title: 'Éxito', text: 'Artículo agregado correctamente al carrito.', icon: 'success', confirmButtonText: 'OK' });";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                    }
                    else
                    {
                        string script = "Swal.fire({ title: 'Advertencia', text: 'El artículo ya está en el carrito.', icon: 'warning', confirmButtonText: 'OK' });";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                    }
                }

                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener los artículos: " + ex.Message);
            }
        }


        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text;
            FiltrarArticulos(texto, 3);

        }
        
        private void FiltrarArticulos(string terminoBusqueda, int param)
        {
            var articuloBusinees = new ArticuloBusiness();
            var articulosFiltrados = new List<ArticuloEntity>();

            try
            {
                listArticulos = articuloBusinees.GetArticulos();
                switch (param)
                {
                    case 1:
                        articulosFiltrados = listArticulos.OrderBy(s => s.Precio).ToList();
                        foreach (var item in articulosFiltrados)
                        {
                            foreach(var elmnt in item.Imagenes)
                            {
                                if (!CargarImagen(elmnt.UrlImagen))
                                { elmnt.UrlImagen = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais"; }
                            }
                        }
                        break;

                    case 2:
                        articulosFiltrados = listArticulos.OrderByDescending(s => s.Precio).ToList();
                        foreach (var item in articulosFiltrados)
                        {
                            foreach (var elmnt in item.Imagenes)
                            {
                                if (!CargarImagen(elmnt.UrlImagen))
                                { elmnt.UrlImagen = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais"; }
                            }

                        }
                        break;

                    case 3:
                        articulosFiltrados = listArticulos
                                        .Where(a => a.Nombre.IndexOf(terminoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                                        .ToList();

                        foreach (var item in articulosFiltrados)
                        {
                            foreach (var elmnt in item.Imagenes)
                            {
                                if (!CargarImagen(elmnt.UrlImagen))
                                { elmnt.UrlImagen = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais"; }
                            }

                        }
                        break;

                }
                
                // Actualizar el control ListView con los artículos filtrados
                var pagedDataSource = new PagedDataSource
                {
                    DataSource = articulosFiltrados,
                    AllowPaging = true,
                    PageSize = 8,
                    CurrentPageIndex = 0 // Siempre comienza en la primera página después de filtrar
                };

                dgvArticulos.DataSource = pagedDataSource;
                dgvArticulos.DataBind();

                // Generar paginación para los artículos filtrados
                int totalPages = (int)Math.Ceiling((double)articulosFiltrados.Count / 8);
                StringBuilder paginationHtml = new StringBuilder();
                for (int i = 1; i <= totalPages; i++)
                {
                    string activeClass = i == GetCurrentPageIndex() ? "active" : "";
                    paginationHtml.AppendFormat("<li class='page-item {1}'><a class='page-link' href='?page={0}&buscar={2}'>{0}</a></li>", i, activeClass, terminoBusqueda);
                }

                litPagination.Text = paginationHtml.ToString();



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }  
        protected string GetBuscarValue()
        {
            string searchTerm = string.Empty;
            try
            {
                searchTerm = Request.QueryString["buscar"];
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción si ocurre al obtener el valor del QueryString
                Console.WriteLine($"Error al obtener el valor de 'buscar': {ex.Message}");
            }
            return searchTerm;
        }
    }
}