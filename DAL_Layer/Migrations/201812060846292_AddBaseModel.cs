namespace DAL_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArriveOfDespacthModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        Carrier = c.String(),
                        Vessel = c.String(),
                        Voyage = c.String(),
                        CTD = c.DateTime(nullable: false),
                        ETA = c.DateTime(nullable: false),
                        OriginPort = c.String(),
                        DestinationPort = c.String(),
                        Mode = c.String(),
                        Confirmed = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingModels", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.BookingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.String(),
                        OrderId = c.Int(nullable: false),
                        Line = c.String(),
                        Item = c.String(),
                        Carier = c.String(),
                        Vessel = c.String(),
                        ETD = c.DateTime(nullable: false),
                        ETA = c.DateTime(nullable: false),
                        Voyage = c.String(),
                        Quantity = c.Int(nullable: false),
                        Cartoons = c.Int(nullable: false),
                        Cube = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackType = c.String(),
                        LoadingType = c.String(),
                        Mode = c.String(),
                        FreightTerms = c.String(),
                        Consignee = c.String(),
                        GrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingDate = c.DateTime(nullable: false),
                        BookingType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CAModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingModels", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.DCBookingDetailModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line = c.String(maxLength: 30),
                        Quantity = c.Int(nullable: false),
                        Cartons = c.Int(nullable: false),
                        Cube = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Item = c.String(maxLength: 50),
                        OrderId = c.Int(nullable: false),
                        Container = c.String(),
                        DCBookingId = c.Int(nullable: false),
                        DCConfirmationDetailModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DCBookingModels", t => t.DCBookingId, cascadeDelete: true)
                .ForeignKey("dbo.OrderModels", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.DCConfirmationDetailModels", t => t.DCConfirmationDetailModel_Id)
                .Index(t => t.OrderId)
                .Index(t => t.DCBookingId)
                .Index(t => t.DCConfirmationDetailModel_Id);
            
            CreateTable(
                "dbo.DCBookingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryMethod = c.String(maxLength: 20),
                        WareHouse = c.String(maxLength: 50),
                        BookingRef = c.String(maxLength: 12),
                        BookingDate = c.DateTime(nullable: false),
                        BookingTime = c.String(maxLength: 12),
                        Haulier = c.String(maxLength: 30),
                        CreatedBy = c.String(maxLength: 30),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Company = c.String(maxLength: 30),
                        Supplier = c.String(maxLength: 30),
                        Origin = c.String(nullable: false),
                        PortOfLoading = c.String(nullable: false),
                        PortOfDelivery = c.String(nullable: false),
                        Buyer = c.String(maxLength: 30),
                        Department = c.String(maxLength: 30),
                        OrderType = c.String(maxLength: 30),
                        Season = c.String(),
                        Factory = c.String(maxLength: 30),
                        Currency = c.String(),
                        ShipDate = c.DateTime(nullable: false),
                        LatestShipDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Mode = c.String(),
                        Vendor = c.String(maxLength: 30),
                        POQuantity = c.Single(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DCConfirmationDetailModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DCConfirmationId = c.Int(nullable: false),
                        Order = c.String(maxLength: 30),
                        Line = c.String(maxLength: 30),
                        Quantity = c.Int(nullable: false),
                        Cartons = c.Int(nullable: false),
                        Item = c.String(maxLength: 50),
                        Container = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DCConfirmationModels", t => t.DCConfirmationId, cascadeDelete: true)
                .Index(t => t.DCConfirmationId);
            
            CreateTable(
                "dbo.DCConfirmationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryTime = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManifestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        Seal = c.String(),
                        Container = c.String(),
                        Loading = c.String(),
                        Bars = c.Int(nullable: false),
                        Equipment = c.String(),
                        Quantity = c.Int(nullable: false),
                        Cartoons = c.Int(nullable: false),
                        Cartons = c.String(),
                        Cube = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KGS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FreightTerms = c.String(),
                        ChargeableKGS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackType = c.String(),
                        NetKGS = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingModels", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.OrderDetailModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line = c.String(),
                        Description = c.String(maxLength: 255),
                        Warehouse = c.String(maxLength: 30),
                        Colour = c.String(maxLength: 30),
                        Size = c.String(maxLength: 30),
                        Item = c.String(),
                        Quantity = c.Single(nullable: false),
                        Cartons = c.Single(nullable: false),
                        Cube = c.Single(nullable: false),
                        KGS = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        RetailPrice = c.Single(nullable: false),
                        Tariff = c.String(),
                        OrderId = c.Int(nullable: false),
                        OrderModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderModels", t => t.OrderModel_Id)
                .Index(t => t.OrderModel_Id);
            
            CreateTable(
                "dbo.ProgressCheckModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Complete = c.Boolean(nullable: false),
                        OnSchedule = c.Boolean(nullable: false),
                        IntendedShipDate = c.DateTime(nullable: false),
                        EstQtyToShip = c.Int(nullable: false),
                        InspectionDate = c.DateTime(nullable: false),
                        Comments = c.String(),
                        OrderId = c.Int(nullable: false),
                        OrderModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderModels", t => t.OrderModel_Id)
                .Index(t => t.OrderModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgressCheckModels", "OrderModel_Id", "dbo.OrderModels");
            DropForeignKey("dbo.OrderDetailModels", "OrderModel_Id", "dbo.OrderModels");
            DropForeignKey("dbo.ManifestModels", "BookingId", "dbo.BookingModels");
            DropForeignKey("dbo.DCConfirmationDetailModels", "DCConfirmationId", "dbo.DCConfirmationModels");
            DropForeignKey("dbo.DCBookingDetailModels", "DCConfirmationDetailModel_Id", "dbo.DCConfirmationDetailModels");
            DropForeignKey("dbo.DCBookingDetailModels", "OrderId", "dbo.OrderModels");
            DropForeignKey("dbo.DCBookingDetailModels", "DCBookingId", "dbo.DCBookingModels");
            DropForeignKey("dbo.CAModels", "BookingId", "dbo.BookingModels");
            DropForeignKey("dbo.ArriveOfDespacthModels", "BookingId", "dbo.BookingModels");
            DropIndex("dbo.ProgressCheckModels", new[] { "OrderModel_Id" });
            DropIndex("dbo.OrderDetailModels", new[] { "OrderModel_Id" });
            DropIndex("dbo.ManifestModels", new[] { "BookingId" });
            DropIndex("dbo.DCConfirmationDetailModels", new[] { "DCConfirmationId" });
            DropIndex("dbo.DCBookingDetailModels", new[] { "DCConfirmationDetailModel_Id" });
            DropIndex("dbo.DCBookingDetailModels", new[] { "DCBookingId" });
            DropIndex("dbo.DCBookingDetailModels", new[] { "OrderId" });
            DropIndex("dbo.CAModels", new[] { "BookingId" });
            DropIndex("dbo.ArriveOfDespacthModels", new[] { "BookingId" });
            DropTable("dbo.ProgressCheckModels");
            DropTable("dbo.OrderDetailModels");
            DropTable("dbo.ManifestModels");
            DropTable("dbo.DCConfirmationModels");
            DropTable("dbo.DCConfirmationDetailModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.DCBookingModels");
            DropTable("dbo.DCBookingDetailModels");
            DropTable("dbo.CAModels");
            DropTable("dbo.BookingModels");
            DropTable("dbo.ArriveOfDespacthModels");
        }
    }
}
