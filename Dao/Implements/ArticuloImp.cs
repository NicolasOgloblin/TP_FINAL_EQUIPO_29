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
            //Consulta actualizada. Todas las demas no estan actualizadas !
            #region Consulta
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
                                INNER JOIN CATEGORIAS C ON (A.CATEGORIAID=C.ID)";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                
                while (datos.Reader.Read())
                {
                    var articulo = new ArticuloEntity(); 
                    articulo.Id = (int)datos.Reader["ID"];
                    articulo.CodArticulo = (string)datos.Reader["CODIGO_ARTICULO"];
                    articulo.Nombre = (string)datos.Reader["NOMBRE"];
                    articulo.Descripcion = (string)datos.Reader["DESCRIPCION"];

                    articulo.Marca = new MarcaEntity();
                    articulo.Categoria = new CategoriaEntity();

                    
                    articulo.Marca.Nombre = (string)datos.Reader["NOMBREMARCA"];
                   
                    articulo.Categoria.Nombre = (string)datos.Reader["CATEGORIANOMBRE"];
                    articulo.Precio = (decimal)datos.Reader["PRECIO"];
                   
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

        public int AgregarArticulo(ArticuloEntity art)
        {
            DataAccess datos = new DataAccess();

            #region Consulta
            string consulta = @"BEGIN TRY
                                BEGIN TRAN

                                INSERT ARTICULOS 
                                VALUES(@codigo,@nombre,@descripcion,@idMarca,@idCategoria,@precio)

                                DECLARE @ID INT;
                                SET @ID = SCOPE_IDENTITY();

                                INSERT IMAGENES 
                                VALUES(@ID,@imagenUrl)

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
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);
              
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
       
        public void Eliminar(int id)
        {
            try
            {
                DataAccess datos = new DataAccess();
                datos.setearConsulta("delete ARTICULOS where Id = @id delete IMAGENES where IdArticulo = @id");

                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArticuloEntity getByID (int id)
        {
            
            DataAccess datos = new DataAccess();


            string consulta = @"SELECT  
                                A.ID, 
                                A.CODIGO, 
                                A.NOMBRE, 
                                A.DESCRIPCION, 
                                A.IdMarca, 
                                M.Descripcion AS DSM,
                                A.IdCategoria, 
                                C.Descripcion AS DSC,
                                A.Precio,
                                I.ImagenUrl
                                FROM ARTICULOS A 
                                INNER JOIN MARCAS M ON (A.IdMarca=M.Id)
                                INNER JOIN CATEGORIAS C ON (A.IdCategoria=C.Id)
                                INNER JOIN IMAGENES I ON(A.Id = I.IdArticulo)
                                WHERE A.ID = @id ";


            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                   var articulo = new ArticuloEntity();

                if (datos.Reader.Read())
                {
                    articulo.Id = (int)datos.Reader["id"];
                    articulo.CodArticulo = (string)datos.Reader["Codigo"];
                    articulo.Nombre = (string)datos.Reader["Nombre"];
                    articulo.Descripcion = (string)datos.Reader["Descripcion"];

                    articulo.Marca = new MarcaEntity();
                    articulo.Categoria = new CategoriaEntity();
                    

                    articulo.Marca.Id = (int)datos.Reader["IdMarca"];
                    articulo.Marca.Nombre = (string)datos.Reader["DSM"];
                    articulo.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    articulo.Categoria.Nombre = (string)datos.Reader["DSC"];
                    articulo.Precio = (decimal)datos.Reader["Precio"];

                    
                }
                return articulo;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
