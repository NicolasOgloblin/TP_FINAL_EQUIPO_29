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
                    marca.Nombre = (string)datos.Reader["Nombre"];

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
            string consulta = "insert MARCAS (NOMBRE) values (@NOMBRE)"; 

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@NOMBRE",marca.Nombre);
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
                string consulta = @"IF EXISTS (SELECT 1 FROM MARCAS M
                                    INNER JOIN ARTICULOS A ON (M.ID=A.MARCAID)
                                    WHERE M.ID = @id)
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

        public int ModificarMarca(MarcaEntity marca)
        {
            DataAccess datos = new DataAccess();
            string consulta = "UPDATE MARCAS SET NOMBRE = @NOMBRE WHERE Id = @id ";

            try
            {
                datos.setearConsulta(consulta);  
                datos.setearParametro("@id", marca.Id);
                datos.setearParametro("@NOMBRE", marca.Nombre);
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

        public bool MarcaExiste(string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM MARCAS WHERE Nombre = @nombre");
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

        public void ModificarMarcaExiste(MarcaEntity marca)
        {
            DataAccess datos = new DataAccess();
            try
            {

                if (MarcaExiste(marca.Nombre) && !EsMismaMarca(marca.Id, marca.Nombre))
                {
                    throw new Exception("Ya existe una marca con ese nombre.");
                }


                datos.setearConsulta("update MARCAS set NOMBRE = @NOMBRE where ID = @id ");
                datos.setearParametro("@id", marca.Id);
                datos.setearParametro("@NOMBRE", marca.Nombre);
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
        private bool EsMismaMarca(int id, string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM MARCAS WHERE Id = @id AND Nombre = @nombre");
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
