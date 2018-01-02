namespace Vidifi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGenreIDColumnInMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("EXEC sp_rename 'Movies.Genre_Id', 'GenreId', 'COLUMN'; ");
        }
        
        public override void Down()
        {
        }
    }
}
