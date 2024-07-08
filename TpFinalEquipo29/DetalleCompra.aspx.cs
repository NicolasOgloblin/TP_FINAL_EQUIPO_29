using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class DetalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["FormaEntrega"] != null)
                    {
                        string formaEntrega = Session["FormaEntrega"].ToString();
                        lblFormaEntrega.Text = ObtenerTextoFormaEntrega(formaEntrega); // Define una función para obtener el texto completo según la forma de entrega
                    }

                    if (Session["MetodoPago"] != null)
                    {
                        string metodoPago = Session["MetodoPago"].ToString();
                        lblMetodoPago.Text = metodoPago;
                    }
                }
            }

        }
            private string ObtenerTextoFormaEntrega(string formaEntrega)
            {
                switch (formaEntrega)
                {
                    case "encuentro":
                        return "Punto de encuentro - Plaza de San Miguel (Gratis)";
                    case "tienda":
                        return "Retiro en la tienda - Tribulato 905, San Miguel (Gratis)";
                    case "domicilio":
                        return "Envío a domicilio - Tu dirección (Costo adicional $3,500)";
                    default:
                        return "";
                }
            }
            protected void btnModificarEntrega_Click(object sender, EventArgs e)
            {
                // Aquí implementa la lógica para permitir al usuario modificar la forma de entrega.
                // Puedes redirigir a la página de FormaEntrega.aspx para que seleccione de nuevo.
                Response.Redirect("~/FormaEntrega.aspx");
            }

            protected void btnModificarPago_Click(object sender, EventArgs e)
            {
                // Aquí implementa la lógica para permitir al usuario modificar el método de pago.
                // Puedes redirigir a la página de MetodoPago.aspx para que seleccione de nuevo.
                Response.Redirect("~/MetodoPago.aspx");
            }

            protected void btnConfirmarCompra_Click(object sender, EventArgs e)
            {
                // Aquí implementa la lógica para confirmar la compra.
                // Puedes finalizar la compra, guardar los detalles en la base de datos, etc.
                // Luego redirige a una página de confirmación o de finalización de compra.
                Response.Redirect("~/FinalizarCompra.aspx");
            }


        }
    }
