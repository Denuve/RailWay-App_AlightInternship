namespace Backend_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedbookings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookSeats",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                        CNP = c.String(),
                        BookingCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Seats", "BookingId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seats", "BookingId");
            DropTable("dbo.BookSeats");
        }
    }
}
