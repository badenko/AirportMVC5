namespace AirportMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringConvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "DepartureTerminal", c => c.String());
            AddColumn("dbo.Trips", "ArrivalTerminal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "ArrivalTerminal");
            DropColumn("dbo.Trips", "DepartureTerminal");
        }
    }
}
