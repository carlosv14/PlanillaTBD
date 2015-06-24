using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class EditNivelEducativo
    {
        [Required]
        public int ID_NIVEL_EDUCATIVO { get; set; }
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