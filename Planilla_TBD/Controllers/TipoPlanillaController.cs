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
    public class TipoPlanillaController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public TIPO_PLANILLAS TipoPlanillas = new TIPO_PLANILLAS(con);
        IList<TipoPlanillaListModel> ListTipo = new List<TipoPlanillaListModel>();
        public ActionResult TipoPlanillaList()
        {
            DataTable dt = TipoPlanillas.GetDataFuncion();
            foreach (DataRow r in dt.Rows)
            {
                TipoPlanillaListModel c = new TipoPlanillaListModel();
                c.ID_TIPO= (int)r["ID_TIPO"];
                c.TIPO_PAGO=(int) r["TIPO_PAGO"];
                c.NOMBRE = r["NOMBRE"].ToString();
              ListTipo.Add(c);
            }
            return View(ListTipo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {
            CreateTipoPlanilla modelo = new CreateTipoPlanilla();
          
            return View(modelo);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateTipoPlanilla modelo)
        {
            if (ModelState.IsValid)
            {

                TipoPlanillas.Insertar(modelo.NOMBRE,modelo.TIPO_PAGO);
                return RedirectToAction("TipoPlanillaList", "TipoPlanilla");
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int ID_TIPO, int TIPO_PAGO , string NOMBRE)
        {
            EditTipoPlanilla modelo = new EditTipoPlanilla();
            modelo.ID_TIPO= ID_TIPO;
            modelo.TIPO_PAGO = TIPO_PAGO;
            modelo.NOMBRE = NOMBRE;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditTipoPlanilla modelo)
        {
            if (ModelState.IsValid)
            {

                TipoPlanillas.Actualizar(modelo.ID_TIPO,modelo.NOMBRE,modelo.TIPO_PAGO);
                return RedirectToAction("TipoPlanillaList");
            }
            return View(modelo);
        }

        public ActionResult Delete(int ID_TIPO)
        {
            TipoPlanillas.Eliminar(ID_TIPO);
            return RedirectToAction("TipoPlanillaList");
        }

    }
}
