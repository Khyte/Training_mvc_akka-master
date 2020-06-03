namespace TrainingMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroRue = c.String(),
                        Rue = c.String(),
                        CodePostal = c.String(),
                        Ville = c.String(),
                        Pays = c.String(),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            DropColumn("dbo.AspNetUsers", "NumeroRue");
            DropColumn("dbo.AspNetUsers", "Rue");
            DropColumn("dbo.AspNetUsers", "CodePostal");
            DropColumn("dbo.AspNetUsers", "Ville");
            DropColumn("dbo.AspNetUsers", "Pays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Pays", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ville", c => c.String());
            AddColumn("dbo.AspNetUsers", "CodePostal", c => c.String());
            AddColumn("dbo.AspNetUsers", "Rue", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumeroRue", c => c.String());
            DropForeignKey("dbo.Addresses", "Student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "Student_Id" });
            DropTable("dbo.Addresses");
        }
    }
}
