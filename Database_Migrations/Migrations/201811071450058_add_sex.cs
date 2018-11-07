namespace Database_Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_sex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "sex");
        }
    }
}
