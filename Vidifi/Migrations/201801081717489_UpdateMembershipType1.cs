namespace Vidifi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay as You Go' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
