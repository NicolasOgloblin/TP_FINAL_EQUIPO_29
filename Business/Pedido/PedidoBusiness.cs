using Dao.Implements;
using Domain.Entities;
using System;
using System.Collections.Generic;

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

        public List<PedidoEntity> ObtenerHistorialCompras(long usuarioId)
        {
            PedidoImp pedidoImp = new PedidoImp();
            return pedidoImp.ObtenerHistorialCompras(usuarioId);
        }



        private UsuarioEntity ObtenerUsuarioPorId(long usuarioid)
        {
            var usuarioDao = new UsuarioImp();
            try
            {

                var usuario = usuarioDao.ObtenerUsuarioPorId(usuarioid);


                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener usuario por ID.", ex);
            }
        }
    }
}