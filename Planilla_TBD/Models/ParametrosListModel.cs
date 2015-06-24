using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class ParametrosListModel
    {
        public int ID_PARAMETRO { get; set; }
        public int TIPO { get; set; }
        public string NOMBRE{ get; set; }
        public string FORMULA { get; set; }
    }
}