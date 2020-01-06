namespace FEP.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsArticle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        NewsArticleImage = c.String(),
                        PublishDate = c.DateTime(),
                        PublishedBy = c.Int(),
                        Display = c.Boolean(nullable: false),
                        DisplayDate = c.DateTime(),
                        Source = c.String(),
                        SourceLink = c.String(),
                        Sequence = c.Int(nullable: false),
                        FreeTextArea = c.String(storeType: "ntext"),
                        NewsCategory = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(),
                        LastModifiedDate = c.DateTime(),
                        RefNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.User", t => t.DeletedBy)
                .ForeignKey("dbo.User", t => t.LastModifiedBy)
                .ForeignKey("dbo.User", t => t.PublishedBy)
                .Index(t => t.PublishedBy)
                .Index(t => t.Sequence)
                .Index(t => t.DeletedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.LastModifiedBy);
            
            CreateTable(
                "dbo.NewsArticleCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsArticleFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FileDocument", t => t.FileId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.NewsArticleImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NewsArticleID = c.Int(nullable: false),
                        CoverPicture = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsArticleFile", "FileId", "dbo.FileDocument");
            DropForeignKey("dbo.NewsArticle", "PublishedBy", "dbo.User");
            DropForeignKey("dbo.NewsArticle", "LastModifiedBy", "dbo.User");
            DropForeignKey("dbo.NewsArticle", "DeletedBy", "dbo.User");
            DropForeignKey("dbo.NewsArticle", "CreatedBy", "dbo.User");
            DropIndex("dbo.NewsArticleFile", new[] { "FileId" });
            DropIndex("dbo.NewsArticle", new[] { "LastModifiedBy" });
            DropIndex("dbo.NewsArticle", new[] { "CreatedBy" });
            DropIndex("dbo.NewsArticle", new[] { "DeletedBy" });
            DropIndex("dbo.NewsArticle", new[] { "Sequence" });
            DropIndex("dbo.NewsArticle", new[] { "PublishedBy" });
            DropTable("dbo.NewsArticleImages");
            DropTable("dbo.NewsArticleFile");
            DropTable("dbo.NewsArticleCategory");
            DropTable("dbo.NewsArticle");
        }
    }
}
