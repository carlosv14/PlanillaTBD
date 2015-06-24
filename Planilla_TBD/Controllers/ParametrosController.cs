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

namespace Planilla_TBD.Controllers
{
    public class ParametrosController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public PARAMETROS param = new PARAMETROS(con);
        IList<ParametrosListModel> Listp = new List<ParametrosListModel>();
        public ActionResult ParametrosList()
        {
            DataTable dt = param.GetDataFuncion();
            foreach (DataRow r in dt.Rows)
            {
                ParametrosListModel c = new ParametrosListModel();
                c.ID_PARAMETRO = (int)r["ID_PARAMETRO"];
                c.TIPO = (int)r["TIPO"];
                c.FORMULA= r["FORMULA"].ToString();
                c.NOMBRE =r["NOMBRE"].ToString();
                Listp.Add(c);
            }
            return View(Listp);
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {

            CreateParametro modelo = new CreateParametro();
            return View(modelo);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateParametro modelo)
        {
            if (ModelState.IsValid)
            {
                param.Insertar(modelo.TIPO, modelo.NOMBRE, modelo.FORMULA);
                return RedirectToAction("ParametrosList");
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int ID_PARAMETRO, int TIPO, string NOMBRE, string FORMULA)
        {
            EditParametro modelo = new EditParametro();
            modelo.ID_PARAMETRO = ID_PARAMETRO;
            modelo.TIPO = TIPO;
            modelo.NOMBRE = NOMBRE;
            modelo.FORMULA = FORMULA;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditParametro modelo)
        {
            if (ModelState.IsValid)
            {

                param.Actualizar(modelo.ID_PARAMETRO, modelo.TIPO, modelo.NOMBRE,
                   modelo.FORMULA);
                return RedirectToAction("ParametrosList");
            }
            return View(modelo);
        }

        public ActionResult Delete(int ID_PARAMETRO)
        {
            param.Eliminar(ID_PARAMETRO);
            return RedirectToAction("ParametrosList");
        }

    }
}
