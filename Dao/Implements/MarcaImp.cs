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
                datos.setearConsulta("SELECT Id, Nombre FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    var marca = new MarcaEntity();
                    marca.Id = (int)datos.Reader["Id"];
                    marca.Nombre = (string)datos.Reader["Descripcion"];

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
                datos.setearParametro("@descripcion",marca.Nombre);
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
                datos.setearParametro("@descripcion", marca.Nombre);
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

    }
}
