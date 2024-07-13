using Business.MetodoPago;
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
                
                lblMontoTotal.Text = $"${montoTotal.ToString("#,##0.00")}";

            }
        }

        protected void btnConfirmarPago_Click(object sender, EventArgs e)
        {
           
            string metodoPago = rbMetodoPago.SelectedValue;

            Session["MetodoPago"] = metodoPago;

            MetodoPagoBusiness metodoPagoBusiness = new MetodoPagoBusiness();

            try
            {
                int idMetodoPago = metodoPagoBusiness.GuardarMetodoPago(metodoPago);
                Session["IdMetodoPago"] = idMetodoPago; 

                Response.Redirect("DetalleCompra.aspx");
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al guardar el método de pago. Por favor, inténtalo nuevamente.";
                lblMensajeError.Visible = true;
            }
        }
        protected void rbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfirmarPago.Enabled = rbMetodoPago.SelectedIndex > -1;
        }

        private decimal ObtenerMontoTotal()
        {
            decimal montoTotal = 0;

            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                montoTotal = carrito.Sum(a => a.Precio * a.Stock);
                
            }

            if (Session["CostoEnvio"] != null)
            {
                montoTotal += (decimal)Session["CostoEnvio"];
            }
            return montoTotal;
        }



    }
}