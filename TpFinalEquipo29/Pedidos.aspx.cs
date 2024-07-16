using Business.Pedido;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private void CargarPedidos()
        {
            var pedidoBusiness = new PedidoBusiness();
            try
            {
                var pedidos = pedidoBusiness.GetPedidos();

                foreach(var pedido in pedidos)
                {
                    if (pedido.EstadoPedido.StartsWith("E"))
                    {
                        pedido.Pagado = true;
                    }
                    else
                    {
                        pedido.Pagado = false;
                    }
                }

                gvPedidos.DataSource = pedidos;
                gvPedidos.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo salio mal: " + ex.Message);
            }
            
        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int pedidoId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;

                CheckBox chkPagado = row.FindControl("chkPagado") as CheckBox;
                bool pagado = chkPagado.Checked;

                // Aquí puedes actualizar el estado de pago en la base de datos
                ActualizarEstadoPagado(pedidoId, pagado);

                // Recargar los pedidos para reflejar los cambios
                CargarPedidos();
            }
        }

        private void ActualizarEstadoPagado(int pedidoId, bool pagado)
        {
            // Implementa la lógica para actualizar el estado de pagado en la base de datos
            // Este es solo un ejemplo
            // Actualizar la base de datos con el nuevo estado de pagado
            // ...
        }

    }
}