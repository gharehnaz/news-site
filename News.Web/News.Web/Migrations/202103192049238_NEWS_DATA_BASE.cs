namespace News.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NEWS_DATA_BASE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsCategoryEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Author = c.String(),
                        NewsCategory_Id = c.Long(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        PictureUrl = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsCategoryEntities", t => t.NewsCategory_Id, cascadeDelete: true)
                .Index(t => t.NewsCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsEntities", "NewsCategory_Id", "dbo.NewsCategoryEntities");
            DropIndex("dbo.NewsEntities", new[] { "NewsCategory_Id" });
            DropTable("dbo.NewsEntities");
            DropTable("dbo.NewsCategoryEntities");
        }
    }
}
