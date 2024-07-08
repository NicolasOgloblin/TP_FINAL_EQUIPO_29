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
               
            }
        }

        protected void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            
            string formaEntrega = rbFormaEntrega.SelectedValue;

            
            ViewState["FormaEntrega"] = formaEntrega;

            
            switch (formaEntrega)
            {
                case "encuentro":
                    
                    Response.Redirect("PuntoEncuentro.aspx");
                    break;
                case "tienda":
                    
                    Response.Redirect("RetiroTienda.aspx");
                    break;
                case "domicilio":
                    
                    Response.Redirect("MisDirecciones.aspx");
                    break;
                default:
                   
                    break;
            }

        }
    }
}