using Dao.DataAccessObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Dao.Implements
{
    public class MarcaImp 
    {

        public List<MarcaEntity> GetMarcas()
        {
            var listMarcas = new List<MarcaEntity>();
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    var marca = new MarcaEntity();
                    marca.Id = (int)datos.Reader["Id"];
                    marca.Descripcion = (string)datos.Reader["Descripcion"];

                    listMarcas.Add(marca);
                }

                return listMarcas;
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

       public int AgregarMarca(MarcaEntity marca) 
        {
            DataAccess datos = new DataAccess();
            string consulta = "insert marcas (Descripcion) values (@descripcion)"; 

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@descripcion",marca.Descripcion);
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

        //Modificar (update).
        public int ModificarMarca(MarcaEntity marca)
        {
            DataAccess datos = new DataAccess();
            string consulta = "update marcas set Descripcion = @descripcion where Id = @id ";

            try
            {
                datos.setearConsulta(consulta);  
                datos.setearParametro("@id", marca.Id);
                datos.setearParametro("@descripcion", marca.Descripcion);
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
        
        public int EliminarMarca(int id)
        {
            var articulos = new ArticuloEntity();
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("DELETE MARCAS WHERE Id = @id");
                
                datos.setearParametro("@id", id);
               
                return datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Corroborar (int id) 
        { 
            DataAccess datos = new DataAccess();
            string consulta = @"SELECT COUNT (*) AS CONTADOR 
                                FROM MARCAS M
                                INNER JOIN ARTICULOS A ON(M.Id = A.IdMarca)
                                WHERE M.Id = @id";

            
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
            finally { datos.cerrarConexion();}

        }

    }
}
