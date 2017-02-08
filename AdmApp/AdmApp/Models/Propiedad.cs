using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmApp.Models
{
    public class Propiedad
    {
        public int ID { get; set; }

        public int LocadorID { get; set; }
        public string Calle { get; set; }
        public int Altura{ get; set; }

        public string Observaciones { get; set; }


        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Locador> Locadores { get; set; }

    }
}