using Business.Articulo;
using Business.Pedido;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TpFinalEquipo29
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                ActualizarCarrito();

                bool carritoVacio = EsCarritoVacio();
                btnFinalizarCompra.Visible = !carritoVacio;
            }
        }
        private bool EsCarritoVacio()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                return carrito.Count == 0;
            }
            return true;
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

        private void BindGrid()
        {
            var articuloBusiness = new ArticuloBusiness();
            try
            {
                if (Session["articulosSeleccionados"] != null)
                {
                    List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];

                    foreach (var item in carrito)
                    {
                        item.Stock = articuloBusiness.GetReservaStock(item.Id);
                        item.Imagenes = articuloBusiness.getImagenByID(item.Id); // Mover aquí
                    }

                    gvCarrito.DataSource = carrito;
                    gvCarrito.DataBind();

                    decimal total = 0;

                    foreach (var item in carrito)
                    {
                        total += item.Precio * item.Stock;
                    }

                    lblTotal.Text = "Total: " + total.ToString("C");
                    btnFinalizarCompra.Visible = carrito.Count > 0;
                }
                else
                {
                    lblTotal.Text = "Total: $0.00";
                    btnFinalizarCompra.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema: " + ex.Message);
            }
        }

        protected void btnIncrementar_Click(object sender, EventArgs e)
        {
            var articuloBusiness = new ArticuloBusiness();

            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);

            var carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
            var articulo = carrito.FirstOrDefault(a => a.Id == articuloId);

            var stockActual = articuloBusiness.getByCodArt(articulo.CodArticulo);
            try
            {
                if (stockActual.Stock > 0)
                {
                    var usuarioLogueado = (UsuarioEntity)Session["Login"];
                    var reservado = articuloBusiness.ReservarStock(articulo, usuarioLogueado.Id);

                    if (articulo != null)
                    {

                        Session["articulosSeleccionados"] = carrito;
                        BindGrid();
                    }

                    if (reservado > 0)
                    {
                        ActualizarCarrito();
                    }
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un problema: " +  ex.Message);
            }
        }

        protected void btnDecrementar_Click(object sender, EventArgs e)
        {
            var articuloBusiness = new ArticuloBusiness();

            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);

            var carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
            var articulo = carrito.FirstOrDefault(a => a.Id == articuloId);

            int stockActual = articuloBusiness.GetReservaStock(articulo.Id);
            var usuarioLogueado = (UsuarioEntity)Session["Login"];

            if (stockActual == 1)
            {
                articuloBusiness.EliminarStock(articulo, usuarioLogueado.Id);
                carrito.Remove(articulo);
                Session["articulosSeleccionados"] = carrito;
                BindGrid();
                return;
            }

            try
            {
                if (stockActual > 1)
                {
                    
                    var reservado = articuloBusiness.DevolverStock(articulo, usuarioLogueado.Id);

                    if (articulo != null)
                    {

                        Session["articulosSeleccionados"] = carrito;
                        BindGrid();
                    }

                    if (reservado > 0)
                    {
                        ActualizarCarrito();
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema: " + ex.Message);
            }
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
         {
            var pedidoBusiness = new PedidoBusiness();

            decimal total = 0;
            var usuarioLogueado = (UsuarioEntity)Session["Login"];
            var carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];

            try
            {
                var pedido = new PedidoEntity();
                pedido.UsuarioId = usuarioLogueado.Id;
                pedido.FechaPedido = DateTime.Now;
                pedido.Detalles = new List<PedidoDetalleEntity>(); // Inicializar Detalles

                foreach (var item in carrito)
                {
                    total += item.Precio * item.Stock;

                    var pedidoDetalle = new PedidoDetalleEntity();
                    pedidoDetalle.ArticuloId = item.Id;
                    pedidoDetalle.Cantidad = item.Stock;
                    pedidoDetalle.PrecioUnitario = item.Precio;
                    pedido.Detalles.Add(pedidoDetalle);
                }

                pedido.MontoTotal = total;
                pedido.Envio = false;
                pedido.EstadoPedidoid = 1;
                var result = pedidoBusiness.AgregarPedido(pedido, usuarioLogueado.Id);
                Session["articulosSeleccionados"] = carrito;

                Response.Redirect("ProcesandoPedido.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un problema: " + ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);
            var articuloBusiness = new ArticuloBusiness();

            try
            {
                if (Session["articulosSeleccionados"] != null)
                {
                    List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                    ArticuloEntity articulo = carrito.FirstOrDefault(a => a.Id == articuloId);

                    if (articulo != null)
                    {
                        var usuarioLogueado = (UsuarioEntity)Session["Login"];
                        articuloBusiness.EliminarStock(articulo, usuarioLogueado.Id);
                        carrito.Remove(articulo);
                        Session["articulosSeleccionados"] = carrito;
                        BindGrid();
                    }
                }

                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema: " + ex.Message);
            }
            
        }

    }
}