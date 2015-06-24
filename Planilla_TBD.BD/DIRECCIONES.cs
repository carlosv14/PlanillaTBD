using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.BD
{
    public class DIRECCIONES
    {
        private SqlConnection _connection;

        public DIRECCIONES(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Insertar(string ID_COLABORADOR, int CALLE, int AVENIDA, string COLONIA, int NUM_CASA, string MUNICIPIO,
            string DEPARTAMENTO, int TIPO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_DIRECCIONES_INSERT";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@CALLE", SqlDbType.Int).Value = CALLE;
                cmd.Parameters.Add("@AVENIDA", SqlDbType.Int).Value = AVENIDA;
                cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = COLONIA;
                cmd.Parameters.Add("@N_CASA", SqlDbType.Int).Value = NUM_CASA;
                cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = MUNICIPIO;
                cmd.Parameters.Add("@DEPARTAMENTO", SqlDbType.VarChar).Value = DEPARTAMENTO;
                cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = TIPO;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception EX)
            {

                return false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

        }
    }
}
