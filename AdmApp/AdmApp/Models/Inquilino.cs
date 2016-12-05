using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdmApp.Models
{
    public class Inquilino
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeAlta { get; set; }


        public virtual ICollection<Propiedad> Propiedades { get; set; }
    }
}