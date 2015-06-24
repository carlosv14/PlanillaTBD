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
    public class DepartamentosController : Controller
    {
          private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public DEPARTAMENTOS depto = new DEPARTAMENTOS(con);
        IList<DepartamentosListModel> ListDep = new List<DepartamentosListModel>();
        public ActionResult DepartamentosList()
        {   
            DataTable dt = depto.GetDataFuncion();
            foreach (DataRow r in dt.Rows)
            {
                DepartamentosListModel c = new DepartamentosListModel();
                c.ID_DEPARTAMENTO = r["ID_DEPARTAMENTO"].ToString();
                c.NOMBRE = r["NOMBRE"].ToString();
                ListDep.Add(c);
            }
            return View(ListDep);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Create(CreateDepartamento modelo)
        {
            if (ModelState.IsValid)
            {
               
                depto.Insertar(modelo.NOMBRE);
                return RedirectToAction("DepartamentosList");
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(String id, string NOMBRE)
        {
            EditDepartamento modelo = new EditDepartamento ();
            modelo.ID_DEPARTAMENTO = id;
            modelo.NOMBRE = NOMBRE;
            return View(modelo);
        
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditDepartamento modelo)
        {
            if (ModelState.IsValid)
            {
                
                    depto.Actualizar(modelo.ID_DEPARTAMENTO,modelo.NOMBRE);
                return RedirectToAction("DepartamentosList");
            }       
            return View(modelo);
        }

        public ActionResult Delete(string id)
        {
            depto.Eliminar(id);
            return RedirectToAction("DepartamentosList");
        }
    }

    }

