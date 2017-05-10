using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmApp.Models
{
    public enum Estado
    {
        Abonado,Pendiente,NoAsignado
    }
    public class Pendiente
    {
        public int ID { get; set; }
        [Display(Name = "Fecha Emision")]
        public DateTime FechaEmision { get; set; }
        [Display(Name = "Locador")]
        public int LocadorID { get; set; }
        [Display(Name = "Inquilino")]
        public int InquilinoID { get; set; }
        public string Referencia { get; set; }
        public string Monto { get; set; }
        public Estado? Estado { get; set; }
        [Display(Name = "Fecha Vencimiento")]
        public DateTime FechaVencimiento { get; set; }
        public string Observaciones { get; set; }

        public virtual Inquilino Inquilino { get; set; }
        public virtual Locador Locador { get; set; }
        
    }
}