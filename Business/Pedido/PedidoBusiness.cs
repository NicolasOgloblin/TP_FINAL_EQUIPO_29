using Business.Articulo;
using Dao.Implements;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Business.Pedido
{
    public class PedidoBusiness
    {
        public long AgregarPedido(PedidoEntity pedido, long usuarioId)
        {
            PedidoImp pedidoImp = new PedidoImp();
            try
            {
                var result = pedidoImp.AgregarPedido(pedido, usuarioId);

                if (result > 0)
                {
                    pedido.Id = result;
                    result = pedidoImp.AgregarDetallePedido(pedido);

                    if(result == 1)
                    {
                        return pedido.Id;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoEntity> GetPedidos()
        {
            PedidoImp pedidoImp = new PedidoImp();
            try
            {
                return pedidoImp.GetPedidos();
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

        public int ModificarPedido(PedidoEntity pedido)
        {
            PedidoImp pedidoImp = new PedidoImp();
            try
            {
                return pedidoImp.ModificarPedido(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public List<ImagenEntity> ObtenerImagenesArticulo(long articuloId)
        {
            ArticuloBusiness articuloBusiness = new ArticuloBusiness();
            return articuloBusiness.getImagenByID(articuloId);
        }
    }
}
