using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdmApp.Models
{
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ocupacion { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telefono Particular")]
        public string Telefono { get; set; }
        public string Celular { get; set; }
        [Display(Name = "Domicilio Particular")]
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Fecha de Alta")]
        public DateTime FechaDeAlta { get; set; }
    }
}