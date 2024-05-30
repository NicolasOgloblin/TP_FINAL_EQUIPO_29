using System;
using System.Data.SqlClient;

namespace Dao.DataAccessObject
{
    internal class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            command = new SqlCommand();
        }

        public void setearParametro(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);
        }

        public void setearConsulta(string consulta)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int ejecutarAccion()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
               return command.ExecuteNonQuery(); //Si no pudo hacerse la insercion va a devolver 0

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if(reader != null) reader.Close();
            connection.Close();
        }

    }
}
