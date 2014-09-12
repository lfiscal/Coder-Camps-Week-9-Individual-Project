namespace MovieApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Poster = c.String(),
                        Year = c.Int(nullable: false),
                        Rated = c.String(),
                        Released = c.String(),
                        Runtime = c.String(),
                        Genre = c.String(),
                        Actors = c.String(),
                        Language = c.String(),
                        Country = c.String(),
                        imdbRating = c.Single(nullable: false),
                        Plot = c.String(),
                        Director = c.String(),
                        Status = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "UserId", "dbo.Users");
            DropIndex("dbo.Movies", new[] { "UserId" });
            DropTable("dbo.Movies");
        }
    }
}
