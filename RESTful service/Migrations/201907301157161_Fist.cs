namespace RESTful_service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Director = c.String(),
                        Description = c.String(),
                        Movie_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId)
                .Index(t => t.Movie_MovieId);
            
            CreateTable(
                "dbo.ContributorTypes",
                c => new
                    {
                        ContributorTypeId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        MovieId = c.Int(nullable: false),
                        Contributors_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ContributorTypeId)
                .ForeignKey("dbo.Contributors", t => t.Contributors_Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.Contributors_Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Movie_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.ContributorTypes", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Contributors", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.ContributorTypes", "Contributors_Id", "dbo.Contributors");
            DropIndex("dbo.Genres", new[] { "Movie_MovieId" });
            DropIndex("dbo.ContributorTypes", new[] { "Contributors_Id" });
            DropIndex("dbo.ContributorTypes", new[] { "MovieId" });
            DropIndex("dbo.Contributors", new[] { "Movie_MovieId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.ContributorTypes");
            DropTable("dbo.Contributors");
        }
    }
}
