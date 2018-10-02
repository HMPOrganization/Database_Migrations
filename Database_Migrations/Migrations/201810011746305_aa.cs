namespace Database_Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        class_no = c.String(nullable: false, maxLength: 50),
                        id = c.Int(nullable: false, identity: true),
                        class_name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.class_no);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        person_no = c.String(nullable: false, maxLength: 50),
                        id = c.Int(nullable: false, identity: true),
                        class_no = c.String(nullable: false, maxLength: 50),
                        person_name = c.String(maxLength: 50),
                        age = c.Int(nullable: false),
                        enrollment_time = c.DateTime(),
                        memo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.person_no)
                .ForeignKey("dbo.Grade", t => t.class_no)
                .Index(t => t.class_no);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        subject_no = c.String(nullable: false, maxLength: 50),
                        id = c.Int(nullable: false, identity: true),
                        subject_name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.subject_no);
            
            CreateTable(
                "dbo.Person_Subject",
                c => new
                    {
                        person_no = c.String(nullable: false, maxLength: 50),
                        subject_no = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.person_no, t.subject_no })
                .ForeignKey("dbo.Person", t => t.person_no, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.subject_no, cascadeDelete: true)
                .Index(t => t.person_no)
                .Index(t => t.subject_no);
            

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "class_no", "dbo.Grade");
            DropForeignKey("dbo.Person_Subject", "subject_no", "dbo.Subject");
            DropForeignKey("dbo.Person_Subject", "person_no", "dbo.Person");
            DropIndex("dbo.Person_Subject", new[] { "subject_no" });
            DropIndex("dbo.Person_Subject", new[] { "person_no" });
            DropIndex("dbo.Person", new[] { "class_no" });
            DropTable("dbo.Person_Subject");
            DropTable("dbo.Subject");
            DropTable("dbo.Person");
            DropTable("dbo.Grade");
        }
    }
}
