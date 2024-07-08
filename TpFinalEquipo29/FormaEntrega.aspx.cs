using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class FormaEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Puedes inicializar aquí cualquier lógica que necesites al cargar la página por primera vez
            }
        }

        protected void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado del RadioButtonList
            string formaEntrega = rbFormaEntrega.SelectedValue;

            // Guardar el valor en ViewState para usarlo posteriormente
            ViewState["FormaEntrega"] = formaEntrega;

            // Redirigir a la página de método de pago
            Response.Redirect("MetodoPago.aspx");
        }


    }
}