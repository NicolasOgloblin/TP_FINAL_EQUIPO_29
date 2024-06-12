using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.DataAccessObject;


namespace Dao.Implements
{
    public class CategoriaImp
    {
       public List<CategoriaEntity>GetCategorias()
        {
            var listaCategorias = new List<CategoriaEntity>();
           DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    var categoria = new CategoriaEntity();
                   categoria.Id = (int)datos.Reader["Id"];
                   categoria.Nombre = (string)datos.Reader["Nombre"];
                        listaCategorias.Add(categoria);

                }
                return listaCategorias;
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
        public int AgregarCategoria(CategoriaEntity categoria)
        {
            DataAccess datos = new DataAccess();
            string consulta = "insert categorias (NOMBRE) values (@NOMBRE)";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@NOMBRE", categoria.Nombre);
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

        public bool VerificarExistenciaCategoriaXArticulo(int id)
        {
            DataAccess dataAccess = new DataAccess();
            try 
            {
                string consulta = @"IF EXISTS (SELECT 1 FROM CATEGORIAS C
                                    INNER JOIN ARTICULOS A ON (C.ID=A.CATEGORIAID)
                                    WHERE C.ID = @id)
                                    BEGIN
                                    SELECT 1
                                    END
                                    ELSE 
                                    BEGIN
                                    SELECT 0
                                    END";
                dataAccess.setearConsulta(consulta);
                dataAccess.setearParametro("@id", id);
                
                var result = dataAccess.ejecutarScalar();
                
               if (Convert.ToInt32(result) == 1)
                {
                    return true;
                }
               return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.cerrarConexion();
            }
        } 
        public int ModificarCategoria(CategoriaEntity categoria)
        {
            DataAccess datos = new DataAccess();
            try
            {
               
                if (CategoriaExiste(categoria.Nombre) && !EsMismaCategoria(categoria.Id, categoria.Nombre))
                {
                    throw new Exception("Ya existe una categoría con ese nombre.");
                }

                
                datos.setearConsulta("UPDATE CATEGORIAS SET NOMBRE = @NOMBRE WHERE Id = @id ");
                datos.setearParametro("@id", categoria.Id);
                datos.setearParametro("@NOMBRE", categoria.Nombre);
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
        public int EliminarCategoria(int id)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("DELETE CATEGORIAS WHERE Id = @id");
                datos.setearParametro("@id", id);
                return datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CategoriaExiste(string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM CATEGORIAS WHERE Nombre = @nombre");
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarLectura();
                datos.Reader.Read();
                return datos.Reader.GetInt32(0) > 0;
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


        public void ModificarCategoriaExiste(CategoriaEntity categoria)
        {
            DataAccess datos = new DataAccess();
            try
            {
               
                if (CategoriaExiste(categoria.Nombre) && !EsMismaCategoria(categoria.Id, categoria.Nombre))
                {
                    throw new Exception("Ya existe una categoría con ese nombre.");
                }

                
                datos.setearConsulta("update categorias set NOMBRE = @NOMBRE where ID = @id ");
                datos.setearParametro("@id", categoria.Id);
                datos.setearParametro("@NOMBRE", categoria.Nombre);
                datos.ejecutarAccion();
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
        private bool EsMismaCategoria(int id, string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM CATEGORIAS WHERE Id = @id AND Nombre = @nombre");
                datos.setearParametro("@id", id);
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarLectura();
                datos.Reader.Read();
                return datos.Reader.GetInt32(0) > 0;
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


