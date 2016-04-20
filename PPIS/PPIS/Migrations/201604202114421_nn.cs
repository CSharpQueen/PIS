namespace PPIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Certifikats", newName: "Certifikat");
            RenameTable(name: "dbo.Ponudas", newName: "Ponuda");
            RenameTable(name: "dbo.Dobavljacs", newName: "Dobavljac");
            RenameTable(name: "dbo.Ugovors", newName: "Ugovor");
            RenameTable(name: "dbo.Potraznjas", newName: "Potraznja");
            RenameTable(name: "dbo.OcjenaDobavljacas", newName: "OcjenaDobavljaca");
            CreateTable(
                "dbo.ZahtjevZaPromjenom",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        StatusZahtjevaZaPromjenom = c.Int(nullable: false),
                        DatumPodnosenja = c.DateTime(nullable: false),
                        NazivPromjene = c.String(),
                        OpisPromjene = c.String(),
                        RokIzvrsenja = c.DateTime(),
                        MenadzerId = c.String(maxLength: 128),
                        ZahtijevaniPosao = c.String(),
                        PlanRealizacije = c.String(),
                        DatumSvrsetka = c.DateTime(),
                        CabId = c.String(maxLength: 128),
                        DatumPrihvatanja = c.DateTime(),
                        Komentar = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CabId)
                .ForeignKey("dbo.AspNetUsers", t => t.MenadzerId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MenadzerId)
                .Index(t => t.CabId);
            
            AddColumn("dbo.OcjenaDobavljaca", "OcjenaCijene", c => c.Int(nullable: false));
            AddColumn("dbo.OcjenaDobavljaca", "OcjenaRokaIporuke", c => c.Int(nullable: false));
            AddColumn("dbo.OcjenaDobavljaca", "IspostovaneStavkeUgovora", c => c.Int(nullable: false));
            AddColumn("dbo.OcjenaDobavljaca", "KvalitetIsporuke", c => c.Int(nullable: false));
            AddColumn("dbo.OcjenaDobavljaca", "Utisak", c => c.Int(nullable: false));
            AddColumn("dbo.OcjenaDobavljaca", "OpisnaOcjena", c => c.String());
            AddColumn("dbo.OcjenaDobavljaca", "DobavljacId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ImeIPrezime", c => c.String());
            CreateIndex("dbo.OcjenaDobavljaca", "DobavljacId");
            AddForeignKey("dbo.OcjenaDobavljaca", "DobavljacId", "dbo.Dobavljac", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZahtjevZaPromjenom", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ZahtjevZaPromjenom", "MenadzerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ZahtjevZaPromjenom", "CabId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OcjenaDobavljaca", "DobavljacId", "dbo.Dobavljac");
            DropIndex("dbo.ZahtjevZaPromjenom", new[] { "CabId" });
            DropIndex("dbo.ZahtjevZaPromjenom", new[] { "MenadzerId" });
            DropIndex("dbo.ZahtjevZaPromjenom", new[] { "UserId" });
            DropIndex("dbo.OcjenaDobavljaca", new[] { "DobavljacId" });
            DropColumn("dbo.AspNetUsers", "ImeIPrezime");
            DropColumn("dbo.OcjenaDobavljaca", "DobavljacId");
            DropColumn("dbo.OcjenaDobavljaca", "OpisnaOcjena");
            DropColumn("dbo.OcjenaDobavljaca", "Utisak");
            DropColumn("dbo.OcjenaDobavljaca", "KvalitetIsporuke");
            DropColumn("dbo.OcjenaDobavljaca", "IspostovaneStavkeUgovora");
            DropColumn("dbo.OcjenaDobavljaca", "OcjenaRokaIporuke");
            DropColumn("dbo.OcjenaDobavljaca", "OcjenaCijene");
            DropTable("dbo.ZahtjevZaPromjenom");
            RenameTable(name: "dbo.OcjenaDobavljaca", newName: "OcjenaDobavljacas");
            RenameTable(name: "dbo.Potraznja", newName: "Potraznjas");
            RenameTable(name: "dbo.Ugovor", newName: "Ugovors");
            RenameTable(name: "dbo.Dobavljac", newName: "Dobavljacs");
            RenameTable(name: "dbo.Ponuda", newName: "Ponudas");
            RenameTable(name: "dbo.Certifikat", newName: "Certifikats");
        }
    }
}
