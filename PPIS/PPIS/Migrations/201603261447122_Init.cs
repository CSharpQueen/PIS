namespace PPIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifikat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        PonudaId = c.Int(nullable: false),
                        PotraznjaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ponuda", t => t.PonudaId, cascadeDelete: true)
                .ForeignKey("dbo.Potraznja", t => t.PotraznjaId, cascadeDelete: true)
                .Index(t => t.PonudaId)
                .Index(t => t.PotraznjaId);
            
            CreateTable(
                "dbo.Ponuda",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Cijena = c.Double(nullable: false),
                        Opis = c.String(nullable: false),
                        RokIsporuke = c.DateTime(nullable: false),
                        DobavljacId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dobavljac", t => t.DobavljacId, cascadeDelete: true)
                .Index(t => t.DobavljacId);
            
            CreateTable(
                "dbo.Dobavljac",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Adresa = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ugovor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PeriodVazenjaOd = c.DateTime(nullable: false),
                        PeriodVazenjaDo = c.DateTime(nullable: false),
                        sadrzajUgovora = c.String(nullable: false),
                        potpisnikUgovoraSupplier = c.String(nullable: false),
                        potpisnikUgovoraManager = c.String(nullable: false),
                        dodatneStavke = c.String(),
                        DobavljacId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dobavljac", t => t.DobavljacId, cascadeDelete: true)
                .Index(t => t.DobavljacId);
            
            CreateTable(
                "dbo.Potraznja",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Cijena = c.Double(nullable: false),
                        PrioritetCijene = c.Int(nullable: false),
                        Opis = c.String(nullable: false),
                        RokIsporuke = c.DateTime(nullable: false),
                        PrioritetRokaIsporuke = c.Int(nullable: false),
                        PonudaId = c.Int(),
                        OcjenaDobavljacaId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OcjenaDobavljaca", t => t.OcjenaDobavljacaId)
                .ForeignKey("dbo.Ponuda", t => t.PonudaId)
                .Index(t => t.PonudaId)
                .Index(t => t.OcjenaDobavljacaId);
            
            CreateTable(
                "dbo.OcjenaDobavljaca",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ocjena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZahtjevZaPromjenom", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ZahtjevZaPromjenom", "MenadzerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ZahtjevZaPromjenom", "CabId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Certifikat", "PotraznjaId", "dbo.Potraznja");
            DropForeignKey("dbo.Potraznja", "PonudaId", "dbo.Ponuda");
            DropForeignKey("dbo.Potraznja", "OcjenaDobavljacaId", "dbo.OcjenaDobavljaca");
            DropForeignKey("dbo.Ugovor", "DobavljacId", "dbo.Dobavljac");
            DropForeignKey("dbo.Ponuda", "DobavljacId", "dbo.Dobavljac");
            DropForeignKey("dbo.Certifikat", "PonudaId", "dbo.Ponuda");
            DropIndex("dbo.ZahtjevZaPromjenom", new[] { "CabId" });
            DropIndex("dbo.ZahtjevZaPromjenom", new[] { "MenadzerId" });
            DropIndex("dbo.ZahtjevZaPromjenom", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Potraznja", new[] { "OcjenaDobavljacaId" });
            DropIndex("dbo.Potraznja", new[] { "PonudaId" });
            DropIndex("dbo.Ugovor", new[] { "DobavljacId" });
            DropIndex("dbo.Ponuda", new[] { "DobavljacId" });
            DropIndex("dbo.Certifikat", new[] { "PotraznjaId" });
            DropIndex("dbo.Certifikat", new[] { "PonudaId" });
            DropTable("dbo.ZahtjevZaPromjenom");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OcjenaDobavljaca");
            DropTable("dbo.Potraznja");
            DropTable("dbo.Ugovor");
            DropTable("dbo.Dobavljac");
            DropTable("dbo.Ponuda");
            DropTable("dbo.Certifikat");
        }
    }
}
