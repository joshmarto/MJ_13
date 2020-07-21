using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MJ_13.Data
{
    public class Contexto : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Contexto() : base("name=Contexto")
        {
        }

        public System.Data.Entity.DbSet<MJ_13.Models.TipoP> TipoPs { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.Clasificaciones> Clasificaciones { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.Miembros> Miembros { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.LideresV> LideresVs { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.Lideres> Lideres { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.Tareas> Tareas { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.Programas> Programas { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.Predicadores> Predicadores { get; set; }

        public System.Data.Entity.DbSet<MJ_13.Models.Actividades> Actividades { get; set; }
    }
}
