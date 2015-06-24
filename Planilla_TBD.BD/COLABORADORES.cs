using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Planilla_TBD.BD
{
    public class COLABORADORES
    {
        private SqlConnection _conection = null;

        public COLABORADORES(SqlConnection conection)
        {
            _conection = conection;
        }

        public bool Insertar(string ID_DEPARTAMENTO, int ID_TIPO, string ID_SUPERIOR, string PRIMER_NOMBRE,
            string SEGUNDO_NOMBRE,
            string PRIMER_APELLIDO, string SEGUNDO_APELLIDO, DateTime FECHA_NACIMIENTO, float SALARIO_BASE, int GRADO,
            char SEXO, string CEDULA)
        {
            SqlCommand cmd = null;
            try
            {
                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_COLABORADORES_INSERT";
                cmd.Parameters.Add("@ID_DEPARTAMENTO", SqlDbType.VarChar).Value = ID_DEPARTAMENTO;
                cmd.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = ID_TIPO;
                cmd.Parameters.Add("@ID_SUPERIOR", SqlDbType.VarChar).Value = ID_SUPERIOR;
                cmd.Parameters.Add("@PRIMER_NOMBRE", SqlDbType.VarChar).Value = PRIMER_NOMBRE;
                cmd.Parameters.Add("@SEGUNDO_NOMBRE", SqlDbType.VarChar).Value = SEGUNDO_NOMBRE;
                cmd.Parameters.Add("@PRIMER_APELLIDO", SqlDbType.VarChar).Value = PRIMER_APELLIDO;
                cmd.Parameters.Add("@SEGUNDO_APELLIDO", SqlDbType.VarChar).Value = SEGUNDO_APELLIDO;
                cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.DateTime).Value = FECHA_NACIMIENTO;
                cmd.Parameters.Add("@SALARIO_BASE", SqlDbType.Float).Value = SALARIO_BASE;
                cmd.Parameters.Add("@GRADO", SqlDbType.Int).Value = GRADO;
                cmd.Parameters.Add("@SEXO", SqlDbType.Char).Value = SEXO;
                cmd.Parameters.Add("@CEDULA", SqlDbType.VarChar).Value = CEDULA;
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

        public DataTable GetDataFuncion(string ID_COLABORADOR)
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
										COLABORADORES WHERE ID_COLABORADOR = @ID_COLABORADOR";

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
                if (_conection.State != ConnectionState.Closed)
                    _conection.Close();
            }

        }

        public bool Actualizar(string ID_COLABORADOR ,string ID_DEPARTAMENTO, int ID_TIPO, string ID_SUPERIOR, string PRIMER_NOMBRE,
            string SEGUNDO_NOMBRE,
            string PRIMER_APELLIDO, string SEGUNDO_APELLIDO, DateTime FECHA_NACIMIENTO, float SALARIO_BASE, int GRADO,
            char SEXO, string CEDULA)
        {
            SqlCommand cmd = null;
            try
            {
                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_COLABORADORES_UPDATE";
                cmd.Parameters.Add("@ID_COLABORADOR", SqlDbType.VarChar).Value = ID_COLABORADOR;
                cmd.Parameters.Add("@ID_DEPARTAMENTO", SqlDbType.VarChar).Value = ID_DEPARTAMENTO;
                cmd.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = ID_TIPO;
                cmd.Parameters.Add("@ID_SUPERIOR", SqlDbType.VarChar).Value = ID_SUPERIOR;
                cmd.Parameters.Add("@PRIMER_NOMBRE", SqlDbType.VarChar).Value = PRIMER_NOMBRE;
                cmd.Parameters.Add("@SEGUNDO_NOMBRE", SqlDbType.VarChar).Value = SEGUNDO_NOMBRE;
                cmd.Parameters.Add("@PRIMER_APELLIDO", SqlDbType.VarChar).Value = PRIMER_APELLIDO;
                cmd.Parameters.Add("@SEGUNDO_APELLIDO", SqlDbType.VarChar).Value = SEGUNDO_APELLIDO;
                cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.DateTime).Value = FECHA_NACIMIENTO;
                cmd.Parameters.Add("@SALARIO_BASE", SqlDbType.Float).Value = SALARIO_BASE;
                cmd.Parameters.Add("@GRADO", SqlDbType.Int).Value = GRADO;
                cmd.Parameters.Add("@SEXO", SqlDbType.Char).Value = SEXO;
                cmd.Parameters.Add("@CEDULA", SqlDbType.VarChar).Value = CEDULA;
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
        public bool Eliminar(string ID_COLABORADOR)
        {
            SqlCommand cmd = null;
            try
            {

                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_COLABORADORES_DELETE";

                cmd.Parameters.Add("@ID_COLABORADORES", SqlDbType.VarChar).Value = ID_COLABORADOR;

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
        public DataTable GetData()
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                _conection.Open();
                cmd = new SqlCommand();
                cmd.Connection = _conection;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_COLABORADORES_SELECT";
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
                if (_conection.State != ConnectionState.Closed)
                    _conection.Close();
            }

        }
        
    }
}
    


            

      
