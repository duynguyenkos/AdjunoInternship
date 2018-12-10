namespace DAL_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPONumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderModels", "PONumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderModels", "PONumber");
        }
    }
}
