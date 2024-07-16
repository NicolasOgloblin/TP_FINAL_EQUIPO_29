using Dao.DataAccessObject;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Dao.Implements
{
    public class ArticuloImp
    {
        
        public List<ArticuloEntity> GetArticulos()
        {
            var listArticulos = new List<ArticuloEntity>();
            DataAccess datos = new DataAccess();
           
            #region Consulta
            string consulta = @"SELECT  
                                 A.ID, 
                                 A.CODIGO_ARTICULO, 
                                 AD.NOMBRE, 
                                 ISNULL(AD.DESCRIPCION,'') AS DESCRIPCION, 
                                 ISNULL(AD.ALTO,0) AS ALTO,
                                 ISNULL(AD.ANCHO,0) AS ANCHO,
                                 ISNULL(AD.COLOR,'') AS COLOR,
                                 ISNULL(AD.MODELO,'') AS MODELO,
                                 ISNULL(AD.ORIGEN,'') AS ORIGEN,
                                 ISNULL(AD.PESO,0) AS PESO,
                                 ISNULL(AD.GARANTIA_ANIOS,0) AS GARANTIA_ANIOS,
                                 ISNULL(AD.GARANTIA_MESES,0) AS GARANTIA_MESES,
                                 ISNULL(AD.PRECIO,0) AS PRECIO,
                                 ISNULL(AD.STOCK,0) AS STOCK,
                                 M.NOMBRE AS NOMBREMARCA,
                                 C.NOMBRE AS NOMBRECATEGORIA
                                 FROM ARTICULOS A
                                 INNER JOIN ARTICULOS_DETALLE AD ON (A.ID = AD.ARTICULOID)
                                 INNER JOIN MARCAS M ON (A.MARCAID=M.ID)
                                 INNER JOIN CATEGORIAS C ON (A.CATEGORIAID=C.ID)
                                 GROUP BY A.ID, A.CODIGO_ARTICULO, AD.NOMBRE, AD.DESCRIPCION,
                                 AD.ALTO, AD.ANCHO, AD.COLOR,AD.MODELO,AD.ORIGEN,AD.PESO,AD.GARANTIA_ANIOS,
                                 AD.GARANTIA_MESES, M.NOMBRE, C.NOMBRE,
                                 AD.PRECIO, AD.STOCK, A.CODIGO_ARTICULO";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                
                while (datos.Reader.Read())
                {
                    var articulo = new ArticuloEntity(); 
                    articulo.Id = (long)datos.Reader["ID"];
                    articulo.CodArticulo = (string)datos.Reader["CODIGO_ARTICULO"];
                    articulo.Nombre = (string)datos.Reader["NOMBRE"];
                    articulo.Descripcion = (string)datos.Reader["DESCRIPCION"];
                    articulo.Alto = (decimal)datos.Reader["ALTO"];
                    articulo.Ancho = (decimal)datos.Reader["ANCHO"];
                    articulo.Color = (string)datos.Reader["COLOR"];
                    articulo.Modelo = (string)datos.Reader["MODELO"];
                    articulo.Origen = (string)datos.Reader["ORIGEN"];
                    articulo.Peso = (decimal)datos.Reader["PESO"];
                    articulo.Garantia_Anios = (int)datos.Reader["GARANTIA_ANIOS"];
                    articulo.Garantia_Meses = (int)datos.Reader["GARANTIA_MESES"];
                   
                    articulo.Marca = new MarcaEntity();
                    articulo.Categoria = new CategoriaEntity();
                    
                    articulo.Marca.Nombre = (string)datos.Reader["NOMBREMARCA"];
                   
                    articulo.Categoria.Nombre = (string)datos.Reader["NOMBRECATEGORIA"];
                    articulo.Precio = (decimal)datos.Reader["PRECIO"];
                    articulo.Stock = (int)datos.Reader["STOCK"];

                    listArticulos.Add(articulo);
                }

                return listArticulos;
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

        public List<ImagenEntity> GetImagenes()
        {
            var listImagenes = new List<ImagenEntity>();
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"SELECT 
                                ARTICULOID,
                                IMAGEN
                                FROM IMAGENES";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    var imagen = new ImagenEntity();
                    imagen.ArticuloId = (long)datos.Reader["ARTICULOID"];
                    imagen.UrlImagen = (string)datos.Reader["IMAGEN"];

                    listImagenes.Add(imagen);
                }

                return listImagenes;
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

        public List<ImagenEntity> GetImagenById(long artId)
        {
            DataAccess datos = new DataAccess();
            var listImagenes = new List<ImagenEntity>();

            string consulta = @"SELECT 
                                ARTICULOID,
                                IMAGEN
                                FROM IMAGENES
                                WHERE ARTICULOID = @artId";


            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@artId", artId);
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    var imagen = new ImagenEntity();
                    imagen.ArticuloId = (long)datos.Reader["ARTICULOID"];
                    imagen.UrlImagen = (string)datos.Reader["IMAGEN"];

                    listImagenes.Add(imagen);
                }

                return listImagenes;

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

        public int GetReservaStock(long artId)
        {
            DataAccess datos = new DataAccess();

            string consulta = @"SELECT STOCK_RESERVADO
                                FROM RESERVA_STOCK
                                WHERE ARTICULOID = @articuloId";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@articuloId", artId);
                datos.ejecutarLectura();

                int stockReservado = 0;

                if(datos.Reader.Read())
                {
                    stockReservado = (int)datos.Reader["STOCK_RESERVADO"];
                }

                return stockReservado;

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

        public int DevolverStock(ArticuloEntity articulo, long usuarioId)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"
                                BEGIN TRY
                                BEGIN TRAN

                                UPDATE RESERVA_STOCK
                                SET STOCK_RESERVADO = STOCK_RESERVADO - 1
                                WHERE ARTICULOID = @articuloId
                                AND USUARIOID = @usuarioId

                                UPDATE ARTICULOS_DETALLE
                                SET STOCK = STOCK + 1
                                WHERE ARTICULOID = @articuloId

                                COMMIT TRAN
                                END TRY
                                BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                ROLLBACK TRAN;
                                END CATCH";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuarioId", usuarioId);
                datos.setearParametro("@articuloId", articulo.Id);

                var result = datos.ejecutarAccion();

                return result;
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

        public int ReservarStock(ArticuloEntity articulo, long usuarioId)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"
                                BEGIN TRY
                                BEGIN TRAN

                                DECLARE @COUNT_STOCK INT 
                                SET @COUNT_STOCK =  (
					                                SELECT COALESCE(SUM(ISNULL(STOCK_RESERVADO, 0)), 0)
					                                FROM RESERVA_STOCK 
					                                WHERE ARTICULOID = @articuloId AND USUARIOID = @usuarioId
					                                )

                                IF @COUNT_STOCK > 0
                                BEGIN
                                UPDATE RESERVA_STOCK
                                SET STOCK_RESERVADO = STOCK_RESERVADO + 1
                                WHERE ARTICULOID = @articuloId
                                AND USUARIOID = @usuarioId
                                END
                                ELSE
                                BEGIN
                                INSERT INTO RESERVA_STOCK
                                VALUES(@usuarioId,@articuloId,1)
                                END

                                UPDATE ARTICULOS_DETALLE
                                SET STOCK = STOCK - 1
                                WHERE ARTICULOID = @articuloId

                                COMMIT TRAN
                                END TRY
                                BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                ROLLBACK TRAN;
                                END CATCH";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuarioId", usuarioId);
                datos.setearParametro("@articuloId", articulo.Id);

                var result = datos.ejecutarAccion();

                return result;
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

        public int EliminarStock(ArticuloEntity articulo, long usuarioId)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"
                                BEGIN TRY
                                BEGIN TRAN

                                UPDATE ARTICULOS_DETALLE
                                SET STOCK = STOCK + (SELECT STOCK_RESERVADO FROM RESERVA_STOCK WHERE ARTICULOID = @articuloId)
                                WHERE ARTICULOID = @articuloId

                                DELETE RESERVA_STOCK
                                WHERE ARTICULOID = @articuloId
                                AND USUARIOID = @usuarioId

                                COMMIT TRAN
                                END TRY
                                BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                ROLLBACK TRAN;
                                END CATCH";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@articuloId", articulo.Id);
                datos.setearParametro("@usuarioId", usuarioId);

                var result = datos.ejecutarAccion();

                return result;
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

        public int FinalizarStock(long usuarioId)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"DELETE RESERVA_STOCK
                                WHERE USUARIOID = @usuarioId";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@usuarioId", usuarioId);

                var result = datos.ejecutarAccion();

                return result;
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

        public int AgregarImagenes(List<ImagenEntity> imagenes)
        {
            #region Consulta
            string consulta = @"INSERT INTO IMAGENES
                                VALUES(@articuloId,@imagen)";
            #endregion

            try
            {

                foreach (var imagen in imagenes)
                {

                    DataAccess datos = new DataAccess();
                    try
                    {
                        datos.setearConsulta(consulta);
                        datos.setearParametro("@articuloId", imagen.ArticuloId);
                        datos.setearParametro("@imagen", imagen.UrlImagen);

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

        public int AgregarArticulo(ArticuloEntity art)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"
                                BEGIN TRY
                                BEGIN TRAN

                                INSERT INTO ARTICULOS (CODIGO_ARTICULO, CATEGORIAID, MARCAID, FECHA_AGREGADO)
                                VALUES (@codigo, @idCategoria, @idMarca, GETDATE());

                                DECLARE @ID INT;
                                SET @ID = SCOPE_IDENTITY();

                                INSERT INTO ARTICULOS_DETALLE 
                                (ARTICULOID, NOMBRE, DESCRIPCION, ALTO, ANCHO, COLOR, MODELO, ORIGEN, PESO, GARANTIA_ANIOS, GARANTIA_MESES, PRECIO, STOCK)
                                VALUES 
                                (@ID, @nombre, @descripcion, @alto, @ancho, @color, @modelo, @origen, @peso, @garantiaAnios, @garantiaMeses, @precio, @stock);

                                COMMIT TRAN
                                END TRY
                                BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                ROLLBACK TRAN;
                                END CATCH";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@codigo", art.CodArticulo);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@alto", art.Alto);
                datos.setearParametro("@ancho", art.Ancho);
                datos.setearParametro("@color", art.Color);
                datos.setearParametro("@modelo", art.Modelo);
                datos.setearParametro("@origen", art.Origen);
                datos.setearParametro("@peso", art.Peso);
                datos.setearParametro("@garantiaAnios", art.Garantia_Anios);
                datos.setearParametro("@garantiaMeses", art.Garantia_Meses);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@stock", art.Stock);

                var result = datos.ejecutarAccion();

                return result;
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
       
        public int ModificarArticulo(ArticuloEntity art)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"
                            BEGIN TRY
                            BEGIN TRAN

                            -- Actualizar ARTICULOS
                            UPDATE ARTICULOS  
                            SET Codigo_Articulo = @codigo, CategoriaID = @idCategoria, MarcaID = @idMarca
                            WHERE ID = @id

                            -- Actualizar ARTICULOS_DETALLE
                            UPDATE ARTICULOS_DETALLE
                            SET Nombre = @nombre, DESCRIPCION = @descripcion, ALTO = @alto, ANCHO = @ancho, COLOR = @color, 
                            MODELO = @modelo, ORIGEN = @origen, PESO = @peso, GARANTIA_ANIOS = @ganios, GARANTIA_MESES = @gmeses Stock = @stock
                            WHERE ArticuloID = @id

                            COMMIT TRAN
                            END TRY
                            BEGIN CATCH
                            IF @@TRANCOUNT > 0
                            ROLLBACK TRAN;
                            END CATCH";

                        
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@codigo", art.CodArticulo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@id", art.Id);
                datos.setearParametro("@stock", art.Stock);
               
                return datos.ejecutarAccion();
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

        
        public int ModificarArticuloCompleto(ArticuloEntity art)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"
                                BEGIN TRY
                                BEGIN TRAN
                                -- Actualizar ARTICULOS
                                UPDATE ARTICULOS  
                                SET Codigo_Articulo = @codigo, CategoriaID = @idCategoria, MarcaID = @idMarca
                                WHERE ID = @id
                                -- Actualizar ARTICULOS_DETALLE
                                UPDATE ARTICULOS_DETALLE
                                SET Nombre = @nombre, Precio = @precio, Stock = @stock, 
                                    Alto = @alto, Ancho = @ancho, Color = @color, Modelo = @modelo, 
                                    Origen = @origen, Peso = @peso, Garantia_Anios = @garantiaAnios, 
                                    Garantia_Meses = @garantiaMeses
                                WHERE ArticuloID = @id


                                COMMIT TRAN
                                END TRY
                                BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                ROLLBACK TRAN;
                                END CATCH";


            #endregion

            try
            {
                
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@codigo", art.CodArticulo);
                    datos.setearParametro("@nombre", art.Nombre);
                    datos.setearParametro("@idMarca", art.Marca.Id);
                    datos.setearParametro("@idCategoria", art.Categoria.Id);
                    datos.setearParametro("@precio", art.Precio);
                    datos.setearParametro("@id", art.Id);
                    datos.setearParametro("@stock", art.Stock);
                    datos.setearParametro("@alto", art.Alto);
                    datos.setearParametro("@ancho", art.Ancho);
                    datos.setearParametro("@color", art.Color);
                    datos.setearParametro("@modelo", art.Modelo);
                    datos.setearParametro("@origen", art.Origen);
                    datos.setearParametro("@peso", art.Peso);
                    datos.setearParametro("@garantiaAnios", art.Garantia_Anios);
                    datos.setearParametro("@garantiaMeses", art.Garantia_Meses);

                    return datos.ejecutarAccion();
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
      

        public bool Eliminar(long id)
        {
            try
            {
                DataAccess datos = new DataAccess();
                datos.setearConsulta(@"BEGIN TRY
                                BEGIN TRAN

                                DELETE FROM IMAGENES
                                WHERE ARTICULOID = @id

                                DELETE FROM ARTICULOS_DETALLE
                                WHERE ARTICULOID = @id;

                                DELETE FROM ARTICULOS
                                WHERE ID = @id;

                                COMMIT TRAN
                                END TRY
                                BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                ROLLBACK TRAN;
                                END CATCH");

                datos.setearParametro("@id", id);
                 var result = datos.ejecutarAccion();

                if(result > 0) return true;
                return false;
            }
                catch (Exception ex)
                {
                     throw ex;
                }
        }

        public ArticuloEntity getByID (long id)
        {
            
            DataAccess datos = new DataAccess();


            string consulta = @"SELECT  
                                A.ID, 
                                A.CODIGO_ARTICULO, 
                                AD.NOMBRE, 
                                AD.DESCRIPCION, 
                                ISNULL(AD.PRECIO,0) AS PRECIO,
                                ISNULL(AD.STOCK,0) AS STOCK,
                                M.NOMBRE AS NOMBREMARCA,
                                C.NOMBRE AS NOMBRECATEGORIA,
                                M.ID AS MID,
                                C.ID CID,
                                AD.ALTO,
                                AD.ANCHO,
                                AD.COLOR,
                                AD.MODELO,
                                AD.ORIGEN,
                                AD.PESO,
                                AD.GARANTIA_ANIOS,
                                AD.GARANTIA_MESES
                                FROM ARTICULOS A
                                INNER JOIN ARTICULOS_DETALLE AD ON (A.ID = AD.ARTICULOID)
                                INNER JOIN MARCAS M ON (A.MARCAID=M.ID)
                                INNER JOIN CATEGORIAS C ON (A.CATEGORIAID=C.ID)
                                WHERE A.ID = @id
                                GROUP BY A.ID, AD.NOMBRE, AD.DESCRIPCION, M.NOMBRE, C.NOMBRE,
                                AD.PRECIO, AD.STOCK, A.CODIGO_ARTICULO,AD.ALTO,AD.ANCHO,AD.COLOR,
                                AD.MODELO,AD.ORIGEN,AD.PESO,AD.GARANTIA_ANIOS,AD.GARANTIA_MESES,
                                C.ID, M.ID";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                   var articulo = new ArticuloEntity();

                if (datos.Reader.Read())
                {
                    articulo.Id = (long)datos.Reader["ID"];
                    articulo.CodArticulo = (string)datos.Reader["CODIGO_ARTICULO"];
                    articulo.Nombre = (string)datos.Reader["NOMBRE"];
                    articulo.Descripcion = (string)datos.Reader["DESCRIPCION"];
                    articulo.Marca = new MarcaEntity();
                    articulo.Categoria = new CategoriaEntity();
                    articulo.Marca.Nombre = (string)datos.Reader["NOMBREMARCA"];
                    articulo.Categoria.Nombre = (string)datos.Reader["NOMBRECATEGORIA"];
                    articulo.Marca.Id = (int)datos.Reader["MID"];
                    articulo.Categoria.Id = (int)datos.Reader["CID"];
                    articulo.Precio = (decimal)datos.Reader["PRECIO"];
                    articulo.Stock = (int)datos.Reader["STOCK"];
                    articulo.Alto = (decimal)datos.Reader["ALTO"];
                    articulo.Ancho = (decimal)datos.Reader["ANCHO"];
                    articulo.Origen = (string)datos.Reader["ORIGEN"];
                    articulo.Modelo = (string)datos.Reader["MODELO"];
                    articulo.Color = (string)datos.Reader["COLOR"];
                    articulo.Peso = (decimal)datos.Reader["PESO"];
                    articulo.Garantia_Anios = (int)datos.Reader["GARANTIA_ANIOS"];
                    articulo.Garantia_Meses = (int)datos.Reader["GARANTIA_MESES"];

                }
                return articulo;
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

        public ArticuloEntity getByCodArticulo(string codArt)
        {

            DataAccess datos = new DataAccess();


            string consulta = @"SELECT  
                                A.ID, 
                                A.CODIGO_ARTICULO, 
                                AD.NOMBRE, 
                                AD.DESCRIPCION, 
                                ISNULL(AD.PRECIO,0) AS PRECIO,
                                ISNULL(AD.STOCK,0) AS STOCK,
                                M.NOMBRE AS NOMBREMARCA,
                                C.NOMBRE AS NOMBRECATEGORIA
                                FROM ARTICULOS A
                                INNER JOIN ARTICULOS_DETALLE AD ON (A.ID = AD.ARTICULOID)
                                INNER JOIN MARCAS M ON (A.MARCAID=M.ID)
                                INNER JOIN CATEGORIAS C ON (A.CATEGORIAID=C.ID)
                                WHERE A.CODIGO_ARTICULO = @codArt
                                GROUP BY A.ID, AD.NOMBRE, AD.DESCRIPCION, M.NOMBRE, C.NOMBRE,
                                AD.PRECIO, AD.STOCK, A.CODIGO_ARTICULO";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@codArt", codArt);
                datos.ejecutarLectura();

                var articulo = new ArticuloEntity();

                if (datos.Reader.Read())
                {
                    articulo.Id = (long)datos.Reader["ID"];
                    articulo.CodArticulo = (string)datos.Reader["CODIGO_ARTICULO"];
                    articulo.Nombre = (string)datos.Reader["NOMBRE"];
                    articulo.Descripcion = (string)datos.Reader["DESCRIPCION"];
                    articulo.Marca = new MarcaEntity();
                    articulo.Categoria = new CategoriaEntity();
                    articulo.Marca.Nombre = (string)datos.Reader["NOMBREMARCA"];
                    articulo.Categoria.Nombre = (string)datos.Reader["NOMBRECATEGORIA"];
                    articulo.Precio = (decimal)datos.Reader["PRECIO"];
                    articulo.Stock = (int)datos.Reader["STOCK"];

                }
                return articulo;
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

        public bool ArticuloExiste(string codigoArticulo)
        {
            DataAccess datos = new DataAccess();

            string consulta = "SELECT COUNT(*) FROM ARTICULOS WHERE CODIGO_ARTICULO = @codigoArticulo";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@codigoArticulo", codigoArticulo);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    int count = Convert.ToInt32(datos.Reader[0]);
                    return count > 0;
                }

                return false;
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

    }
}
