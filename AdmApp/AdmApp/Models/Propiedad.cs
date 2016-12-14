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
        public int InquilinoID { get; set; }

        public string Calle { get; set; }
        public int Altura{ get; set; }


        public virtual Locador Locador { get; set; }
        public virtual Inquilino Inquilino{ get; set; }

    }
}