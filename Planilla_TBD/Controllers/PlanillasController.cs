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
using System.Web.UI.WebControls;
using Planilla_TBD.BD;
using Planilla_TBD.Models;

namespace Planilla_TBD.Controllers
{
    public class PlanillasController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public PLANILLAS planilla = new PLANILLAS(con);
        IList<PlanillasListModel> Listp = new List<PlanillasListModel>();
        public ActionResult PlanillasList()
        {
            DataTable dt = planilla.GetDataFuncion();
            foreach (DataRow r in dt.Rows)
            {
                PlanillasListModel c = new PlanillasListModel();
                c.ID_PLANILLA = r["ID_PLANILLA"].ToString();
                c.ID_TIPO = (int)r["ID_TIPO"];
                c.NOMBRE = r["NOMBRE"].ToString();
                c.FECHA_INICIO = DateTime.Parse(r["FECHA_INICIO"].ToString()).Date.ToString("yyyy/MM/dd");
                c.FECHA_FINAL = DateTime.Parse(r["FECHA_FINAL"].ToString()).Date.ToString("yyyy/MM/dd"); 
                Listp.Add(c);
            }
            return View(Listp);
        }
          [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {
         
              CreatePlanilla modelo = new CreatePlanilla();
            return View(modelo);
        }
        
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreatePlanilla modelo)
        {
            if (ModelState.IsValid)
            {
                planilla.Insertar(modelo.ID_TIPO, modelo.NOMBRE, DateTime.Parse(modelo.FECHA_INICIO), DateTime.Parse(modelo.FECHA_FINAL));
                return RedirectToAction("PlanillasList", "Planillas");
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(string id,int ID_TIPO,string NOMBRE, string FECHA_INICIO,string FECHA_FINAL)
        {
            EditPlanilla modelo = new EditPlanilla();
            modelo.ID_PLANILLA = id;
            modelo.ID_TIPO = ID_TIPO;
            modelo.NOMBRE = NOMBRE;
            modelo.FECHA_INICIO = FECHA_INICIO;
            modelo.FECHA_FINAL = FECHA_FINAL;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditPlanilla modelo)
        {
            if (ModelState.IsValid)
            {

                planilla.Actualizar(modelo.ID_PLANILLA, modelo.ID_TIPO, modelo.NOMBRE,
                    DateTime.Parse(modelo.FECHA_INICIO), DateTime.Parse(modelo.FECHA_FINAL));
                return RedirectToAction("PlanillasList", "Planillas");
            }
            return View(modelo);
        }

        public ActionResult Delete(string id)
        {
            planilla.Eliminar(id);
            return RedirectToAction("PlanillasList");
        }


    }
}
