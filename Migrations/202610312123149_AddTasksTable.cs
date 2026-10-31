namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTasksTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        Status = c.String(nullable: false),
                        Priority = c.String(nullable: false),
                        DueDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskItems", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TaskItems", new[] { "UserId" });
            DropTable("dbo.TaskItems");
        }
    }
}
