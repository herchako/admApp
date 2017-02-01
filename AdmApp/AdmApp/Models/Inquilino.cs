using System;
using System.Collections.Generic;
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
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaDeAlta { get; set; }
        
        public virtual ICollection<Propiedad> Propiedades { get; set; }
    }
}