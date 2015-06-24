using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planilla_TBD.BD;

namespace Planilla_TBD.Models
{
    public class ColaboradoresDetail
    {
        public string ID_COLABORADOR { get; set; }
        public string ID_DEPARTAMENTO { get; set; }
        public int ID_TIPO { get; set; }
        public string ID_SUPERIOR { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public float SALARIO_BASE { get; set; }
        public int GRADO { get; set; }
        public char SEXO { get; set; }
        public string CEDULA { get; set; }
    }
}