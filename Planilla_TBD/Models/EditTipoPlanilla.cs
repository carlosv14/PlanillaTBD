using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class EditTipoPlanilla
    {
        [Required]
        public int ID_TIPO { get; set; }
        [Required]
        public int TIPO_PAGO { get; set; }
        [Required]
        public string NOMBRE { get; set; }
    }
}