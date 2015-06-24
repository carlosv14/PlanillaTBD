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
    public class HobbiesController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public HOBBIES hobbie = new HOBBIES(con);
        IList<HobbiesListModel> Listhob = new List<HobbiesListModel>();
        public ActionResult HobbiesList(string ID_COLABORADOR)
        {
            DataTable dt = hobbie.GetDataFuncion(ID_COLABORADOR);
            foreach (DataRow r in dt.Rows)
            {
                HobbiesListModel c = new HobbiesListModel();
                c.ID_HOBBIE = (int)r["ID_HOBBIE"];
                c.ID_COLABORADOR = r["ID_COLABORADOR"].ToString();
                c.HOBBIE = r["HOBBIE"].ToString();
                Listhob.Add(c);
            }
            return View(Listhob);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Create( string id)
        {
           CreateHobbie modelo = new CreateHobbie();
            modelo.ID_COLABORADOR = id;
            return View(modelo);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateHobbie modelo,string id)
        {
            if (ModelState.IsValid)
            {
                modelo.ID_COLABORADOR = id;
                hobbie.Insertar(modelo.ID_COLABORADOR,modelo.HOBBIE);
                return RedirectToAction("ColaboradoresList","Colaboradores");
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id,string ID_COLABORADOR, string HOBBIE)
        {
            EditHobbie modelo = new EditHobbie();
            modelo.ID_HOBBIE = id;
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            modelo.HOBBIE = HOBBIE;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditHobbie modelo)
        {
            if (ModelState.IsValid)
            {

                hobbie.Actualizar(modelo.ID_HOBBIE,modelo.ID_COLABORADOR, modelo.HOBBIE);
                return RedirectToAction("HobbiesList",new{ID_COLABORADOR = modelo.ID_COLABORADOR});
            }
            return View(modelo);
        }

        public ActionResult Delete(int id,string ID_COLABORADOR)
        {
            hobbie.Eliminar(id,ID_COLABORADOR);
            return RedirectToAction("HobbiesList",new {ID_COLABORADOR = ID_COLABORADOR});
        }

    }
}
