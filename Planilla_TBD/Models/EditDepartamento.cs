﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilla_TBD.Models
{
    public class EditDepartamento
    {
        [Required]
        public string ID_DEPARTAMENTO { get; set; }
        [Required]
        public string NOMBRE { get; set; }
    }
}