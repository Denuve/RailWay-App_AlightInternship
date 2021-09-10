namespace Backend_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSeats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "BookingCode", c => c.Guid(nullable: false));
            DropColumn("dbo.Seats", "BookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "BookingId", c => c.Guid(nullable: false));
            DropColumn("dbo.Seats", "BookingCode");
        }
    }
}
