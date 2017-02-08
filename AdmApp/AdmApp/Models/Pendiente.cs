using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmApp.Models
{
    public class Pendiente
    {
        public int ID { get; set; }
        public string Referencia { get; set; }
        public string Monto { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Observaciones { get; set; }

        public virtual Inquilino Inquilino { get; set; }
        public virtual Locador Locador { get; set; }
        
    }
}