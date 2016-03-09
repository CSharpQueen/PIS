namespace PPIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifikats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        PonudaId = c.Int(nullable: false),
                        PotraznjaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ponudas", t => t.PonudaId, cascadeDelete: true)
                .ForeignKey("dbo.Potraznjas", t => t.PotraznjaId, cascadeDelete: true)
                .Index(t => t.PonudaId)
                .Index(t => t.PotraznjaId);
            
            CreateTable(
                "dbo.Ponudas",
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
                .ForeignKey("dbo.Dobavljacs", t => t.DobavljacId, cascadeDelete: true)
                .Index(t => t.DobavljacId);
            
            CreateTable(
                "dbo.Dobavljacs",
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
                "dbo.Ugovors",
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
                .ForeignKey("dbo.Dobavljacs", t => t.DobavljacId, cascadeDelete: true)
                .Index(t => t.DobavljacId);
            
            CreateTable(
                "dbo.Potraznjas",
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
                .ForeignKey("dbo.OcjenaDobavljacas", t => t.OcjenaDobavljacaId)
                .ForeignKey("dbo.Ponudas", t => t.PonudaId)
                .Index(t => t.PonudaId)
                .Index(t => t.OcjenaDobavljacaId);
            
            CreateTable(
                "dbo.OcjenaDobavljacas",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Certifikats", "PotraznjaId", "dbo.Potraznjas");
            DropForeignKey("dbo.Potraznjas", "PonudaId", "dbo.Ponudas");
            DropForeignKey("dbo.Potraznjas", "OcjenaDobavljacaId", "dbo.OcjenaDobavljacas");
            DropForeignKey("dbo.Ugovors", "DobavljacId", "dbo.Dobavljacs");
            DropForeignKey("dbo.Ponudas", "DobavljacId", "dbo.Dobavljacs");
            DropForeignKey("dbo.Certifikats", "PonudaId", "dbo.Ponudas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Potraznjas", new[] { "OcjenaDobavljacaId" });
            DropIndex("dbo.Potraznjas", new[] { "PonudaId" });
            DropIndex("dbo.Ugovors", new[] { "DobavljacId" });
            DropIndex("dbo.Ponudas", new[] { "DobavljacId" });
            DropIndex("dbo.Certifikats", new[] { "PotraznjaId" });
            DropIndex("dbo.Certifikats", new[] { "PonudaId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OcjenaDobavljacas");
            DropTable("dbo.Potraznjas");
            DropTable("dbo.Ugovors");
            DropTable("dbo.Dobavljacs");
            DropTable("dbo.Ponudas");
            DropTable("dbo.Certifikats");
        }
    }
}
