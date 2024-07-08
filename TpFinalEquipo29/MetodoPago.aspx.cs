using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class MetodoPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí obtienes el monto total desde donde lo tengas almacenado (por ejemplo, en una variable de sesión o base de datos)
                decimal montoTotal = ObtenerMontoTotal(); // Implementa este método según donde esté almacenado el monto total

                // Mostrar el monto total en el Label
                lblMontoTotal.Text = $"${montoTotal.ToString("0.00")}"; // Formato de ejemplo: $123.45
            }
        }

        protected void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado del RadioButtonList
            string metodoPago = rbMetodoPago.SelectedValue;

            // Aquí puedes almacenar el método de pago seleccionado para uso posterior
            Session["MetodoPago"] = metodoPago;

            // Redirigir a la siguiente página según tu flujo de compra
            Response.Redirect("FinalizarCompra.aspx");
        }

        private decimal ObtenerMontoTotal()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                decimal montoTotal = carrito.Sum(a => a.Precio * a.Stock); // Asumiendo que "Stock" refleja la cantidad seleccionada
                return montoTotal;
            }
            return 0; // Manejo de caso cuando no hay artículos en el carrito o está vacío
        }

    }
}