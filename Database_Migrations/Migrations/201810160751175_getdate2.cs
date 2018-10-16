namespace Database_Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Input_date2", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Input_date2");
        }
    }
}
