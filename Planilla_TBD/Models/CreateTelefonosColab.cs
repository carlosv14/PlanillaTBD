using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class CreateTelefonosColab
    {
        
        [Required]
        public string ID_COLABORADOR { get; set; }
        [Required]
        public int TELEFONO { get; set; }
        [Required]
        public int TIPO { get; set; }
    }
}