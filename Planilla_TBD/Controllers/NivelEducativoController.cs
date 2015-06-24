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
    public class NivelEducativoController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public NIVEL_EDUCATIVO NE = new NIVEL_EDUCATIVO(con);
        IList<NivelEducativoListModel> ListNE = new List<NivelEducativoListModel>();
        public ActionResult NivelEducativoList(string ID_COLABORADOR)
        {
            DataTable dt = NE.GetDataFuncion(ID_COLABORADOR);
            foreach (DataRow r in dt.Rows)
            {
                NivelEducativoListModel c = new NivelEducativoListModel();
                c.ID_NIVEL_EDUCATIVO = (int)r["ID_NIVEL_EDUCATIVO"];
                c.ID_COLABORADOR = r["ID_COLABORADOR"].ToString();
                c.NOMBRE = r["NOMBRE"].ToString();
                c.TITULO = r["TITULO"].ToString();
                c.AÑO = (int)r["AÑO"];
                ListNE.Add(c);
            }
            return View(ListNE);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Create(string ID_COLABORADOR)
        {
            CreateNivelEducativo modelo = new CreateNivelEducativo();
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            return View(modelo);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateNivelEducativo modelo, string id)
        {
            if (ModelState.IsValid)
            {
                modelo.ID_COLABORADOR = id;
                NE.Insertar(modelo.ID_COLABORADOR,modelo.NOMBRE,modelo.AÑO,modelo.TITULO);
                return RedirectToAction("NivelEducativoList", "NivelEducativo",new{ID_COLABORADOR = modelo.ID_COLABORADOR});
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id, string ID_COLABORADOR, string NOMBRE,int AÑO, string TITULO)
        {
            EditNivelEducativo modelo = new EditNivelEducativo();
            modelo.ID_NIVEL_EDUCATIVO = id;
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            modelo.NOMBRE = NOMBRE;
            modelo.AÑO = AÑO;
            modelo.TITULO = TITULO;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditNivelEducativo modelo)
        {
            if (ModelState.IsValid)
            {

                NE.Actualizar(modelo.ID_NIVEL_EDUCATIVO, modelo.ID_COLABORADOR, modelo.NOMBRE,modelo.AÑO,modelo.TITULO);
                return RedirectToAction("NivelEducativoList", new { ID_COLABORADOR = modelo.ID_COLABORADOR });
            }
            return View(modelo);
        }

        public ActionResult Delete(int id, string ID_COLABORADOR)
        {
            NE.Eliminar(id, ID_COLABORADOR);
            return RedirectToAction("NivelEducativoList", new { ID_COLABORADOR = ID_COLABORADOR });
        }
    }
}
