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
                var articulosSeleccionados = (List<ArticuloEntity>)Session["articulosSeleccionados"];

                int totalItems = 0;

                foreach (var item in articulosSeleccionados)
                {
                    totalItems += 1;
                }

                string script = $"document.getElementById('cartItemCount').innerText = '{totalItems}';";
                ScriptManager.RegisterStartupScript(this, GetType(), "updateCartCount", script, true);
            }
        }

        private void BindGrid()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                gvCarrito.DataSource = carrito;
                gvCarrito.DataBind();

                decimal total = 0;

                foreach (var item in carrito)
                {
                    total += item.Precio * 1;
                }

                lblTotal.Text = "Total: " + total.ToString("C");
            }
            else
            {
                lblTotal.Text = "Total: $0.00";
            }
        }

        protected void btnIncrementar_Click(object sender, EventArgs e)
        {

            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);

            var carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
            var articulo = carrito.FirstOrDefault(a => a.Id == articuloId);

            if (articulo != null)
            {
                Session["articulosSeleccionados"] = carrito;
                BindGrid();
            }

            ActualizarCarrito();
        }

        protected void btnDecrementar_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);

            var carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
            var articulo = carrito.FirstOrDefault(a => a.Id == articuloId);

            if (articulo != null)
            {
                
                Session["articulosSeleccionados"] = carrito;
                BindGrid();
            }

            ActualizarCarrito();
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