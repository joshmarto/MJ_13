namespace MJ_13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Fecha = c.String(),
                        Medio = c.String(),
                        Actividad = c.String(),
                        LiderID = c.Int(nullable: false),
                        ActividadL = c.String(),
                        LeaderID = c.Int(nullable: false),
                        PredicadorID = c.Int(nullable: false),
                        Tema = c.String(),
                        CitaBase = c.String(),
                        NoParticipantes = c.Int(nullable: false),
                        ProgramaID = c.Int(nullable: false),
                        Realizada = c.Boolean(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Miembros", t => t.LeaderID, cascadeDelete: true)
                .ForeignKey("dbo.Lideres", t => t.LiderID, cascadeDelete: true)
                .ForeignKey("dbo.Predicadores", t => t.PredicadorID, cascadeDelete: true)
                .ForeignKey("dbo.Programas", t => t.ProgramaID, cascadeDelete: true)
                .Index(t => t.LiderID)
                .Index(t => t.LeaderID)
                .Index(t => t.PredicadorID)
                .Index(t => t.ProgramaID);
            
            CreateTable(
                "dbo.Miembros",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Nickname = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lideres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tareas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tarea = c.String(),
                        LiderID = c.Int(nullable: false),
                        FechaInicio = c.String(),
                        FechaFinal = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lideres", t => t.LiderID, cascadeDelete: true)
                .Index(t => t.LiderID);
            
            CreateTable(
                "dbo.Predicadores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        TipoID = c.Int(nullable: false),
                        ClasificacionID = c.Int(nullable: false),
                        Localidad = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clasificaciones", t => t.ClasificacionID, cascadeDelete: true)
                .ForeignKey("dbo.TipoPs", t => t.TipoID, cascadeDelete: true)
                .Index(t => t.TipoID)
                .Index(t => t.ClasificacionID);
            
            CreateTable(
                "dbo.Clasificaciones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Clasificacion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TipoPs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Programas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Programa = c.String(),
                        LiderID = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LideresVs", t => t.LiderID, cascadeDelete: true)
                .Index(t => t.LiderID);
            
            CreateTable(
                "dbo.LideresVs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programas", "LiderID", "dbo.LideresVs");
            DropForeignKey("dbo.Actividades", "ProgramaID", "dbo.Programas");
            DropForeignKey("dbo.Predicadores", "TipoID", "dbo.TipoPs");
            DropForeignKey("dbo.Predicadores", "ClasificacionID", "dbo.Clasificaciones");
            DropForeignKey("dbo.Actividades", "PredicadorID", "dbo.Predicadores");
            DropForeignKey("dbo.Tareas", "LiderID", "dbo.Lideres");
            DropForeignKey("dbo.Actividades", "LiderID", "dbo.Lideres");
            DropForeignKey("dbo.Actividades", "LeaderID", "dbo.Miembros");
            DropIndex("dbo.Programas", new[] { "LiderID" });
            DropIndex("dbo.Predicadores", new[] { "ClasificacionID" });
            DropIndex("dbo.Predicadores", new[] { "TipoID" });
            DropIndex("dbo.Tareas", new[] { "LiderID" });
            DropIndex("dbo.Actividades", new[] { "ProgramaID" });
            DropIndex("dbo.Actividades", new[] { "PredicadorID" });
            DropIndex("dbo.Actividades", new[] { "LeaderID" });
            DropIndex("dbo.Actividades", new[] { "LiderID" });
            DropTable("dbo.LideresVs");
            DropTable("dbo.Programas");
            DropTable("dbo.TipoPs");
            DropTable("dbo.Clasificaciones");
            DropTable("dbo.Predicadores");
            DropTable("dbo.Tareas");
            DropTable("dbo.Lideres");
            DropTable("dbo.Miembros");
            DropTable("dbo.Actividades");
        }
    }
}
