namespace Database_Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Input_date1", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Input_date1");
        }
    }
}
