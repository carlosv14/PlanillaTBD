using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class DependientesListModel
    {
        public string ID_COLABORADOR { get; set; }
        public int ID_DEPENDIENTE{ get; set; }
        public string PRIMER_NOMBRE{ get; set; }
        public string SEGUNDO_NOMBRE{ get; set; }
        public string PRIMER_APELLIDO{ get; set; }
        public string SEGUNDO_APELLIDO{ get; set; }
        public string TIPO{ get; set; }
        public string FECHA_NACIMIENTO { get; set; }
    }
}