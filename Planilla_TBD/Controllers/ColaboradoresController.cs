using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Planilla_TBD.BD;
using Planilla_TBD.Domain;
using Planilla_TBD.Models;
using WebApplication1.Models;

namespace Planilla_TBD.Controllers
{
    public class ColaboradoresController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public COLABORADORES colab = new COLABORADORES(con);
        IList<ColaboradoresListModel> ListColab = new List<ColaboradoresListModel>();
        public ActionResult ColaboradoresList()
        {   
            DataTable dt = colab.GetData();
            foreach (DataRow r in dt.Rows)
            {
                ColaboradoresListModel c = new ColaboradoresListModel();
                c.ID_COLABORADOR = r["ID_COLABORADOR"].ToString();
                c.ID_DEPARTAMENTO = r["ID_DEPARTAMENTO"].ToString();
                c.ID_TIPO = (int) r["ID_TIPO"];
                c.ID_SUPERIOR = r["ID_SUPERIOR"].ToString();
                c.PRIMER_NOMBRE = r["PRIMER_NOMBRE"].ToString();
                c.SEGUNDO_NOMBRE = r["SEGUNDO_APELLIDO"].ToString();
                c.PRIMER_APELLIDO = r["PRIMER_APELLIDO"].ToString();
                c.SEGUNDO_APELLIDO = r["SEGUNDO_APELLIDO"].ToString();
                c.FECHA_NACIMIENTO = DateTime.Parse(r["FECHA_NACIMIENTO"].ToString()).Date.ToString("yyyy/MM/dd"); 
                c.SALARIO_BASE = float.Parse(r["SALARIO_BASE"].ToString());
                c.GRADO = (int) r["GRADO"];
                c.SEXO = r["SEXO"].ToString()[0];
                c.CEDULA = r["CEDULA"].ToString();
                ListColab.Add(c);
            }
            return View(ListColab);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Create(CreateColaborador modelo)
        {
            if (ModelState.IsValid)
            {
                modelo.SEGUNDO_NOMBRE = " ";
                modelo.SEGUNDO_APELLIDO = " ";
                colab.Insertar(modelo.ID_DEPARTAMENTO, modelo.ID_TIPO, modelo.ID_SUPERIOR,
                    modelo.PRIMER_NOMBRE, modelo.SEGUNDO_NOMBRE, modelo.PRIMER_APELLIDO,
                    modelo.SEGUNDO_APELLIDO, DateTime.Parse(modelo.FECHA_NACIMIENTO) , modelo.SALARIO_BASE,
                    modelo.GRADO, modelo.SEXO, modelo.CEDULA);
                return RedirectToAction("ColaboradoresList");
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(String id, String depto, int tipo, String jefe, String pn,
                                String sn, String pa, String sa, string fecha_nac, float sal_base
                                , int grado, char sexo, String cedula)
        {
            EditColaborador modelo = new EditColaborador();
            modelo.ID_COLABORADOR = id;
            modelo.ID_DEPARTAMENTO = depto;
            modelo.ID_TIPO = tipo;
            modelo.ID_SUPERIOR = jefe;
            modelo.PRIMER_NOMBRE = pn;
            modelo.SEGUNDO_NOMBRE = sn;
            modelo.PRIMER_APELLIDO = pa;
            modelo.SEGUNDO_APELLIDO = sa;
            modelo.FECHA_NACIMIENTO = DateTime.Parse(fecha_nac).Date.ToString("yyyy/MM/dd");
            modelo.SALARIO_BASE = sal_base;
            modelo.GRADO = grado;
            modelo.SEXO = sexo;
            modelo.CEDULA = cedula;

            return View(modelo);
        
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditColaborador modelo)
        {
            if (ModelState.IsValid)
            {
                
                    colab.Actualizar(modelo.ID_COLABORADOR ,modelo.ID_DEPARTAMENTO, modelo.ID_TIPO, modelo.ID_SUPERIOR,
                    modelo.PRIMER_NOMBRE, modelo.SEGUNDO_NOMBRE, modelo.PRIMER_APELLIDO,
                    modelo.SEGUNDO_APELLIDO,DateTime.Parse(modelo.FECHA_NACIMIENTO), modelo.SALARIO_BASE,
                    modelo.GRADO, modelo.SEXO, modelo.CEDULA);
                return RedirectToAction("ColaboradoresList");
            }       
            return View(modelo);
        }

        public ActionResult Delete(string id)
        {
            colab.Eliminar(id);
            return RedirectToAction("ColaboradoresList");
        }

        public ActionResult Detail(string id)
        {
            ColaboradoresDetail cd = new ColaboradoresDetail();
          DataTable dt=  colab.GetDataFuncion(id);

            foreach (DataRow r in dt.Rows)
            {
               
                cd.ID_COLABORADOR = r["ID_COLABORADOR"].ToString();
                cd.ID_DEPARTAMENTO = r["ID_DEPARTAMENTO"].ToString();
                cd.ID_TIPO = (int)r["ID_TIPO"];
                cd.ID_SUPERIOR = r["ID_SUPERIOR"].ToString();
                cd.PRIMER_NOMBRE = r["PRIMER_NOMBRE"].ToString();
                cd.SEGUNDO_NOMBRE = r["SEGUNDO_APELLIDO"].ToString();
                cd.PRIMER_APELLIDO = r["PRIMER_APELLIDO"].ToString();
                cd.SEGUNDO_APELLIDO = r["SEGUNDO_APELLIDO"].ToString();
                cd.FECHA_NACIMIENTO = DateTime.Parse(r["FECHA_NACIMIENTO"].ToString()).Date.ToString("yyyy/MM/dd");
                cd.SALARIO_BASE = float.Parse(r["SALARIO_BASE"].ToString());
                cd.GRADO = (int)r["GRADO"];
                cd.SEXO = r["SEXO"].ToString()[0];
                cd.CEDULA = r["CEDULA"].ToString();
                
            }
           
            return View(cd);
        }
    }
}
