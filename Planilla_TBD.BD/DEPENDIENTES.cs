using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.BD
{
    public class DEPENDIENTES
    {
        private SqlConnection _connection;

        public DEPENDIENTES(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Insert(string ID_COLABORADOR, string PRIMER_NOMBRE, 
            string SEGUNDO_NOMBRE, string PRIMER_APELLIDO, string SEGUNDO_APELLIDO, string TIPO, DateTime FECHA_NACIMIENTO)
            {
                SqlCommand cmd = null;
                try
                {
                    _connection.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = _connection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_DEPENDIENTES_INSERT";
                    cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;   
                    cmd.Parameters.Add("@PRIMER_NOMBRE", SqlDbType.VarChar).Value = PRIMER_NOMBRE;
                    cmd.Parameters.Add("@SEGUNDO_NOMBRE", SqlDbType.VarChar).Value = SEGUNDO_NOMBRE;
                    cmd.Parameters.Add("@PRIMER_APELLIDO", SqlDbType.VarChar).Value = PRIMER_APELLIDO;
                    cmd.Parameters.Add("@SEGUNDO_APELLIDO", SqlDbType.VarChar).Value = SEGUNDO_APELLIDO;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO;   
                    cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.DateTime).Value = FECHA_NACIMIENTO;
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
                cmd.CommandText = "SP_DEPENDIENTES_SELECT";

                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                da.Dispose();
                cmd.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                //Atrapar el error y mostrarlo al usuario
                throw ex;
                return null;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

        }

        public bool Actualizar(string ID_COLABORADOR, int ID_DEPENDIENTE,string PRIMER_NOMBRE,
            string SEGUNDO_NOMBRE, string PRIMER_APELLIDO, string SEGUNDO_APELLIDO,
           string TIPO, DateTime FECHA_NACIMIENTO)
        {
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DEPENDIENTES_UPDATE";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@ID_DEPENDIENTE", SqlDbType.Int).Value = ID_DEPENDIENTE;
                cmd.Parameters.Add("@PRIMER_NOMBRE", SqlDbType.VarChar).Value = PRIMER_NOMBRE;
                cmd.Parameters.Add("@SEGUNDO_NOMBRE", SqlDbType.VarChar).Value = SEGUNDO_NOMBRE;
                cmd.Parameters.Add("@PRIMER_APELLIDO", SqlDbType.VarChar).Value = PRIMER_APELLIDO;
                cmd.Parameters.Add("@SEGUNDO_APELLIDO", SqlDbType.VarChar).Value = SEGUNDO_APELLIDO;
                cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO;
                cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.DateTime).Value = FECHA_NACIMIENTO;
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
        public bool Eliminar(string ID_COLABORADOR, int ID_DEPENDIENTE)
        {
            SqlCommand cmd = null;
            try
            {

                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DEPENDIENTES_DELETE";

                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@ID_DEPENDIENTE", SqlDbType.Int).Value = ID_DEPENDIENTE;
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
        public DataTable GetData()
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _connection;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT
                                        * FROM DEPENDIENTES";
                
                da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                da.Dispose();
                cmd.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                //Atrapar el error y mostrarlo al usuario
                throw ex;
                return null;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

        }


    }
}
