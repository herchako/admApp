using System;
using System.Collections.Generic;

namespace AdmApp.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeAlta { get; set; }

        public virtual ICollection<Propiedad> Propiedades { get; set; }
    }
}