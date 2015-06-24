using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Planilla_TBD.BD
{
    public class PARAMETROS
    {
        private SqlConnection _connection;

        public PARAMETROS(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Insertar(int TIPO, string NOMBRE, string FORMULA)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_PARAMETROS_INSERT";
                cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = TIPO;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@FORMULA", SqlDbType.VarChar).Value = FORMULA;
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
        public DataTable GetDataFuncion()
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_PARAMETROS_SELECT";

                da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                da.Dispose();
                cmd.Dispose();

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
                return null;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

        }

        public bool Actualizar(int ID_PARAMETRO, int TIPO, string NOMBRE, string FORMULA)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_PARAMETROS_UPDATE";
                cmd.Parameters.Add("@ID_PARAMETRO", SqlDbType.Int).Value = ID_PARAMETRO;
                cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = TIPO;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@FORMULA", SqlDbType.VarChar).Value = FORMULA;
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
        public bool Eliminar(int ID_PARAMETRO)
        {
            SqlCommand cmd = null;
            try
            {

                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_PARAMETROS_DELETE";

                cmd.Parameters.Add("@ID_PARAMETRO", SqlDbType.Int).Value = ID_PARAMETRO;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                //Atrapar el error y mostrarlo al usuario
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
