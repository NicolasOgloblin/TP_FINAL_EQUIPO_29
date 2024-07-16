using Business.Articulo;
using Business.Pedido;
using Domain.Entities;
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
                    if ((bool)pedido.Envio)
                    {
                        pedido.EnvioPedido = "SI";
                    }
                    else
                    {
                        pedido.EnvioPedido = "NO";
                    }

                    if (pedido.EstadoPedido.StartsWith("E"))
                    {
                        pedido.Entregado = true;
                        pedido.Despachado = true;
                    }
                    else if(pedido.EstadoPedido.StartsWith("D"))
                    {
                        pedido.Entregado = false;
                        pedido.Despachado = true;
                    }
                    else
                    {
                        pedido.Entregado = false;
                        pedido.Despachado = false;
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
            if (e.CommandName == "Entregado")
            {
                long usuarioId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;

                long pedidoId = long.Parse(row.Cells[0].Text);

                ActualizarEstadoPagado(usuarioId, pedidoId, 3);
                
                CargarPedidos();
            }

            if (e.CommandName == "Despachado")
            {
                long usuarioId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;

                long pedidoId = long.Parse(row.Cells[0].Text);

                ActualizarEstadoPagado(usuarioId, pedidoId, 2);

                CargarPedidos();
            }
        }

        private void ActualizarEstadoPagado(long usuarioId, long pedidoId , short estado)
        {
            var articuloBusiness = new ArticuloBusiness();
            var pedidoBusiness = new PedidoBusiness();
            try
            {
                var pedido = new PedidoEntity();
                pedido.Id = pedidoId;
                pedido.EstadoPedidoid = estado;
                if(estado == 3)
                {
                    articuloBusiness.FinalizarStock(usuarioId);
                    pedidoBusiness.ModificarPedido(pedido);
                }
                else if(estado == 2)
                {
                    pedidoBusiness.ModificarPedido(pedido);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Algo salio mal: " + ex.Message);
            }
        }

    }
}