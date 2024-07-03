using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }
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
                    }

                    gvCarrito.DataSource = carrito;
                    gvCarrito.DataBind();

                    decimal total = 0;

                    foreach (var item in carrito)
                    {
                        total += item.Precio * item.Stock;
                    }

                    lblTotal.Text = "Total: " + total.ToString("C");
                }
                else
                {
                    lblTotal.Text = "Total: $0.00";
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
                    if (articulo != null)
                    {

                        Session["articulosSeleccionados"] = carrito;
                        BindGrid();
                    }

                    var usuarioLogueado = (UsuarioEntity)Session["Login"];
                    var reservado = articuloBusiness.ReservarStock(articulo, usuarioLogueado.Id);
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

            var stockActual = articuloBusiness.getByCodArt(articulo.CodArticulo);
            try
            {
                if (stockActual.Stock > 0)
                {
                    if (articulo != null)
                    {

                        Session["articulosSeleccionados"] = carrito;
                        BindGrid();
                    }

                    var usuarioLogueado = (UsuarioEntity)Session["Login"];
                    var reservado = articuloBusiness.DevolverStock(articulo, usuarioLogueado.Id);
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);

            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                ArticuloEntity articulo = carrito.FirstOrDefault(a => a.Id == articuloId);

                if (articulo != null)
                {
                    carrito.Remove(articulo);
                    Session["articulosSeleccionados"] = carrito;
                    BindGrid();
                }
            }

            ActualizarCarrito();
        }

    }
}