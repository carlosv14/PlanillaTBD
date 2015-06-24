using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.BD
{
   public class DEPARTAMENTOS
    {
        private SqlConnection _conection = null;
           public DEPARTAMENTOS(SqlConnection conection)
        {
            _conection = conection;
        }

        public bool Insertar(string NOMBRE)
         {
          SqlCommand cmd = null;
            try
            {
                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SP_DEPARTAMENTO_INSERT";
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
                if (_conection.State != ConnectionState.Closed)
                    _conection.Close();
            }
		
         }
        public DataTable GetDataFuncion()
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT *
									FROM 
										DEPARTAMENTOS";


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
                if (_conection.State != ConnectionState.Closed)
                    _conection.Close();
            }

        }

        public bool Actualizar(string ID_DEPARTAMENTO, string NOMBRE)
        {
            SqlCommand cmd = null;
            try
            {
                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DEPARTAMENTOS_UPDATE";
                cmd.Parameters.Add("@ID_DEPARTAMENTO", SqlDbType.VarChar).Value = ID_DEPARTAMENTO;
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
                if (_conection.State != ConnectionState.Closed)
                    _conection.Close();
            }

        }
        public bool Eliminar(string ID_DEPARTAMENTO)
        {
            SqlCommand cmd = null;
            try
            {

                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DEPARTAMENTOS_DELETE";

                cmd.Parameters.Add("@ID_DEPARTAMENTO", SqlDbType.VarChar).Value = ID_DEPARTAMENTO;

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
                if (_conection.State != ConnectionState.Closed)
                    _conection.Close();
            }

        }
    }
}
