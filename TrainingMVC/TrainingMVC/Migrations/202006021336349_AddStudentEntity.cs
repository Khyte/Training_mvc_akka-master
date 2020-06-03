namespace TrainingMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NumeroRue", c => c.String());
            AddColumn("dbo.AspNetUsers", "Rue", c => c.String());
            AddColumn("dbo.AspNetUsers", "CodePostal", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ville", c => c.String());
            AddColumn("dbo.AspNetUsers", "Pays", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Pays");
            DropColumn("dbo.AspNetUsers", "Ville");
            DropColumn("dbo.AspNetUsers", "CodePostal");
            DropColumn("dbo.AspNetUsers", "Rue");
            DropColumn("dbo.AspNetUsers", "NumeroRue");
        }
    }
}
