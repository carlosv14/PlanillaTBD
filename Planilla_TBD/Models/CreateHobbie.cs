using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class CreateHobbie
    {
       
        [Required]
        public string ID_COLABORADOR { get; set; }
        [Required]
        public string HOBBIE { get; set; }
    }
}