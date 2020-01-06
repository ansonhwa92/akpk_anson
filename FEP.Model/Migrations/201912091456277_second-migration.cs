namespace FEP.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupMembers", "LearnerId", "dbo.Learners");
            DropForeignKey("dbo.KMCUser", "KMCId", "dbo.KMCs");
            DropForeignKey("dbo.KMCUser", "UserId", "dbo.User");
            DropIndex("dbo.GroupMembers", new[] { "LearnerId" });
            DropIndex("dbo.KMCUser", new[] { "KMCId" });
            DropIndex("dbo.KMCUser", new[] { "UserId" });
            CreateTable(
                "dbo.CourseAdditionalInputResponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InputId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Answers = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAdditionalInputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        Contents = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseContentAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Answers = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseContentQuizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ContentId = c.Int(nullable: false),
                        CourseModuleId = c.Int(),
                        CourseId = c.Int(),
                        Contents = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExhibitionRecommendation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recommendation = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        Display = c.Boolean(nullable: false),
                        ExhibitionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.EventExhibitionRequest", t => t.ExhibitionId)
                .Index(t => t.CreatedBy)
                .Index(t => t.ExhibitionId);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        Header = c.String(),
                        Template = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UpdatedBy)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.FeedbackContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        FeedbackId = c.Int(nullable: false),
                        ViewId = c.Int(nullable: false),
                        Content = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feedback", t => t.FeedbackId)
                .ForeignKey("dbo.FeedbackView", t => t.ViewId)
                .ForeignKey("dbo.User", t => t.UpdatedBy)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.FeedbackId)
                .Index(t => t.ViewId);
            
            CreateTable(
                "dbo.FeedbackView",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        View = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KMCRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KMCId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KMCs", t => t.KMCId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.KMCId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.MediaRepresentative",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MediaId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventMediaInterviewRequest", t => t.MediaId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.MediaId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PublicEventImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        CoverPicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublicEventPurchaseItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseOrderId = c.Int(),
                        EventId = c.Int(nullable: false),
                        Ticket = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.PublicEvent", "SeatAllocated_EarlyBird", c => c.Int());
            AddColumn("dbo.EventSpeaker", "Thumbnail", c => c.String());
            AddColumn("dbo.CourseCertificates", "Name", c => c.String());
            AddColumn("dbo.CourseCertificateTemplates", "Name", c => c.String());
            AddColumn("dbo.CourseContents", "FeedbackId", c => c.Int());
            AddColumn("dbo.CourseContents", "FeedbackEnable", c => c.Boolean());
            AddColumn("dbo.CourseEvents", "IsTrial", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupMembers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.GroupMembers", "UserId");
            AddForeignKey("dbo.GroupMembers", "UserId", "dbo.User", "Id");
            DropColumn("dbo.GroupMembers", "LearnerId");
            DropTable("dbo.KMCUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KMCUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KMCId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GroupMembers", "LearnerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MediaRepresentative", "UserId", "dbo.User");
            DropForeignKey("dbo.MediaRepresentative", "MediaId", "dbo.EventMediaInterviewRequest");
            DropForeignKey("dbo.KMCRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.KMCRole", "KMCId", "dbo.KMCs");
            DropForeignKey("dbo.FeedbackContent", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.FeedbackContent", "UpdatedBy", "dbo.User");
            DropForeignKey("dbo.FeedbackContent", "ViewId", "dbo.FeedbackView");
            DropForeignKey("dbo.FeedbackContent", "FeedbackId", "dbo.Feedback");
            DropForeignKey("dbo.Feedback", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.Feedback", "UpdatedBy", "dbo.User");
            DropForeignKey("dbo.ExhibitionRecommendation", "ExhibitionId", "dbo.EventExhibitionRequest");
            DropForeignKey("dbo.ExhibitionRecommendation", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.GroupMembers", "UserId", "dbo.User");
            DropIndex("dbo.MediaRepresentative", new[] { "UserId" });
            DropIndex("dbo.MediaRepresentative", new[] { "MediaId" });
            DropIndex("dbo.KMCRole", new[] { "RoleId" });
            DropIndex("dbo.KMCRole", new[] { "KMCId" });
            DropIndex("dbo.FeedbackContent", new[] { "ViewId" });
            DropIndex("dbo.FeedbackContent", new[] { "FeedbackId" });
            DropIndex("dbo.FeedbackContent", new[] { "UpdatedBy" });
            DropIndex("dbo.FeedbackContent", new[] { "CreatedBy" });
            DropIndex("dbo.Feedback", new[] { "UpdatedBy" });
            DropIndex("dbo.Feedback", new[] { "CreatedBy" });
            DropIndex("dbo.ExhibitionRecommendation", new[] { "ExhibitionId" });
            DropIndex("dbo.ExhibitionRecommendation", new[] { "CreatedBy" });
            DropIndex("dbo.GroupMembers", new[] { "UserId" });
            DropColumn("dbo.GroupMembers", "UserId");
            DropColumn("dbo.CourseEvents", "IsTrial");
            DropColumn("dbo.CourseContents", "FeedbackEnable");
            DropColumn("dbo.CourseContents", "FeedbackId");
            DropColumn("dbo.CourseCertificateTemplates", "Name");
            DropColumn("dbo.CourseCertificates", "Name");
            DropColumn("dbo.EventSpeaker", "Thumbnail");
            DropColumn("dbo.PublicEvent", "SeatAllocated_EarlyBird");
            DropTable("dbo.PublicEventPurchaseItem");
            DropTable("dbo.PublicEventImages");
            DropTable("dbo.MediaRepresentative");
            DropTable("dbo.KMCRole");
            DropTable("dbo.FeedbackView");
            DropTable("dbo.FeedbackContent");
            DropTable("dbo.Feedback");
            DropTable("dbo.ExhibitionRecommendation");
            DropTable("dbo.CourseContentQuizs");
            DropTable("dbo.CourseContentAnswers");
            DropTable("dbo.CourseAdditionalInputs");
            DropTable("dbo.CourseAdditionalInputResponses");
            CreateIndex("dbo.KMCUser", "UserId");
            CreateIndex("dbo.KMCUser", "KMCId");
            CreateIndex("dbo.GroupMembers", "LearnerId");
            AddForeignKey("dbo.KMCUser", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.KMCUser", "KMCId", "dbo.KMCs", "Id");
            AddForeignKey("dbo.GroupMembers", "LearnerId", "dbo.Learners", "Id");
        }
    }
}
