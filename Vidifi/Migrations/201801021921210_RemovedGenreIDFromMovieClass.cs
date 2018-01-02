namespace Vidifi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedGenreIDFromMovieClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            
        }
    }
}
