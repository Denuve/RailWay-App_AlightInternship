namespace Backend_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeatUpgrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "Occupied", c => c.Boolean(nullable: false));
            DropColumn("dbo.Seats", "Free");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "Free", c => c.Boolean(nullable: false));
            DropColumn("dbo.Seats", "Occupied");
        }
    }
}
