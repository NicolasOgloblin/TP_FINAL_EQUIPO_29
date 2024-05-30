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
        //ésto está del modificar
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
                return marcaImp.EliminarMarca(id);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int Corrobar (int id)
        {
            MarcaImp marca = new MarcaImp();
            try
            {
                return marca.Corroborar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
