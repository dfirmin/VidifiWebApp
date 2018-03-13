namespace Vidifi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumberAvailableToMoviesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("Update Movies Set NumberAvailable = NumberInstock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
