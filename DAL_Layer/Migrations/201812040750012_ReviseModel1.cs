namespace DAL_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviseModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetailModels", "OrderID", "dbo.OrderModels");
            DropForeignKey("dbo.ProgressCheckModels", "OrderID", "dbo.OrderModels");
            DropForeignKey("dbo.DCConfirmationDetailModels", "DCConfirmationModel_Id", "dbo.DCConfirmationModels");
            DropIndex("dbo.ArriveOfDespacthModels", new[] { "BookingID" });
            DropIndex("dbo.CAModels", new[] { "BookingID" });
            DropIndex("dbo.DCConfirmationDetailModels", new[] { "DCConfirmationModel_Id" });
            DropIndex("dbo.ManifestModels", new[] { "BookingID" });
            DropIndex("dbo.OrderDetailModels", new[] { "OrderID" });
            DropIndex("dbo.ProgressCheckModels", new[] { "OrderID" });
            DropColumn("dbo.DCConfirmationDetailModels", "DCConfirmationId");
            RenameColumn(table: "dbo.DCConfirmationDetailModels", name: "DCConfirmationModel_Id", newName: "DCConfirmationId");
            AddColumn("dbo.OrderModels", "POQuantity", c => c.Single(nullable: false));
            AddColumn("dbo.OrderDetailModels", "OrderModel_Id", c => c.Int());
            AddColumn("dbo.ProgressCheckModels", "OrderModel_Id", c => c.Int());
            AlterColumn("dbo.DCConfirmationDetailModels", "DCConfirmationId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgressCheckModels", "Complete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProgressCheckModels", "OnSchedule", c => c.Boolean(nullable: false));
            CreateIndex("dbo.ArriveOfDespacthModels", "BookingId");
            CreateIndex("dbo.CAModels", "BookingId");
            CreateIndex("dbo.DCConfirmationDetailModels", "DCConfirmationId");
            CreateIndex("dbo.ManifestModels", "BookingId");
            CreateIndex("dbo.OrderDetailModels", "OrderModel_Id");
            CreateIndex("dbo.ProgressCheckModels", "OrderModel_Id");
            AddForeignKey("dbo.OrderDetailModels", "OrderModel_Id", "dbo.OrderModels", "Id");
            AddForeignKey("dbo.ProgressCheckModels", "OrderModel_Id", "dbo.OrderModels", "Id");
            AddForeignKey("dbo.DCConfirmationDetailModels", "DCConfirmationId", "dbo.DCConfirmationModels", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderDetailModels", "TotalPrice");
            DropColumn("dbo.OrderDetailModels", "TotalRetailPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetailModels", "TotalRetailPrice", c => c.Single(nullable: false));
            AddColumn("dbo.OrderDetailModels", "TotalPrice", c => c.Single(nullable: false));
            DropForeignKey("dbo.DCConfirmationDetailModels", "DCConfirmationId", "dbo.DCConfirmationModels");
            DropForeignKey("dbo.ProgressCheckModels", "OrderModel_Id", "dbo.OrderModels");
            DropForeignKey("dbo.OrderDetailModels", "OrderModel_Id", "dbo.OrderModels");
            DropIndex("dbo.ProgressCheckModels", new[] { "OrderModel_Id" });
            DropIndex("dbo.OrderDetailModels", new[] { "OrderModel_Id" });
            DropIndex("dbo.ManifestModels", new[] { "BookingId" });
            DropIndex("dbo.DCConfirmationDetailModels", new[] { "DCConfirmationId" });
            DropIndex("dbo.CAModels", new[] { "BookingId" });
            DropIndex("dbo.ArriveOfDespacthModels", new[] { "BookingId" });
            AlterColumn("dbo.ProgressCheckModels", "OnSchedule", c => c.String());
            AlterColumn("dbo.ProgressCheckModels", "Complete", c => c.String());
            AlterColumn("dbo.DCConfirmationDetailModels", "DCConfirmationId", c => c.Int());
            DropColumn("dbo.ProgressCheckModels", "OrderModel_Id");
            DropColumn("dbo.OrderDetailModels", "OrderModel_Id");
            DropColumn("dbo.OrderModels", "POQuantity");
            RenameColumn(table: "dbo.DCConfirmationDetailModels", name: "DCConfirmationId", newName: "DCConfirmationModel_Id");
            AddColumn("dbo.DCConfirmationDetailModels", "DCConfirmationId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgressCheckModels", "OrderID");
            CreateIndex("dbo.OrderDetailModels", "OrderID");
            CreateIndex("dbo.ManifestModels", "BookingID");
            CreateIndex("dbo.DCConfirmationDetailModels", "DCConfirmationModel_Id");
            CreateIndex("dbo.CAModels", "BookingID");
            CreateIndex("dbo.ArriveOfDespacthModels", "BookingID");
            AddForeignKey("dbo.DCConfirmationDetailModels", "DCConfirmationModel_Id", "dbo.DCConfirmationModels", "Id");
            AddForeignKey("dbo.ProgressCheckModels", "OrderID", "dbo.OrderModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetailModels", "OrderID", "dbo.OrderModels", "ID", cascadeDelete: true);
        }
    }
}
