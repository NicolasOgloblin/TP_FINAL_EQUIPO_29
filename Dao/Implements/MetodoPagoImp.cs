using Dao.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Implements
{
    public class MetodoPagoImp
    {

        public int GuardarMetodoPago(string metodoPago)
        {
            DataAccess datos = new DataAccess();

            string consulta = "INSERT INTO METODO_PAGO (NOMBRE) VALUES (@nombre); SELECT SCOPE_IDENTITY()";

            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@nombre", metodoPago);

                
                var idInsertado = datos.ejecutarScalar();

                
                if (idInsertado != null && idInsertado != DBNull.Value)
                {
                    return Convert.ToInt32(idInsertado);
                }
                else
                {
                    
                    throw new Exception("No se pudo obtener el ID del método de pago insertado.");
                }
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
