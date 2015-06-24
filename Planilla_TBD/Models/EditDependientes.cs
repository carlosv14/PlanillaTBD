using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class EditDependientes
    {
        [Required]
        public string ID_COLABORADOR { get; set; }
        [Required]
        public int ID_DEPENDIENTE { get; set; }
        [Required]
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        [Required]
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        [Required]
        public string TIPO { get; set; }
        [Required]
        public string FECHA_NACIMIENTO { get; set; }
    }
}