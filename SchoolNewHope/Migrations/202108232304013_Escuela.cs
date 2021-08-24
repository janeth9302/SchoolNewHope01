namespace SchoolNewHope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Escuela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlumnoGradoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlumnoId = c.Int(nullable: false),
                        GradoId = c.Int(nullable: false),
                        GradoActual = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alumnoes", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Gradoes", t => t.GradoId, cascadeDelete: true)
                .Index(t => t.AlumnoId)
                .Index(t => t.GradoId);
            
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroIdentidad = c.String(maxLength: 20),
                        PrimerNombre = c.String(),
                        SegundoNombre = c.String(),
                        PrimerApellido = c.String(),
                        SegundoApellido = c.String(),
                        Sexo = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NumeroIdentidad, unique: true, name: "NumeroIdentidad");
            
            CreateTable(
                "dbo.Gradoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlumnoGradoes", "GradoId", "dbo.Gradoes");
            DropForeignKey("dbo.AlumnoGradoes", "AlumnoId", "dbo.Alumnoes");
            DropIndex("dbo.Alumnoes", "NumeroIdentidad");
            DropIndex("dbo.AlumnoGradoes", new[] { "GradoId" });
            DropIndex("dbo.AlumnoGradoes", new[] { "AlumnoId" });
            DropTable("dbo.Gradoes");
            DropTable("dbo.Alumnoes");
            DropTable("dbo.AlumnoGradoes");
        }
    }
}
