using Dao.Implements;
using Domain.Entities;
using System;
using System.Collections.Generic;


namespace Business.Articulo
{
    public class ArticuloBusiness
    {
        public List<ArticuloEntity> GetArticulos()
        {
            var listArticulos = new List<ArticuloEntity>();
            var ArticuloDao = new ArticuloImp();
            try
            {
                listArticulos = ArticuloDao.GetArticulos();

                return listArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ImagenEntity> GetImagenes()
        {
            var listImagenes = new List<ImagenEntity>();
            var ArticuloDao = new ArticuloImp();
            try
            {
                listImagenes = ArticuloDao.GetImagenes();

                return listImagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int agregarArticulo(ArticuloEntity nuevo)
        {
            ArticuloImp artImp = new ArticuloImp();
            try
            {
                return artImp.AgregarArticulo(nuevo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int id)
        {
            ArticuloImp articuloImp = new ArticuloImp();
            try
            {
                articuloImp.Eliminar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int ModificarArticulo(ArticuloEntity categoria)
        {
            ArticuloImp catImp = new ArticuloImp();

            try
            {
                return catImp.ModificarArticulo(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArticuloEntity getByID(long id)
        {
            ArticuloImp articulo = new ArticuloImp();
            try
            {
                return articulo.getByID(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ImagenEntity> getImagenByID(long id)
        {
            ArticuloImp articulo = new ArticuloImp();
            try
            {
                return articulo.GetImagenById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }

}
