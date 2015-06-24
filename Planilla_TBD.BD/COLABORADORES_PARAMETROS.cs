using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.BD
{
    public class COLABORADORES_PARAMETROS
    {
        private SqlConnection _connection;

        public COLABORADORES_PARAMETROS(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Insertar(string ID_COLABORADOR, int ID_PARAMETRO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_COLABORADORES_PARAMETROS_INSERT";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@ID_PARAMETRO", SqlDbType.Int).Value = ID_PARAMETRO;
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
        public DataTable GetDataFuncion(string ID_COLABORADOR)
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
                cmd.CommandText = "SP_COLABORADORES_PARAMETROS_SELECT";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;


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

        public bool Actualizar(string ID_COLABORADOR,int ID_PARAMETRO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_COLABORADORES_PARAMETROS_UPDATE";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@ID_PARAMETRO", SqlDbType.VarChar).Value = ID_PARAMETRO;
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

        public bool Eliminar(string ID_COLABORADOR, int ID_PARAMETRO)
        {
            SqlCommand cmd = null;
            try
            {

                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_COLABORADORES_PARAMETROS_DELETE";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@ID_PARAMETRO", SqlDbType.VarChar).Value = ID_PARAMETRO;
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
