namespace Vidifi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Pay as You Go', 'Monthly', 'Quarterly', 'Annual'");
            
        }
        
        public override void Down()
        {
        }
    }
}
