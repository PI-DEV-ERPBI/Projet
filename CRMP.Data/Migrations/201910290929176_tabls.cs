namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        NomAg = c.String(),
                        prenomA = c.String(),
                        adresseA = c.String(),
                        ageA = c.Int(nullable: false),
                        salaireA = c.Single(nullable: false),
                        typeA = c.String(),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        CommandeId = c.Int(nullable: false, identity: true),
                        cmdNum = c.Int(nullable: false),
                        cmdDate = c.DateTime(nullable: false),
                        cmdMontant = c.Single(nullable: false),
                        userId = c.Int(),
                        productId = c.Int(),
                    })
                .PrimaryKey(t => t.CommandeId)
                .ForeignKey("dbo.Products", t => t.productId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        prodName = c.String(),
                        prodDesc = c.String(),
                        prodPrice = c.Single(nullable: false),
                        prodQuantity = c.Int(nullable: false),
                        prodImage = c.String(),
                        prodCat = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        lastName = c.String(),
                        role = c.String(),
                        gender = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        userAddress = c.String(),
                        userNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Devis",
                c => new
                    {
                        DevisId = c.Int(nullable: false, identity: true),
                        devisEtat = c.String(),
                        devisDate = c.DateTime(nullable: false),
                        CommandeId = c.Int(),
                        userId = c.Int(),
                    })
                .PrimaryKey(t => t.DevisId)
                .ForeignKey("dbo.Commandes", t => t.CommandeId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.CommandeId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        offerName = c.String(),
                        offerDesc = c.String(),
                        offerType = c.String(),
                        offerprice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OfferId);
            
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        PackId = c.Int(nullable: false, identity: true),
                        packName = c.String(),
                        packDesc = c.String(),
                        packPrice = c.String(),
                        packImage = c.String(),
                        ProductId = c.Int(),
                        OfferId = c.Int(),
                    })
                .PrimaryKey(t => t.PackId)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .ForeignKey("dbo.Users", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        promoDesc = c.String(),
                        promoDateD = c.DateTime(nullable: false),
                        promoDateF = c.DateTime(nullable: false),
                        promoPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        ReclamationId = c.Int(nullable: false, identity: true),
                        typeRec = c.String(),
                        descRec = c.String(),
                        responseRec = c.String(),
                        etatRec = c.String(),
                        dataRec = c.DateTime(nullable: false),
                        userId = c.Int(),
                    })
                .PrimaryKey(t => t.ReclamationId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Stands",
                c => new
                    {
                        StandId = c.Int(nullable: false, identity: true),
                        adresseSt = c.String(),
                        typeSt = c.String(),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.StandId)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        storeName = c.String(),
                        storeaddress = c.String(),
                        storeNum = c.String(),
                        storeDesc = c.String(),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.Vehicules",
                c => new
                    {
                        VehiculeId = c.Int(nullable: false, identity: true),
                        typeVh = c.String(),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.VehiculeId)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.Ventes",
                c => new
                    {
                        VentesId = c.Int(nullable: false, identity: true),
                        typeVt = c.String(),
                        valeurVt = c.Single(nullable: false),
                        StandId = c.Int(),
                    })
                .PrimaryKey(t => t.VentesId)
                .ForeignKey("dbo.Stands", t => t.StandId)
                .Index(t => t.StandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventes", "StandId", "dbo.Stands");
            DropForeignKey("dbo.Vehicules", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.Stands", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.Reclamations", "userId", "dbo.Users");
            DropForeignKey("dbo.Packs", "ProductId", "dbo.Users");
            DropForeignKey("dbo.Packs", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Devis", "userId", "dbo.Users");
            DropForeignKey("dbo.Devis", "CommandeId", "dbo.Commandes");
            DropForeignKey("dbo.Commandes", "userId", "dbo.Users");
            DropForeignKey("dbo.Commandes", "productId", "dbo.Products");
            DropIndex("dbo.Ventes", new[] { "StandId" });
            DropIndex("dbo.Vehicules", new[] { "AgentId" });
            DropIndex("dbo.Stands", new[] { "AgentId" });
            DropIndex("dbo.Reclamations", new[] { "userId" });
            DropIndex("dbo.Packs", new[] { "OfferId" });
            DropIndex("dbo.Packs", new[] { "ProductId" });
            DropIndex("dbo.Devis", new[] { "userId" });
            DropIndex("dbo.Devis", new[] { "CommandeId" });
            DropIndex("dbo.Commandes", new[] { "productId" });
            DropIndex("dbo.Commandes", new[] { "userId" });
            DropTable("dbo.Ventes");
            DropTable("dbo.Vehicules");
            DropTable("dbo.Stores");
            DropTable("dbo.Stands");
            DropTable("dbo.Reclamations");
            DropTable("dbo.Promotions");
            DropTable("dbo.Packs");
            DropTable("dbo.Offers");
            DropTable("dbo.Devis");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Commandes");
            DropTable("dbo.Agents");
        }
    }
}
