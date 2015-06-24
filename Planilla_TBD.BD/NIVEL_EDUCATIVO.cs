using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.BD
{
    public class NIVEL_EDUCATIVO
    {
        private SqlConnection _connection;

        public NIVEL_EDUCATIVO(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Insertar(string ID_COLABORADOR, string NOMBRE, int AÑO, string TITULO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_NIVEL_EDUCATIVO_INSERT";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value =AÑO;
                cmd.Parameters.Add("@TITULO", SqlDbType.VarChar).Value = TITULO;
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
                cmd.CommandText = "SP_NIVEL_EDUCATIVO_SELECT";
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

        public bool Actualizar(int ID_NIVEL_EDUCATIVO, string ID_COLABORADOR, string NOMBRE,
                               int AÑO, string TITULO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_NIVEL_EDUCATIVO_UPDATE";
                cmd.Parameters.Add("@ID_NIVEL_EDUCATIVO", SqlDbType.Int).Value = ID_NIVEL_EDUCATIVO;
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = AÑO;
                cmd.Parameters.Add("@TITULO", SqlDbType.VarChar).Value = TITULO;
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
        public bool Eliminar(int ID_NIVEL_EDUCATIVO, string ID_COLABORADOR)
        {
            SqlCommand cmd = null;
            try
            {

                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_NIVEL_EDUCATIVO_DELETE";

                cmd.Parameters.Add("@ID_NIVEL_EDUCATIVO", SqlDbType.VarChar).Value = ID_NIVEL_EDUCATIVO;
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
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
