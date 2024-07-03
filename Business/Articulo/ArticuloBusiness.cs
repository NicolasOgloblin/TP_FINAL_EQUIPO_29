using Dao.Implements;
using Domain.Entities;
using System;
using System.Collections.Generic;


namespace Business.Articulo
{
    public class ArticuloBusiness
    {
        public int ReservarStock(ArticuloEntity articulo, long usuarioId)
        {
            ArticuloImp artImp = new ArticuloImp();
            try
            {
                var result = artImp.ReservarStock(articulo, usuarioId);

                if (result > 0)
                {
                    return GetReservaStock(articulo.Id);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DevolverStock(ArticuloEntity articulo, long usuarioId)
        {
            ArticuloImp artImp = new ArticuloImp();
            try
            {
                var result = artImp.DevolverStock(articulo, usuarioId);

                if(result > 0)
                {
                    return GetReservaStock(articulo.Id);
                }

                return result; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarStock(ArticuloEntity articulo, long usuarioId)
        {
            ArticuloImp artImp = new ArticuloImp();
            try
            {
                var result = artImp.EliminarStock(articulo, usuarioId);

                if (result > 0)
                {
                    return GetReservaStock(articulo.Id);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetReservaStock(long articuloId)
        {
            ArticuloImp artImp = new ArticuloImp();
            try
            {
                return artImp.GetReservaStock(articuloId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public int AgregarImagenes(List<ImagenEntity> imagenes)
        {
            ArticuloImp artImp = new ArticuloImp();
            try
            {
                return artImp.AgregarImagenes(imagenes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Eliminar(long id)
        {
            ArticuloImp articuloImp = new ArticuloImp();
            try
            {
                bool result = articuloImp.Eliminar(id);
                return result;
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

        public int ModificarArticuloCompleto(ArticuloEntity categoria)
        {
            ArticuloImp catImp = new ArticuloImp();

            try
            {
                return catImp.ModificarArticuloCompleto(categoria);
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

        public ArticuloEntity getByCodArt(string codArt)
        {
            ArticuloImp articulo = new ArticuloImp();
            try
            {
                return articulo.getByCodArticulo(codArt);
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
        public bool ArticuloExiste(string codigoArticulo)
        {
            ArticuloImp articulo = new ArticuloImp();
            try
            {
                return articulo.ArticuloExiste(codigoArticulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
