using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.BD
{
    public class PLANILLAS
    {
        private SqlConnection _connection;

        public PLANILLAS(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Insertar(int ID_TIPO, string NOMBRE, DateTime F_INICIO, DateTime F_FINAL)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_PLANILLA_INSERT";
                cmd.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = ID_TIPO;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value =F_INICIO;
                cmd.Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime).Value = F_FINAL;
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
                cmd.CommandText = "SP_PLANILLA_SELECT";
                
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

        public bool Actualizar(string ID_PLANILLA,int ID_TIPO, string NOMBRE, DateTime F_INICIO, DateTime F_FINAL)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_PLANILLA_UPDATE";
                cmd.Parameters.Add("@ID_PLANILLA", SqlDbType.VarChar).Value = ID_PLANILLA;
                cmd.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = ID_TIPO;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = F_INICIO;
                cmd.Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime).Value = F_FINAL;
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
        public bool Eliminar(string ID_PLANILLA)
        {
            SqlCommand cmd = null;
            try
            {

                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_PLANILLA_DELETE";

                cmd.Parameters.Add("@ID_PLANILLA", SqlDbType.VarChar).Value = ID_PLANILLA;
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
