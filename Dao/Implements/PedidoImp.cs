using Dao.DataAccessObject;
using Domain.Entities;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Dao.Implements
{
    public class PedidoImp
    {
        public int AgregarPedido(PedidoEntity pedido, long usuarioId)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"
                                INSERT INTO PEDIDO
                                VALUES(@usuarioId,@fechaPedido,@montoTotal,0) SELECT SCOPE_IDENTITY() AS ID";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuarioId", usuarioId);
                datos.setearParametro("@fechaPedido", pedido.FechaPedido);
                datos.setearParametro("@montoTotal", pedido.MontoTotal);
                
                var result = datos.ejecutarScalar();

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int AgregarDetallePedido(PedidoEntity pedido)
        {
            #region Consulta
            string consulta = @"INSERT INTO PEDIDO_DETALLE
                                VALUES(@pedidoId,@articuloId,@cantidad,@precioUnitario)";
            #endregion

            try
            {
                foreach (var detalle in pedido.Detalles)
                {

                    DataAccess datos = new DataAccess();
                    try
                    {
                        datos.setearConsulta(consulta);
                        datos.setearParametro("@pedidoId", pedido.Id);
                        datos.setearParametro("@articuloId", detalle.ArticuloId);
                        datos.setearParametro("@cantidad", detalle.Cantidad);
                        datos.setearParametro("@precioUnitario", detalle.PrecioUnitario);

                        datos.ejecutarAccion();
                    }
                    finally
                    {
                        datos.cerrarConexion();
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
