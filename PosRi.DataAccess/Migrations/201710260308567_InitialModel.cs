namespace PosRi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(unicode: false),
                        ExtraDescription = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        PurchasePrice = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        SpecialPrice = c.Single(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        SizeId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        ProductHeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.ProductHeaders", t => t.ProductHeaderId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.SizeId)
                .Index(t => t.ColorId)
                .Index(t => t.ProductHeaderId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        City = c.String(unicode: false),
                        Rfc = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        CreationDate = c.DateTime(nullable: false, precision: 0),
                        IsActive = c.Boolean(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.PurchaseHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false, precision: 0),
                        SubTotal = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        PaidCash = c.Single(nullable: false),
                        PaidCard = c.Single(nullable: false),
                        PaidCredit = c.Single(nullable: false),
                        VendorId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        SalePrice = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PurchaseHeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseHeaders", t => t.PurchaseHeaderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseHeaderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Username = c.String(nullable: false, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        Birthday = c.DateTime(nullable: false, precision: 0),
                        HireDate = c.DateTime(nullable: false, precision: 0),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CashFounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisterDate = c.DateTime(nullable: false, precision: 0),
                        Quantity = c.Single(nullable: false),
                        UserId = c.Int(nullable: false),
                        CashRegisterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashRegisters", t => t.CashRegisterId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CashRegisterId);
            
            CreateTable(
                "dbo.CashRegisters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CashRegisterMoves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Action = c.String(unicode: false),
                        RegisterDate = c.DateTime(nullable: false, precision: 0),
                        Quantity = c.Single(nullable: false),
                        CashRegisterId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashRegisters", t => t.CashRegisterId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CashRegisterId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomerPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        PaidDate = c.DateTime(nullable: false, precision: 0),
                        PaidCash = c.Single(nullable: false),
                        PaidCard = c.Single(nullable: false),
                        CustomerDebtId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerDebts", t => t.CustomerDebtId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CustomerDebtId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomerDebts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        DueDate = c.DateTime(nullable: false, precision: 0),
                        Debt = c.Single(nullable: false),
                        Balance = c.Single(nullable: false),
                        SaleHeaderId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.SaleHeaders", t => t.SaleHeaderId, cascadeDelete: true)
                .Index(t => t.SaleHeaderId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        City = c.String(unicode: false),
                        Rfc = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        CreationDate = c.DateTime(nullable: false, precision: 0),
                        IsActive = c.Boolean(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.SaleHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false, precision: 0),
                        SubTotal = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        PaidCash = c.Single(nullable: false),
                        PaidCard = c.Single(nullable: false),
                        PaidCredit = c.Single(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CashRegisterId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashRegisters", t => t.CashRegisterId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CashRegisterId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        SalePrice = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SaleHeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SaleHeaders", t => t.SaleHeaderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SaleHeaderId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VendorPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        PaidDate = c.DateTime(nullable: false, precision: 0),
                        PaidCash = c.Single(nullable: false),
                        PaidCard = c.Single(nullable: false),
                        VendorDebtId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.VendorDebts", t => t.VendorDebtId, cascadeDelete: true)
                .Index(t => t.VendorDebtId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VendorDebts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        DueDate = c.DateTime(nullable: false, precision: 0),
                        Debt = c.Single(nullable: false),
                        Balance = c.Single(nullable: false),
                        PurchaseHeaderId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseHeaders", t => t.PurchaseHeaderId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.PurchaseHeaderId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        LastAdd = c.DateTime(nullable: false, precision: 0),
                        ProductId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.VendorBrands",
                c => new
                    {
                        VendorId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VendorId, t.BrandId })
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryProducts", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.InventoryProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseHeaders", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.VendorPayments", "VendorDebtId", "dbo.VendorDebts");
            DropForeignKey("dbo.VendorDebts", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.VendorDebts", "PurchaseHeaderId", "dbo.PurchaseHeaders");
            DropForeignKey("dbo.VendorPayments", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseHeaders", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomerPayments", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomerDebts", "SaleHeaderId", "dbo.SaleHeaders");
            DropForeignKey("dbo.CustomerPayments", "CustomerDebtId", "dbo.CustomerDebts");
            DropForeignKey("dbo.Vendors", "StateId", "dbo.States");
            DropForeignKey("dbo.Customers", "StateId", "dbo.States");
            DropForeignKey("dbo.SaleHeaders", "UserId", "dbo.Users");
            DropForeignKey("dbo.SaleDetails", "SaleHeaderId", "dbo.SaleHeaders");
            DropForeignKey("dbo.SaleDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SaleHeaders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SaleHeaders", "CashRegisterId", "dbo.CashRegisters");
            DropForeignKey("dbo.CustomerDebts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CashRegisterMoves", "UserId", "dbo.Users");
            DropForeignKey("dbo.CashRegisterMoves", "CashRegisterId", "dbo.CashRegisters");
            DropForeignKey("dbo.CashFounds", "UserId", "dbo.Users");
            DropForeignKey("dbo.CashFounds", "CashRegisterId", "dbo.CashRegisters");
            DropForeignKey("dbo.CashRegisters", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseHeaderId", "dbo.PurchaseHeaders");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.VendorBrands", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.VendorBrands", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Products", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.Products", "ProductHeaderId", "dbo.ProductHeaders");
            DropForeignKey("dbo.Products", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.ProductHeaders", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductHeaders", "BrandId", "dbo.Brands");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.VendorBrands", new[] { "BrandId" });
            DropIndex("dbo.VendorBrands", new[] { "VendorId" });
            DropIndex("dbo.InventoryProducts", new[] { "StoreId" });
            DropIndex("dbo.InventoryProducts", new[] { "ProductId" });
            DropIndex("dbo.VendorDebts", new[] { "VendorId" });
            DropIndex("dbo.VendorDebts", new[] { "PurchaseHeaderId" });
            DropIndex("dbo.VendorPayments", new[] { "UserId" });
            DropIndex("dbo.VendorPayments", new[] { "VendorDebtId" });
            DropIndex("dbo.SaleDetails", new[] { "SaleHeaderId" });
            DropIndex("dbo.SaleDetails", new[] { "ProductId" });
            DropIndex("dbo.SaleHeaders", new[] { "UserId" });
            DropIndex("dbo.SaleHeaders", new[] { "CashRegisterId" });
            DropIndex("dbo.SaleHeaders", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "StateId" });
            DropIndex("dbo.CustomerDebts", new[] { "CustomerId" });
            DropIndex("dbo.CustomerDebts", new[] { "SaleHeaderId" });
            DropIndex("dbo.CustomerPayments", new[] { "UserId" });
            DropIndex("dbo.CustomerPayments", new[] { "CustomerDebtId" });
            DropIndex("dbo.CashRegisterMoves", new[] { "UserId" });
            DropIndex("dbo.CashRegisterMoves", new[] { "CashRegisterId" });
            DropIndex("dbo.CashRegisters", new[] { "StoreId" });
            DropIndex("dbo.CashFounds", new[] { "CashRegisterId" });
            DropIndex("dbo.CashFounds", new[] { "UserId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseHeaderId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseHeaders", new[] { "UserId" });
            DropIndex("dbo.PurchaseHeaders", new[] { "VendorId" });
            DropIndex("dbo.Vendors", new[] { "StateId" });
            DropIndex("dbo.Products", new[] { "ProductHeaderId" });
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.Products", new[] { "SizeId" });
            DropIndex("dbo.ProductHeaders", new[] { "BrandId" });
            DropIndex("dbo.ProductHeaders", new[] { "CategoryId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.VendorBrands");
            DropTable("dbo.InventoryProducts");
            DropTable("dbo.VendorDebts");
            DropTable("dbo.VendorPayments");
            DropTable("dbo.Roles");
            DropTable("dbo.States");
            DropTable("dbo.SaleDetails");
            DropTable("dbo.SaleHeaders");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerDebts");
            DropTable("dbo.CustomerPayments");
            DropTable("dbo.CashRegisterMoves");
            DropTable("dbo.Stores");
            DropTable("dbo.CashRegisters");
            DropTable("dbo.CashFounds");
            DropTable("dbo.Users");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.PurchaseHeaders");
            DropTable("dbo.Vendors");
            DropTable("dbo.Sizes");
            DropTable("dbo.Colors");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.ProductHeaders");
            DropTable("dbo.Brands");
        }
    }
}
