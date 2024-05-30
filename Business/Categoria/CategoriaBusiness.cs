using Dao.Implements;
using Domain.Entities;
using System.Collections.Generic;
using System;

namespace Business.Marca
{
  public class CategoriaBusiness
    {
        public List <CategoriaEntity> GetCategorias()
        {
            var listCategorias = new List<CategoriaEntity>();
            var categoriaDao = new CategoriaImp();
            try
            {
                listCategorias = categoriaDao.GetCategorias();
                return listCategorias;

            }
            catch(Exception ex) 
            {

                throw ex;
            }
        }
        public int AgregarCategoria(CategoriaEntity categoria)
        {
            CategoriaImp catImp = new CategoriaImp();

            try
            {
                return catImp.AgregarCategoria(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int ModificarCategoria(CategoriaEntity categoria)
        {
            CategoriaImp catImp = new CategoriaImp();

            try
            {
                return catImp.ModificarCategoria(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int EliminarCategoria(int id)
        {
            CategoriaImp categoImp = new CategoriaImp();

            try
            {
                return categoImp.EliminarCategoria(id);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int Corroborar(int id)
        {
           CategoriaImp catego = new CategoriaImp();
            try
            {
                return catego.Corroborar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
