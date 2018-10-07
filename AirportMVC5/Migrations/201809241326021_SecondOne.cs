namespace AirportMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Departure = c.String(),
                        Arrival = c.String(),
                        DepartureDay = c.DateTime(nullable: false),
                        DepartureTime = c.Time(nullable: false, precision: 7),
                        ArrivalDay = c.DateTime(nullable: false),
                        ArrivalTime = c.Time(nullable: false, precision: 7),
                        FlightTime = c.Time(nullable: false, precision: 7),
                        FlightStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Flights", "FlightTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "FlightTime");
            DropTable("dbo.Trips");
        }
    }
}
