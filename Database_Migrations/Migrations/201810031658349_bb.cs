namespace Database_Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "memo2", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "memo2");
        }
    }
}
