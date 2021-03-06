﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class EditPlanilla
    {
        [Required]
        public string ID_PLANILLA { get; set; }
        [Required]
        public int ID_TIPO { get; set; }
        [Required]
        public string NOMBRE { get; set; }
        [Required]
        public string FECHA_INICIO { get; set; }
        [Required]
        public string FECHA_FINAL { get; set; }
    }
}