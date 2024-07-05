using Dao.Implements;
using Domain.Entities;
using System;

namespace Business.Pedido
{
    public class PedidoBusiness
    {
        public int AgregarPedido(PedidoEntity pedido, long usuarioId)
        {
            PedidoImp pedidoImp = new PedidoImp();
            try
            {
                var result = pedidoImp.AgregarPedido(pedido, usuarioId);

                if (result > 0)
                {
                    pedido.Id = result;
                    return pedidoImp.AgregarDetallePedido(pedido);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
