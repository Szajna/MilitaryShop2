namespace MilitaryShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageBasket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketItems", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasketItems", "Image");
        }
    }
}
