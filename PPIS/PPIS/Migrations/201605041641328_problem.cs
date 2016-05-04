namespace PPIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class problem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Problem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        StatusGlavnogProblema = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Issue", "ProblemId", c => c.Int());
            CreateIndex("dbo.Issue", "ProblemId");
            AddForeignKey("dbo.Issue", "ProblemId", "dbo.Problem", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issue", "ProblemId", "dbo.Problem");
            DropIndex("dbo.Issue", new[] { "ProblemId" });
            DropColumn("dbo.Issue", "ProblemId");
            DropTable("dbo.Problem");
        }
    }
}
