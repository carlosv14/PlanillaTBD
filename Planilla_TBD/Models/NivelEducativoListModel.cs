using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class NivelEducativoListModel
    {
        public int ID_NIVEL_EDUCATIVO { get; set; }
        public string ID_COLABORADOR { get; set; }
        public string NOMBRE { get; set; }
        public int AÑO { get; set; }
        public string TITULO { get; set; }

    }
}