using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_TBD.Domain
{
    public class Colaboradores 
    {
        string ID_COLABORADOR { get; set; }
        string ID_DEPARTAMENTO { get; set; }
        int ID_TIPO { get; set; }
        string ID_SUPERIOR { get; set; }
        string PRIMER_NOMBRE { get; set; }
        string SEGUNDO_NOMBRE { get; set; }
        string PRIMER_APELLIDO { get; set; }
        string SEGUNDO_APELLIDO { get; set; }
        DateTime FECHA_NACIMIENTO { get; set; }
        float SALARIO_BASE { get; set; }
        int GRADO { get; set; }
        char SEXO { get; set; }
        string CEDULA { get; set; }
      }
}
