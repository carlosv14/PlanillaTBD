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
    public class ColaboradoresParametrosController :Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);

        public COLABORADORES_PARAMETROS ColaboradoresParametros = new COLABORADORES_PARAMETROS(con);
        IList<ColaboradoresParametrosListModel> ListColabParam= new List<ColaboradoresParametrosListModel>();
        public ActionResult ColaboradoresParametrosList(string ID_COLABORADOR)
        {
            DataTable dt = ColaboradoresParametros.GetDataFuncion(ID_COLABORADOR);
            foreach (DataRow r in dt.Rows)
            {
                ColaboradoresParametrosListModel c = new ColaboradoresParametrosListModel();
                c.ID_PARAMETRO = (int)r["ID_PARAMETRO"];
                c.ID_COLABORADOR = r["ID_COLABORADOR"].ToString();
                ListColabParam.Add(c);
            }
            return View(ListColabParam);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Create(string ID_COLABORADOR)
        {
            CreateColaboradorParametro modelo = new CreateColaboradorParametro();
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            modelo.ID_PARAMETRO = 0;
            return View(modelo);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateColaboradorParametro modelo, string ID_COLABORADOR)
        {
            if (ModelState.IsValid)
            {
                modelo.ID_COLABORADOR = ID_COLABORADOR;
                ColaboradoresParametros.Insertar(modelo.ID_COLABORADOR, modelo.ID_PARAMETRO);
                return RedirectToAction("ColaboradoresParametrosList", new { ID_COLABORADOR = modelo.ID_COLABORADOR });
            }
            return View(modelo);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int ID_PARAMETRO, string ID_COLABORADOR)
        {
            EditColaboradorParametro modelo = new EditColaboradorParametro();
            modelo.ID_PARAMETRO = ID_PARAMETRO;
            modelo.ID_COLABORADOR = ID_COLABORADOR;
            return View(modelo);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(EditColaboradorParametro modelo)
        {
            if (ModelState.IsValid)
            {

                ColaboradoresParametros.Actualizar( modelo.ID_COLABORADOR, modelo.ID_PARAMETRO);
                return RedirectToAction("ColaboradoresParametrosList", new { ID_COLABORADOR = modelo.ID_COLABORADOR });
            }
            return View(modelo);
        }

        public ActionResult Delete(int ID_PARAMETRO, string ID_COLABORADOR)
        {
            ColaboradoresParametros.Eliminar( ID_COLABORADOR,ID_PARAMETRO);
            return RedirectToAction("ColaboradoresParametrosList",new{ID_COLABORADOR=ID_COLABORADOR});
        }
    }
}
