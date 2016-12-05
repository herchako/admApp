using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AdmApp.Models;

namespace AdmApp.DAL
{
    public class InmobiliariaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<InmobiliariaContext>
    {
        protected override void Seed(InmobiliariaContext context)
        {
            var clientes = new List<Cliente>
            {
            new Cliente{Nombre="Carson",Apellido="Alexander",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Cliente{Nombre="Meredith",Apellido="Alonso",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Cliente{Nombre="Arturo",Apellido="Anand",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Cliente{Nombre="Gytis",Apellido="Barzdukas",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Cliente{Nombre="Yan",Apellido="Li",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Cliente{Nombre="Peggy",Apellido="Justice",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Cliente{Nombre="Laura",Apellido="Norman",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Cliente{Nombre="Nino",Apellido="Oliveto",FechaDeAlta=DateTime.Parse("2005-09-01")}
            };

            clientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();

            var inquilinos = new List<Inquilino>
            {
            new Inquilino{ID=1050,Nombre="Juan",Apellido="Lopez",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Inquilino{ID=4022,Nombre="Roberto",Apellido="Gomez",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Inquilino{ID=4041,Nombre="Maria",Apellido="Iriart",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Inquilino{ID=1045,Nombre="Pablo",Apellido="Ventura",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Inquilino{ID=3141,Nombre="Lucas",Apellido="Fernandez",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Inquilino{ID=2021,Nombre="Franco",Apellido="Lopez",FechaDeAlta=DateTime.Parse("2005-09-01")},
            new Inquilino{ID=2042,Nombre="David",Apellido="Rob",FechaDeAlta=DateTime.Parse("2005-09-01")},

            };
            inquilinos.ForEach(s => context.Inquilinos.Add(s));
            context.SaveChanges();

            var propiedades = new List<Propiedad>
            {
            new Propiedad{ClienteID=1, InquilinoID=1050, Calle="14 de Julio",Altura=315,},
            new Propiedad{ClienteID=1, InquilinoID=4022, Calle="Condarco",Altura=1377,},
            new Propiedad{ClienteID=1, InquilinoID=4041, Calle="Obligado",Altura=730,},
            new Propiedad{ClienteID=2, InquilinoID=1045, Calle="Cangallo",Altura=730,},
            new Propiedad{ClienteID=2, InquilinoID=3141, Calle="Cangallo",Altura=990,},
            new Propiedad{ClienteID=2, InquilinoID=2021, Calle="Santa María de Oro",Altura=1990,},
            new Propiedad{ClienteID=3, InquilinoID=1050, Calle="Vicente Stea",Altura=90,},
            new Propiedad{ClienteID=4, InquilinoID=1050, Calle="Vicente Stea",Altura=150,},
            new Propiedad{ClienteID=4, InquilinoID=4022, Calle="Vicente Stea",Altura=150,},
            new Propiedad{ClienteID=4, InquilinoID=4022, Calle="Meeks",Altura=500,}
            };
            propiedades.ForEach(s => context.Propiedades.Add(s));
            context.SaveChanges();
        }
    }
}