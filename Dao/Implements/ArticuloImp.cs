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
        /*
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

                           INSERT INTO IMAGENES (ARTICULOID, IMAGEN)
                           VALUES (@ID, @imagenUrl);

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
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@imagenUrl", art.Imagenes[0].UrlImagen);


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
        }*/

        public int AgregarArticulo(ArticuloEntity art)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta =   @"
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

                                INSERT INTO IMAGENES (ARTICULOID, IMAGEN)
                                VALUES (@ID, @imagenUrl);

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
                datos.setearParametro("@imagenUrl", art.Imagenes[0].UrlImagen);

                datos.ejecutarAccion();

                
                for (int i = 1; i < art.Imagenes.Count; i++)
                {
                    string consultaImagen = @"
                INSERT INTO IMAGENES (ARTICULOID, IMAGEN)
                VALUES (@ID, @imagenUrl)";
                    datos.setearConsulta(consultaImagen);
                    datos.setearParametro("@ID", art.Id); 
                    datos.setearParametro("@imagenUrl", art.Imagenes[i].UrlImagen);
                    datos.ejecutarAccion();
                }

                return 1; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el artículo", ex);
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
            string consulta = @"BEGIN TRY
                                BEGIN TRAN

                                UPDATE ARTICULOS  
                                SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, 
                                IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio 
                                WHERE ID = @id

                                UPDATE IMAGENES
                                SET ImagenUrl = @imagenUrl
                                WHERE IdArticulo = @id

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
                datos.setearParametro("@codigo",art.CodArticulo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@id", art.Id);

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
                                A.NOMBRE, 
                                A.DESCRIPCION, 
                                ISNULL(AD.PRECIO,0) AS PRECIO,
                                ISNULL(AD.STOCK,0) AS STOCK,
                                M.NOMBRE AS NOMBREMARCA,
                                C.NOMBRE AS NOMBRECATEGORIA
                                FROM ARTICULOS A
                                INNER JOIN ARTICULOS_DETALLE AD ON (A.ID = AD.ARTICULOID)
                                INNER JOIN MARCAS M ON (A.MARCAID=M.ID)
                                INNER JOIN CATEGORIAS C ON (A.CATEGORIAID=C.ID)
                                WHERE A.ID = @id
                                GROUP BY A.ID, A.NOMBRE, A.DESCRIPCION, M.NOMBRE, C.NOMBRE,
                                         AD.PRECIO, AD.STOCK, A.CODIGO_ARTICULO";


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
