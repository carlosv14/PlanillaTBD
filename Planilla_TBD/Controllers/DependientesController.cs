using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Planilla_TBD.BD;
using Planilla_TBD.Models;
using WebApplication1.Models;

namespace Planilla_TBD.Controllers
{
    public class DependientesController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public DEPENDIENTES dep = new DEPENDIENTES(con);
        IList<DependientesListModel> ListDep= new List<DependientesListModel>();
        public ActionResult DependientesList(string ID_COLABORADOR)
        {
            DataTable dt = dep.GetDataFuncion(ID_COLABORADOR);
            foreach (DataRow r in dt.Rows)
            {
                DependientesListModel c = new DependientesListModel();
                c.ID_COLABORADOR = r["ID_COLABORADOR"].ToString();
                c.ID_DEPENDIENTE = (int)r["ID_DEPENDIENTE"];
                c.PRIMER_NOMBRE = r["PRIMER_NOMBRE"].ToString();
                c.SEGUNDO_NOMBRE = r["SEGUNDO_APELLIDO"].ToString();
                c.PRIMER_APELLIDO = r["PRIMER_APELLIDO"].ToString();
                c.SEGUNDO_APELLIDO = r["SEGUNDO_APELLIDO"].ToString();
                c.TIPO = r["TIPO"].ToString();
                c.FECHA_NACIMIENTO = DateTime.Parse(r["FECHA_NACIMIENTO"].ToString()).Date.ToString("yyyy/MM/dd");
               
                ListDep.Add(c);
            }
            return View(ListDep);
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult Create(string ID_COLABORADOR)
        {
           CreateDependiente modelo = new CreateDependiente();
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            return View(modelo);
        }



        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateDependiente modelo)
        {
            if (ModelState.IsValid)
            {
                modelo.SEGUNDO_NOMBRE = " ";
                modelo.SEGUNDO_APELLIDO = " ";
                dep.Insert(modelo.ID_COLABORADOR,modelo.PRIMER_NOMBRE, modelo.SEGUNDO_NOMBRE, modelo.PRIMER_APELLIDO,
                    modelo.SEGUNDO_APELLIDO,modelo.TIPO, DateTime.Parse(modelo.FECHA_NACIMIENTO));
                return RedirectToAction("DependientesList",new{ID_COLABORADOR =modelo.ID_COLABORADOR});
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(String id,int ID_DEPENDIENTE, String pn, String sn, String pa, String sa, 
                                string tipo,string fecha_nac)
        {
            EditDependientes modelo = new EditDependientes();
            modelo.ID_COLABORADOR = id;
            modelo.ID_DEPENDIENTE = ID_DEPENDIENTE;
            modelo.PRIMER_NOMBRE = pn;
            modelo.SEGUNDO_NOMBRE = sn;
            modelo.PRIMER_APELLIDO = pa;
            modelo.SEGUNDO_APELLIDO = sa;
            modelo.FECHA_NACIMIENTO = DateTime.Parse(fecha_nac).Date.ToString("yyyy/MM/dd");
            modelo.TIPO = tipo;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditDependientes modelo)
        {
            if (ModelState.IsValid)
            {
               
                dep.Actualizar(modelo.ID_COLABORADOR,modelo.ID_DEPENDIENTE,modelo.PRIMER_NOMBRE,
                    modelo.SEGUNDO_NOMBRE,modelo.PRIMER_APELLIDO,modelo.SEGUNDO_APELLIDO,modelo.TIPO,
                    DateTime.Parse(modelo.FECHA_NACIMIENTO));
                return RedirectToAction("DependientesList",new{ID_COLABORADOR =  modelo.ID_COLABORADOR});
            }
            return View(modelo);
        }

        public ActionResult Delete(string id,int ID_DEPENDIENTE)
        {
            dep.Eliminar(id,ID_DEPENDIENTE);
            return RedirectToAction("DependientesList",new{ID_COLABORADOR =id});
        }

       
    }
}
