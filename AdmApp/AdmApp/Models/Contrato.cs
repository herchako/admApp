using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmApp.Models
{
    public class Contrato
    {
        public int ID { get; set; }
        [Display(Name = "Locador")]
        public int LocadorID { get; set; }
        [Display(Name = "Inquilino")]
        public int InquilinoID { get; set; }
        public string Referencia { get; set; }
        [Display(Name = "Nombre Garantia")]
        public string GarantiaNombre { get; set; }
        [Display(Name = "Telefono Garantia")]
        public string GarantiaTelefono { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Observaciones { get; set; }


        public virtual ICollection<Inquilino> Inquilinos { get; set; }
        public virtual ICollection<Locador> Locadores { get; set; }
        public virtual ICollection<PeriodoContrato> PeriodoContratos { get;set; }
        public virtual Propiedad Propiedad { get; set; }
        
    }
}