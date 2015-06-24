using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class CreateColaboradorParametro
    {
        [Required]
        public string ID_COLABORADOR { get; set; }
        [Required]
        public int ID_PARAMETRO { get; set; }
    }
}