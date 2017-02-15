using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmApp.Models
{
    public class PeriodoContrato
    {
        public int ID { get; set; }
        public int ContratoID { get; set; }
        public string Referencia { get; set; }
        public string Monto { get; set; }
        public DateTime FechaComienzo { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Contrato Contrato { get; set; }
    }
}