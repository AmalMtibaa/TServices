namespace PuProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fournisseur",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Gouvernorat = c.String(),
                        Ville = c.String(),
                        Lat = c.Double(nullable: false),
                        Lon = c.Double(nullable: false),
                        Telephone = c.Int(nullable: false),
                        Description = c.String(),
                        Id_Categorie = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fournisseur");
            DropTable("dbo.Categorie");
        }
    }
}
