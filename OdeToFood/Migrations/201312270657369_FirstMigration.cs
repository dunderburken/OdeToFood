namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestaurantReviews", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.RestaurantReviews", new[] { "Restaurant_Id" });
            RenameColumn(table: "dbo.RestaurantReviews", name: "Restaurant_Id", newName: "RestaurantId");
            AddColumn("dbo.Restaurants", "Name", c => c.String());
            AddColumn("dbo.Restaurants", "City", c => c.String());
            AddColumn("dbo.Restaurants", "Country", c => c.String());
            AddColumn("dbo.RestaurantReviews", "Body", c => c.String());
            AlterColumn("dbo.RestaurantReviews", "RestaurantId", c => c.Int(nullable: false));
            CreateIndex("dbo.RestaurantReviews", "RestaurantId");
            AddForeignKey("dbo.RestaurantReviews", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
            DropColumn("dbo.Restaurants", "Rating");
            DropColumn("dbo.Restaurants", "Body");
            DropColumn("dbo.Restaurants", "RestaurantId");
            DropColumn("dbo.RestaurantReviews", "Name");
            DropColumn("dbo.RestaurantReviews", "City");
            DropColumn("dbo.RestaurantReviews", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantReviews", "Country", c => c.String());
            AddColumn("dbo.RestaurantReviews", "City", c => c.String());
            AddColumn("dbo.RestaurantReviews", "Name", c => c.String());
            AddColumn("dbo.Restaurants", "RestaurantId", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "Body", c => c.String());
            AddColumn("dbo.Restaurants", "Rating", c => c.Int(nullable: false));
            DropForeignKey("dbo.RestaurantReviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.RestaurantReviews", new[] { "RestaurantId" });
            AlterColumn("dbo.RestaurantReviews", "RestaurantId", c => c.Int());
            DropColumn("dbo.RestaurantReviews", "Body");
            DropColumn("dbo.Restaurants", "Country");
            DropColumn("dbo.Restaurants", "City");
            DropColumn("dbo.Restaurants", "Name");
            RenameColumn(table: "dbo.RestaurantReviews", name: "RestaurantId", newName: "Restaurant_Id");
            CreateIndex("dbo.RestaurantReviews", "Restaurant_Id");
            AddForeignKey("dbo.RestaurantReviews", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
