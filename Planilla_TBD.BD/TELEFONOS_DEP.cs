using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.BD
{
    public class TELEFONOS_DEP
    {
        private SqlConnection _connection;

        public TELEFONOS_DEP(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Insertar(int ID_DEPENDIENTE, string ID_COLABORADOR, int TELEFONO, int TIPO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_TELEFONOS_DEP_INSERT";
                cmd.Parameters.Add("@ID_DEPENDIENTE", SqlDbType.Int).Value = ID_DEPENDIENTE;
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = TELEFONO;
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
