using Dao.Implements;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Business
{
    public class MarcaBusiness
    {
        
        public List<MarcaEntity> GetMarcas()
        {
            var listMarcas = new List<MarcaEntity>();
            var marcaDao = new MarcaImp();
            try
            {
                listMarcas = marcaDao.GetMarcas();

                return listMarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AgregarMarca(MarcaEntity marca)
        {
            MarcaImp marcaImp = new MarcaImp();

            try
            {
                return marcaImp.AgregarMarca(marca);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
       
        public int ModificarMarca(MarcaEntity marca)
        {
            MarcaImp marcaImp = new MarcaImp();

            try
            {
                return marcaImp.ModificarMarca(marca);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int EliminarMarca(int id)
        {
            MarcaImp marcaImp = new MarcaImp();

            try
            {
                if (!marcaImp.VerificarExistenciaCategoriaXArticulo(id))
                {
                    return marcaImp.EliminarMarca(id);
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool MarcaExiste(string nombre)
        {
            MarcaImp marcaImp = new MarcaImp();
            try
            {
                return marcaImp.MarcaExiste(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
