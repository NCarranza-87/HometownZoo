namespace HometownZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Animal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.AnimalID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animals");
        }
    }
}
