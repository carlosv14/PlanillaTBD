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
    public class TelefonosColabController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public TELEFONOS_COLAB TColab = new TELEFONOS_COLAB(con);
        IList<TelefonosColabListModel> List_tc = new List<TelefonosColabListModel>();
        public ActionResult TelefonosColabList(string ID_COLABORADOR)
        {
            DataTable dt = TColab.GetDataFuncion(ID_COLABORADOR);
            foreach (DataRow r in dt.Rows)
            {
                TelefonosColabListModel c = new TelefonosColabListModel();
                c.ID_TELEFONO=(int)r["ID_TELEFONO"];
                c.ID_COLABORADOR = r["ID_COLABORADOR"].ToString();
                c.TELEFONO = (int)r["TELEFONO"];
                c.TIPO = (int)r["TIPO"];
                List_tc.Add(c);
            }
            return View(List_tc);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Create(string ID_COLABORADOR)
        {

           
             CreateTelefonosColab modelo = new CreateTelefonosColab();
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            return View(modelo);
        }


        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateTelefonosColab modelo)
        {
            if (ModelState.IsValid)
            {

                TColab.Insertar(modelo.ID_COLABORADOR,modelo.TELEFONO,modelo.TIPO);
                return RedirectToAction("TelefonosColabList",new{ID_COLABORADOR = modelo.ID_COLABORADOR});
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id, string ID_COLABORADOR, int TELEFONO,int TIPO)
        {
            EditTelefonosColab modelo = new EditTelefonosColab();
            modelo.ID_TELEFONO = id;
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            modelo.TELEFONO = TELEFONO;
            modelo.TIPO = TIPO;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditTelefonosColab modelo)
        {
            if (ModelState.IsValid)
            {

                TColab.Actualizar(modelo.ID_TELEFONO, modelo.ID_COLABORADOR,modelo.TELEFONO,modelo.TIPO);
                return RedirectToAction("TelefonosColabList", new {ID_COLABORADOR = modelo.ID_COLABORADOR});
            }
            return View(modelo);
        }

        public ActionResult Delete(int id,string ID_COLABORADOR)
        {
            TColab.Eliminar(id,ID_COLABORADOR);
            return RedirectToAction("TelefonosColabList",new{ID_COLABORADOR=ID_COLABORADOR});
        }
    }
}
