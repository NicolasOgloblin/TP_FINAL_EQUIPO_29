using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TpFinalEquipo29
{
    public partial class MetodoPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal montoTotal = ObtenerMontoTotal();
                
                lblMontoTotal.Text = $"${montoTotal.ToString("0.00")}";

            }
        }

        protected void btnConfirmarPago_Click(object sender, EventArgs e)
        {
           
            string metodoPago = rbMetodoPago.SelectedValue;

            Session["MetodoPago"] = metodoPago;

            Response.Redirect("FinalizarCompra.aspx");
        }

        private decimal ObtenerMontoTotal()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                decimal montoTotal = carrito.Sum(a => a.Precio * a.Stock);
                return montoTotal;
            }
            return 0; 
        }



    }
}