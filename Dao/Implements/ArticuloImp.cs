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
                                A.CODIGO, 
                                A.NOMBRE, 
                                A.DESCRIPCION, 
                                A.IdMarca, 
                                M.Descripcion AS DSM,
                                A.IdCategoria, 
                                C.Descripcion AS DSC,
                                A.Precio,
                                I.ImagenUrl,
                                ROW_NUMBER() OVER (ORDER BY A.ID) AS RowNumber
                                FROM ARTICULOS A 
                                INNER JOIN MARCAS M ON (A.IdMarca=M.Id)
                                INNER JOIN CATEGORIAS C ON (A.IdCategoria=C.Id)
                                INNER JOIN IMAGENES I ON(A.Id = I.IdArticulo)
                                GROUP BY A.Id,A.CODIGO, A.NOMBRE, A.DESCRIPCION, A.IdMarca, 
                                M.Descripcion,A.IdCategoria, C.Descripcion,A.Precio,I.ImagenUrl";
            #endregion

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                
                while (datos.Reader.Read())
                {
                    var articulo = new ArticuloEntity(); 
                    articulo.Id = (int)datos.Reader["id"];
                    articulo.CodArticulo = (string)datos.Reader["Codigo"];
                    articulo.Nombre = (string)datos.Reader["Nombre"];
                    articulo.Descripcion = (string)datos.Reader["Descripcion"];

                    articulo.Marca = new MarcaEntity();
                    articulo.Categoria = new CategoriaEntity();
                    articulo.Imagen = new ImagenEntity();

                    articulo.Marca.Id = (int)datos.Reader["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Reader["DSM"];
                    articulo.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Reader["DSC"];
                    articulo.Precio = (decimal)datos.Reader["Precio"];
                    articulo.Imagen.UrlImagen = (string)datos.Reader["ImagenUrl"];

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
                datos.setearParametro("@imagenUrl",art.Imagen.UrlImagen);
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
                datos.setearParametro("@imagenUrl", art.Imagen.UrlImagen);
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
                    articulo.Imagen = new ImagenEntity();

                    articulo.Marca.Id = (int)datos.Reader["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Reader["DSM"];
                    articulo.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Reader["DSC"];
                    articulo.Precio = (decimal)datos.Reader["Precio"];
                    articulo.Imagen.UrlImagen = (string)datos.Reader["ImagenUrl"];

                    
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
