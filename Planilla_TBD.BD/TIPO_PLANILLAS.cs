using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Planilla_TBD.BD
{
    public class TIPO_PLANILLAS
    {
        private SqlConnection _connection;

        public TIPO_PLANILLAS(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Insertar(string NOMBRE, int TIPO_PAGO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_TIPO_PLANILLA_INSERT";
                cmd.Parameters.Add("@TIPO_PAGO", SqlDbType.Int).Value = TIPO_PAGO;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
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
                cmd.CommandText = "SP_TIPO_PLANILLA_SELECT";
      
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

        public bool Actualizar(int ID_TIPO,string NOMBRE, int TIPO_PAGO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_TIPO_PLANILLA_UPDATE";
                cmd.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = ID_TIPO;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@TIPO_PAGO", SqlDbType.Int).Value = TIPO_PAGO;
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
        public bool Eliminar(int ID_TIPO)
        {
            SqlCommand cmd = null;
            try
            {

                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_TIPO_PLANILLA_DELETE";

                cmd.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = ID_TIPO;
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