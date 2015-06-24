using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class CreateNivelEducativo
    {
        [Required]
        public string ID_COLABORADOR { get; set; }
         [Required]
        public string NOMBRE { get; set; }
         [Required]
        public int AÑO { get; set; }
         [Required]
        public string TITULO { get; set; }
    }
}