namespace Backend_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TrainId = c.Guid(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarId = c.Guid(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        Free = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        DayOfWeek = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trains");
            DropTable("dbo.Seats");
            DropTable("dbo.Cars");
        }
    }
}
