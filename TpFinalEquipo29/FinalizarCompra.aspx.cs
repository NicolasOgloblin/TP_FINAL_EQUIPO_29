using System;

namespace TpFinalEquipo29
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMisPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MisPedidos.aspx");
        }

    }
}