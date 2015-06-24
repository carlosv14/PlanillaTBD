using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
    public class CreateColaborador
    {
        [Required]
        public string ID_DEPARTAMENTO { get; set; }
        [Required]
        public int ID_TIPO { get; set; }
        [Required]
        public string ID_SUPERIOR { get; set; }
        [Required]
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        [Required]
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        [Required]
        public string FECHA_NACIMIENTO { get; set; }
        [Required]
        public float SALARIO_BASE { get; set; }
        [Required]
        public int GRADO { get; set; }
        [Required]
        public char SEXO { get; set; }
        [Required]
        public string CEDULA { get; set; }
    }
}