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
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    var categoria = new CategoriaEntity();
                   categoria.Id = (int)datos.Reader["Id"];
                   categoria.Descripcion = (string)datos.Reader["Descripcion"];
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
            string consulta = "insert categorias (Descripcion) values (@descripcion)";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@descripcion", categoria.Descripcion);
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
        public int ModificarCategoria(CategoriaEntity categoria)
        {
            DataAccess datos = new DataAccess();
            string consulta = "update categorias set Descripcion = @descripcion where Id = @id ";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@id", categoria.Id);
                datos.setearParametro("@descripcion", categoria.Descripcion);
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
        public int Corroborar(int id)
        {
            DataAccess datos = new DataAccess();
            string consulta = @"SELECT COUNT (*) AS CONTADOR 
                                FROM CATEGORIAS C
                                INNER JOIN ARTICULOS A ON(C.Id = A.IdCategoria)
                                WHERE C.Id = @id";
            int contador = 0;
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {

                    contador = (int)datos.Reader["CONTADOR"];

                }
                return contador;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

    }
}

