using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdmApp.Models
{
    public class Inquilino
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telefono Particular")]
        public string Telefono { get; set; }
        public string Celular { get; set; }
        [Display(Name = "Domicilio Particular")]
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Fecha de Alta")]
        public DateTime FechaDeAlta { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Pendiente> Pendientes { get; set; }
    }
}