using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class EditParametro
    {
        [Required]
        public int ID_PARAMETRO { get; set; }
         [Required]
        public int TIPO { get; set; }
         [Required]
        public string NOMBRE { get; set; }
         [Required]
        public string FORMULA { get; set; }
    }
}