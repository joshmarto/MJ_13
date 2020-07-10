using MJ_13.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Data
{
    public class Inicializador : System.Data.Entity.DropCreateDatabaseAlways<Contexto>
    {
        protected override void Seed(Contexto context)
        {
            base.Seed(context);

            var lideres = new List<Lideres>
            {
                new Lideres{Nombre="Alejandro Samayoa", Telefono="5446 1588", Email="luisale2009@hotmail.es" },
                new Lideres{Nombre="David Cancino", Telefono="4245 6232", Email="davidecancinoced@gmail.com" },
                new Lideres{Nombre="Myshel Ochoa", Telefono="5151 0146", Email="sherlynochoa3940@gmail.com" },
                new Lideres{Nombre="Josue Martinez", Telefono="57749728", Email="jmartinezolivares1@gmail.com" },
            };

            lideres.ForEach(s => context.Lideres.Add(s));
            context.SaveChanges();

            var lideresV = new List<LideresV>
            {
                new LideresV{Nombre="Alejandro Samayoa", Telefono="5446 1588", Email="luisale2009@hotmail.es" },
                new LideresV{Nombre="David Cancino", Telefono="4245 6232", Email="davidecancinoced@gmail.com" },
                new LideresV{Nombre="Myshel Ochoa", Telefono="5151 0146", Email="sherlynochoa3940@gmail.com" },
                new LideresV{Nombre="Josue Martinez", Telefono="57749728", Email="jmartinezolivares1@gmail.com" },
            };

            lideresV.ForEach(s => context.LideresVs.Add(s));
            context.SaveChanges();

            var tipos = new List<TipoP>
            {
                new TipoP{Tipo="Invitado" },
                new TipoP{Tipo="Local" },
                new TipoP{Tipo="Lider" },
            };

            tipos.ForEach(s => context.TipoPs.Add(s));
            context.SaveChanges();

        }
    }
}