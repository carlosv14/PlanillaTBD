using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class PlanillasListModel
    {
        public string ID_PLANILLA { get; set; }
        public int ID_TIPO { get; set; }
        public string NOMBRE { get; set; }
        public string FECHA_INICIO { get; set; }
        public string FECHA_FINAL { get; set; }

    }
}