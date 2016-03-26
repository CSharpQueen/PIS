namespace PPIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imeiprezime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImeIPrezime", c => c.String());            
        }
        
        public override void Down()
        {            
            DropColumn("dbo.AspNetUsers", "ImeIPrezime");
        }
    }
}
