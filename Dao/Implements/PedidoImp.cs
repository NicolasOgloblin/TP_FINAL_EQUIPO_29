using Dao.DataAccessObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                                INSERT INTO PEDIDO (USUARIOID,FECHA_PEDIDO,MONTO_TOTAL,ENVIO,ESTADOPEDIDOID)
                                VALUES(@usuarioId,@fechaPedido,@montoTotal,@envio,@estadopedidoid) SELECT SCOPE_IDENTITY() AS ID";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuarioId", usuarioId);
                datos.setearParametro("@fechaPedido", pedido.FechaPedido);
                datos.setearParametro("@montoTotal", pedido.MontoTotal);
                datos.setearParametro("@envio", pedido.Envio);
                datos.setearParametro("@estadopedidoid", pedido.EstadoPedidoid);

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
            string consulta = @"INSERT INTO PEDIDO_DETALLE (PEDIDOID, ARTICULOID, CANTIDAD, PRECIO_UNITARIO)
                        VALUES (@pedidoId, @articuloId, @cantidad, @precioUnitario)";

            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta(consulta);
                foreach (var detalle in pedido.Detalles)
                {
                    datos.setearParametro("@pedidoId", pedido.Id);
                    datos.setearParametro("@articuloId", detalle.ArticuloId);
                    datos.setearParametro("@cantidad", detalle.Cantidad);
                    datos.setearParametro("@precioUnitario", detalle.PrecioUnitario);
                    datos.ejecutarAccion();
                }

                return 1;
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

        public int AgregarEstadoPedido(EstadoPedidoEntity pedido)
        {
            #region Consulta
            string consulta = @"INSERT INTO PEDIDO_DETALLE (ID, NOMBRE)
                                VALUES(@pedidoId,@nombre)";
            #endregion

            try
            {
                DataAccess datos = new DataAccess();
                try
                {
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@pedidoId", pedido.EstadoPedidoid);
                    datos.setearParametro("@articuloId", pedido.Nombre);


                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    

        public List<PedidoEntity> ObtenerHistorialCompras(long usuarioId)
        {
            
            List<PedidoEntity> historialCompras = new List<PedidoEntity>();
            string consultaPedidos = @"
                               SELECT 
                                        p.ID,
                                        p.USUARIOID,
                                        p.FECHA_PEDIDO,
                                        p.MONTO_TOTAL,
                                        p.ESTADOPEDIDOID,
                                        ad.NOMBRE AS NombreArticulo,
                                        pd.ARTICULOID,
                                        pd.CANTIDAD,
                                        pd.PRECIO_UNITARIO,
                                        p.ENVIO,
                                        mp.ID AS MetodoPagoId,
                                        mp.NOMBRE AS NombreMetodoPago
                                    FROM 
                                        PEDIDO p
                                    JOIN 
                                        PEDIDO_DETALLE pd ON p.ID = pd.PEDIDOID
                                    JOIN 
                                        ARTICULOS_DETALLE ad ON pd.ARTICULOID = ad.ARTICULOID
                                    LEFT JOIN 
                                        METODO_PAGO mp ON p.USUARIOID = mp.ID
                                    WHERE 
                                        p.USUARIOID = @UsuarioID
                                    ORDER BY 
                                        p.FECHA_PEDIDO DESC";

            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta(consultaPedidos);
                datos.setearParametro("@UsuarioID", usuarioId);
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    long pedidoId = datos.Reader.GetInt64(0);
                   
                    var pedido = historialCompras.Find(p => p.Id == pedidoId);
                    if (pedido == null)
                    {   
                        pedido = new PedidoEntity
                        {
                             
                            Id = pedidoId,
                            UsuarioId = datos.Reader.GetInt64(1),
                            FechaPedido = datos.Reader.GetDateTime(2),
                            MontoTotal = datos.Reader.GetDecimal(3),
                            EstadoPedidoid = datos.Reader.IsDBNull(4) ? default(short) : (short)datos.Reader.GetInt16(4),
                            Envio = datos.Reader.GetBoolean(9),
                            MetodoPago = new MetodoPagoEntity
                            {
                            Nombre = datos.Reader.IsDBNull(11) ? null : datos.Reader.GetString(11)
                            },
                            Detalles = new List<PedidoDetalleEntity>()
                        };
                        historialCompras.Add(pedido);
                    }

                    var detalle = new PedidoDetalleEntity
                    {
                        ArticuloId = datos.Reader.GetInt64(6),
                        Articulo = new ArticuloEntity()
                        {
                            Nombre = datos.Reader.GetString(5)
                        },
                        Cantidad = datos.Reader.GetInt32(7),
                        PrecioUnitario = datos.Reader.GetDecimal(8),
                        Imagenes = ObtenerImagenesArticulo(datos.Reader.GetInt64(6)) 
                    };

                    pedido.Detalles.Add(detalle);
                }
              
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el historial de compras desde PedidoImp", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return historialCompras;
        }
    
        public UsuarioEntity ObtenerUsuarioPorId(long usuarioid)
        {
            UsuarioEntity usuario = null;
            DataAccess datos = new DataAccess();

            string consulta = @"SELECT 
                                U.ID,
                                U.NOMBRE,
                                U.APELLIDO,
                                U.DNI,
                                U.USUARIO,
                                U.EMAIL,
                                U.CONTRASENIA,
                                U.SALT,
                                U.ROLID,
                                R.NOMBRE AS ROL_NOMBRE,
                                U.PROVINCIA,
                                U.LOCALIDAD,
                                U.CALLE,
                                U.ALTURA,
                                U.CODIGO_POSTAL,
                                U.TELEFONO,
                                U.ESTADO,
                                U.FECHA_REGISTRO
                            FROM USUARIOS U
                            INNER JOIN ROLES R ON U.ROLID = R.ID 
                            WHERE U.ID = @usuarioid";
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuarioid", usuarioid);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    usuario = new UsuarioEntity();
                    usuario.Id = (long)datos.Reader["ID"];
                    usuario.Nombre = datos.Reader["NOMBRE"] != DBNull.Value ? (string)datos.Reader["NOMBRE"] : null;
                    usuario.Apellido = datos.Reader["APELLIDO"] != DBNull.Value ? (string)datos.Reader["APELLIDO"] : null;
                    usuario.Dni = datos.Reader["DNI"] != DBNull.Value ? (string)datos.Reader["DNI"] : null;
                    usuario.Usuario = datos.Reader["USUARIO"] != DBNull.Value ? (string)datos.Reader["USUARIO"] : null;
                    usuario.Email = datos.Reader["EMAIL"] != DBNull.Value ? (string)datos.Reader["EMAIL"] : null;
                    usuario.Contrasenia = datos.Reader["CONTRASENIA"] != DBNull.Value ? (string)datos.Reader["CONTRASENIA"] : null;
                    usuario.Salt = datos.Reader["SALT"] != DBNull.Value ? (string)datos.Reader["SALT"] : null;
                    usuario.Rol = new RolesEntity
                    {
                        Id = (short)datos.Reader["ROLID"],
                        Nombre = datos.Reader["ROL_NOMBRE"] != DBNull.Value ? (string)datos.Reader["ROL_NOMBRE"] : null
                    };
                    usuario.Provincia = datos.Reader["PROVINCIA"] != DBNull.Value ? (string)datos.Reader["PROVINCIA"] : null;
                    usuario.Localidad = datos.Reader["LOCALIDAD"] != DBNull.Value ? (string)datos.Reader["LOCALIDAD"] : null;
                    usuario.Calle = datos.Reader["CALLE"] != DBNull.Value ? (string)datos.Reader["CALLE"] : null;
                    usuario.Altura = datos.Reader["ALTURA"] != DBNull.Value ? (string)datos.Reader["ALTURA"] : null;
                    usuario.CodPostal = datos.Reader["CODIGO_POSTAL"] != DBNull.Value ? (string)datos.Reader["CODIGO_POSTAL"] : null;
                    usuario.Telefono = datos.Reader["TELEFONO"] != DBNull.Value ? (string)datos.Reader["TELEFONO"] : null;
                    usuario.Estado = (bool)datos.Reader["ESTADO"];
                    usuario.FechaRegistro = (DateTime)datos.Reader["FECHA_REGISTRO"];
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario por ID desde la base de datos.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<ImagenEntity> ObtenerImagenesArticulo(long articuloId)
        {
            List<ImagenEntity> imagenes = new List<ImagenEntity>();
            string consultaImagenes = "SELECT IMAGEN FROM Imagenes WHERE ArticuloID = @ArticuloID";

            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta(consultaImagenes);
                datos.setearParametro("@ArticuloID", articuloId);
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    ImagenEntity imagen = new ImagenEntity
                    {
                        UrlImagen = datos.Reader.GetString(0)
                    };
                    imagenes.Add(imagen);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las imágenes del artículo desde ArticuloImp", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return imagenes;
        }
    }

}