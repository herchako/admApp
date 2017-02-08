using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmApp.Models
{
    public class Contrato
    {
        public int ID { get; set; }
        public int LocadorID { get; set; }
        public int InquilinoID { get; set; }
        public string Referencia { get; set; }
        public string GarantiaNombre { get; set; }
        public string GarantiaTelefono { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Observaciones { get; set; }


        public virtual ICollection<Inquilino> Inquilinos { get; set; }
        public virtual ICollection<Locador> Locadores { get; set; }
        public virtual ICollection<PeriodoContrato> PeriodoContratos { get;set; }
        public virtual Propiedad Propiedad { get; set; }
        
    }
}