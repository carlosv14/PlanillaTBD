using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Planilla_TBD.BD;
namespace Planilla_TBD.Controllers
{
    public class HomeController : Controller
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        public DEPARTAMENTOS depto = new DEPARTAMENTOS(con);
        public TIPO_PLANILLAS TIPO = new TIPO_PLANILLAS(con);
        
        public DEPENDIENTES dep = new DEPENDIENTES(con);
        public DIRECCIONES dir = new DIRECCIONES(con);
        public HOBBIES Hobbie = new HOBBIES(con);
        public NIVEL_EDUCATIVO NivelEductavio = new NIVEL_EDUCATIVO(con);
        public PARAMETROS param = new PARAMETROS(con);
        public PLANILLAS Planilla = new PLANILLAS(con);
        public TELEFONOS_COLAB TelefonosColab = new TELEFONOS_COLAB(con);
        public TELEFONOS_DEP TelefonosDep = new TELEFONOS_DEP(con);
        public COLABORADORES_PARAMETROS CpParametros = new COLABORADORES_PARAMETROS(con);
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}