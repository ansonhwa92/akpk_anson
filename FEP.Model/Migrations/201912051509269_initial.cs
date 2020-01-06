namespace FEP.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Access",
                c => new
                    {
                        UserAccess = c.Int(nullable: false),
                        Module = c.Int(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserAccess);
            
            CreateTable(
                "dbo.RoleAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserAccess = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Access", t => t.UserAccess)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.UserAccess);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountSetting",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsPasswordExpiry = c.Boolean(nullable: false),
                        IsLimitLoginAttempt = c.Boolean(nullable: false),
                        PasswordExpiryDuration = c.Int(),
                        LoginAttemptLimit = c.Int(),
                        InactiveDuration = c.Int(nullable: false),
                        IsContainLowerCase = c.Boolean(nullable: false),
                        IsContainUpperCase = c.Boolean(nullable: false),
                        IsContainNumeric = c.Boolean(nullable: false),
                        IsContainSymbol = c.Boolean(nullable: false),
                        IsLengthLimit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivateAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UID = c.String(),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActivate = c.Boolean(nullable: false),
                        ActivateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ICNo = c.String(),
                        CountryCode = c.String(),
                        MobileNo = c.String(),
                        UserType = c.Int(nullable: false),
                        Display = c.Boolean(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CompanyName = c.String(),
                        SectorId = c.Int(),
                        MinistryId = c.Int(),
                        CompanyRegNo = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                        StateId = c.Int(),
                        StateName = c.String(),
                        CountryId = c.Int(nullable: false),
                        CountryCode = c.String(),
                        CompanyPhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.Ministry", t => t.MinistryId)
                .ForeignKey("dbo.Sector", t => t.SectorId)
                .ForeignKey("dbo.State", t => t.StateId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SectorId)
                .Index(t => t.MinistryId)
                .Index(t => t.StateId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryCode1 = c.String(),
                        CountryCode2 = c.String(),
                        CountryCode3 = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ministry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndividualProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        IsMalaysian = c.Boolean(nullable: false),
                        CitizenshipId = c.Int(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                        StateId = c.Int(),
                        StateName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Country", t => t.CitizenshipId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.State", t => t.StateId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CitizenshipId)
                .Index(t => t.StateId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.StaffProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        StaffId = c.String(),
                        DepartmentId = c.Int(),
                        BranchId = c.Int(),
                        DesignationId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Designation", t => t.DesignationId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DepartmentId)
                .Index(t => t.BranchId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.String(),
                        StateId = c.Int(nullable: false),
                        Name = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptId = c.String(),
                        Name = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationId = c.String(),
                        Name = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        LoginId = c.String(),
                        HashPassword = c.String(),
                        Salt = c.String(),
                        IsEnable = c.Boolean(nullable: false),
                        LastLogin = c.DateTime(),
                        LastPasswordChange = c.DateTime(),
                        LoginAttempt = c.Int(nullable: false),
                        ValidFrom = c.DateTime(),
                        ValidTo = c.DateTime(),
                        Avatar = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.UserAccount", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AgendaScript",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TentativeScript = c.String(),
                        EventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.PublicEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefNo = c.String(),
                        EventTitle = c.String(),
                        EventObjective = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Venue = c.String(),
                        FreeIndividual = c.Boolean(nullable: false),
                        IndividualFee = c.Single(),
                        IndividualEarlyBird = c.Single(),
                        FreeIndividualPaper = c.Boolean(nullable: false),
                        IndividualPaperFee = c.Single(),
                        IndividualPaperEarlyBird = c.Single(),
                        FreeIndividualPresent = c.Boolean(nullable: false),
                        IndividualPresentFee = c.Single(),
                        IndividualPresentEarlyBird = c.Single(),
                        FreeAgency = c.Boolean(nullable: false),
                        AgencyFee = c.Single(),
                        AgencyEarlyBird = c.Single(),
                        ParticipantAllowed = c.Int(),
                        TargetedGroup = c.Int(),
                        Remarks = c.String(),
                        EventStatus = c.Int(),
                        EventCategoryId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                        SLAReminderStatusId = c.Int(),
                        IsRequested = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.EventCategory", t => t.EventCategoryId)
                .Index(t => t.EventCategoryId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.EventAgenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgendaTitle = c.String(),
                        AgendaDescription = c.String(),
                        Tentative = c.String(),
                        Time = c.DateTime(),
                        EventId = c.Int(),
                        PersonInChargeId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .ForeignKey("dbo.User", t => t.PersonInChargeId)
                .Index(t => t.EventId)
                .Index(t => t.PersonInChargeId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.EventCategory",
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
                "dbo.AssessmentResponse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SurveyID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ResponseDate = c.DateTime(nullable: false),
                        Contents = c.String(),
                        Answers = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AssessmentSurvey", t => t.SurveyID)
                .Index(t => t.SurveyID);
            
            CreateTable(
                "dbo.AssessmentSurvey",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssessmentID = c.Int(nullable: false),
                        Contents = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssignedExternalExhibitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalExhibitorId = c.Int(nullable: false),
                        PublicEventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventExternalExhibitor", t => t.ExternalExhibitorId)
                .ForeignKey("dbo.PublicEvent", t => t.PublicEventId)
                .Index(t => t.ExternalExhibitorId)
                .Index(t => t.PublicEventId);
            
            CreateTable(
                "dbo.EventExternalExhibitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        CompanyName = c.String(),
                        PhoneNo = c.String(),
                        Remark = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.AssignedSpeaker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicEventId = c.Int(nullable: false),
                        EventSpeakerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventSpeaker", t => t.EventSpeakerId)
                .ForeignKey("dbo.PublicEvent", t => t.PublicEventId)
                .Index(t => t.PublicEventId)
                .Index(t => t.EventSpeakerId);
            
            CreateTable(
                "dbo.EventSpeaker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpeakerType = c.Int(),
                        SpeakerStatus = c.Int(),
                        Experience = c.String(),
                        UserId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.BankInformation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BulkNotification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationMedium = c.Int(nullable: false),
                        SLAReminderStatusId = c.Int(nullable: false),
                        NotificationId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carousel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        CarouselImage = c.String(),
                        Display = c.Boolean(nullable: false),
                        DisplayDate = c.DateTime(),
                        Sequence = c.Int(nullable: false),
                        FreeTextArea = c.String(storeType: "ntext"),
                        TextLocation = c.Int(nullable: false),
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
                .Index(t => t.Sequence)
                .Index(t => t.DeletedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.LastModifiedBy);
            
            CreateTable(
                "dbo.CarouselFile",
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
                "dbo.FileDocument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                        FileSize = c.Int(nullable: false),
                        FileType = c.String(),
                        FileTag = c.String(),
                        Directory = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        FileNameOnStorage = c.String(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.CarouselImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarouselID = c.Int(nullable: false),
                        CoverPicture = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SecretKey = c.String(),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContentFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        FileType = c.Int(nullable: false),
                        FileName = c.String(),
                        FileDocumentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ContentId = c.Int(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileDocument", t => t.FileDocumentId)
                .Index(t => t.FileDocumentId);
            
            CreateTable(
                "dbo.ContentQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        CourseId = c.Int(),
                        QuestionId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        QuestionType = c.Int(nullable: false),
                        MultipleChoiceAnswerId = c.Int(nullable: false),
                        OrderAnswerString = c.String(),
                        FreeTextAnswer = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FreeTextAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Answer = c.String(),
                        Point = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.MultipleChoiceAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Answer = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.OrderAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Answer = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.CourseApprovalLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        CreatedByName = c.String(),
                        ApprovalLevel = c.Int(nullable: false),
                        ApprovalStatus = c.Int(nullable: false),
                        ApproverId = c.Int(),
                        ApprovedByName = c.String(),
                        ActionDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsNextLevelRequired = c.Boolean(nullable: false),
                        Remark = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ApproverId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.ApproverId);
            
            CreateTable(
                "dbo.CourseCertificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        BackgroundImageFilename = c.String(),
                        FileUploadId = c.Int(nullable: false),
                        TypePageOrientation = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileUpload", t => t.FileUploadId)
                .Index(t => t.FileUploadId);
            
            CreateTable(
                "dbo.FileUpload",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        FileType = c.Int(nullable: false),
                        FileName = c.String(),
                        FilePath = c.String(),
                        FileSize = c.Int(nullable: false),
                        FileTag = c.String(),
                        FileNameOnStorage = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.CourseCertificateTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Template = c.String(),
                        TypePageOrientation = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CourseModuleId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        ContentType = c.Int(nullable: false),
                        VideoType = c.Int(),
                        AudioType = c.Int(),
                        DocumentType = c.Int(),
                        Url = c.String(),
                        ContentFileId = c.Int(),
                        Text = c.String(),
                        ShowIFrameAs = c.Int(nullable: false),
                        CompletionType = c.Int(nullable: false),
                        QuestionType = c.Int(),
                        QuestionId = c.Int(),
                        Timer = c.Int(nullable: false),
                        IntroImageFileName = c.String(),
                        Height = c.Int(),
                        Width = c.Int(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentFiles", t => t.ContentFileId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.CourseModules", t => t.CourseModuleId)
                .Index(t => t.CourseModuleId)
                .Index(t => t.ContentFileId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.CourseEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        EnrollmentCode = c.String(nullable: false, maxLength: 150),
                        CourseId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                        LastDateToCancel = c.DateTime(),
                        GroupId = c.Int(),
                        ViewCategory = c.Int(nullable: false),
                        TrialRemark = c.String(),
                        AllowablePercentageBeforeWithdraw = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDisplayed = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.EnrollmentCode, unique: true)
                .Index(t => t.CourseId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Code = c.String(maxLength: 20),
                        Objectives = c.String(),
                        Medium = c.Int(nullable: false),
                        ScheduleType = c.Int(nullable: false),
                        Duration = c.Decimal(precision: 18, scale: 2),
                        DurationType = c.Int(nullable: false),
                        Language = c.Int(nullable: false),
                        IsFree = c.Boolean(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        IntroMaterialId = c.Int(),
                        TraversalRule = c.Int(nullable: false),
                        ScoreCalculation = c.Int(nullable: false),
                        TotalModules = c.Int(nullable: false),
                        CourseCertificateId = c.Int(),
                        CourseCertificateTemplateId = c.Int(),
                        DefaultAllowablePercentageBeforeWithdraw = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ViewCategory = c.Int(nullable: false),
                        CompletionCriteriaType = c.Int(nullable: false),
                        ModulesCompleted = c.String(),
                        PercentageCompletion = c.Decimal(precision: 18, scale: 2),
                        TestsPassed = c.String(),
                        LearningPath = c.String(),
                        CreatedByName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IntroImageFileName = c.String(),
                        SkillLevel = c.Int(nullable: false),
                        SLAReminderId = c.Int(nullable: false),
                        TotalContents = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RefCourseCategories", t => t.CategoryId)
                .ForeignKey("dbo.CourseCertificateTemplates", t => t.CourseCertificateTemplateId)
                .ForeignKey("dbo.CourseCertificates", t => t.CourseCertificateId)
                .ForeignKey("dbo.FileDocument", t => t.IntroMaterialId)
                .Index(t => t.CategoryId)
                .Index(t => t.Code)
                .Index(t => t.IntroMaterialId)
                .Index(t => t.CourseCertificateId)
                .Index(t => t.CourseCertificateTemplateId);
            
            CreateTable(
                "dbo.RefCourseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        IsDisplayed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GamificationCriterias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.CourseModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                        Objectives = c.String(),
                        CourseId = c.Int(nullable: false),
                        TotalVideo = c.Int(nullable: false),
                        TotalAudio = c.Int(nullable: false),
                        TotalDocument = c.Int(nullable: false),
                        TotalContent = c.Int(nullable: false),
                        TotalTest = c.Int(nullable: false),
                        TotalRichText = c.Int(nullable: false),
                        TotalAssignment = c.Int(nullable: false),
                        IntroImageFileName = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.UserId)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        TrainerId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainerId, t.CourseId })
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.TrainerGroups",
                c => new
                    {
                        TrainerId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainerId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        IsVisible = c.Boolean(nullable: false),
                        EnrollmentCode = c.String(),
                        CourseEventId = c.Int(),
                        CourseId = c.Int(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        LearnerId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Learners", t => t.LearnerId)
                .Index(t => t.GroupId)
                .Index(t => t.LearnerId);
            
            CreateTable(
                "dbo.Learners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        Badges = c.Int(nullable: false),
                        CourseEnrolled = c.Int(nullable: false),
                        CourseCompleted = c.Int(nullable: false),
                        TrainingTime = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CourseInvitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseEventId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Emails = c.String(),
                        EmailSubject = c.String(),
                        NotificationType = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.CourseEvents", t => t.CourseEventId)
                .Index(t => t.CourseEventId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnrollmentId = c.Int(nullable: false),
                        LearnerId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        ContentId = c.Int(nullable: false),
                        CourseContentType = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseId = c.Int(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollments", t => t.EnrollmentId)
                .ForeignKey("dbo.Learners", t => t.LearnerId)
                .Index(t => t.EnrollmentId)
                .Index(t => t.LearnerId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseEventId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        LearnerId = c.Int(nullable: false),
                        GroupId = c.Int(),
                        EnrolledDate = c.DateTime(),
                        WithdrawDate = c.DateTime(),
                        CancelledDate = c.DateTime(),
                        CompletionDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Score = c.Decimal(precision: 18, scale: 2),
                        TotalContentsCompleted = c.Int(nullable: false),
                        PercentageCompleted = c.Decimal(precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.CourseEvents", t => t.CourseEventId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Learners", t => t.LearnerId)
                .Index(t => t.CourseEventId)
                .Index(t => t.CourseId)
                .Index(t => t.LearnerId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.EnrollmentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnrollmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        CourseEventId = c.Int(),
                        UserId = c.Int(),
                        LearnerId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Remark = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollments", t => t.EnrollmentId)
                .Index(t => t.EnrollmentId);
            
            CreateTable(
                "dbo.DiscussionAttachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        AttachmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileDocument", t => t.AttachmentId)
                .ForeignKey("dbo.DiscussionPosts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.AttachmentId);
            
            CreateTable(
                "dbo.DiscussionPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscussionId = c.Int(nullable: false),
                        ParentId = c.Int(),
                        UserId = c.Int(nullable: false),
                        Topic = c.String(),
                        Message = c.String(),
                        IsDeleted = c.Boolean(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discussions", t => t.DiscussionId)
                .ForeignKey("dbo.DiscussionPosts", t => t.ParentId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.DiscussionId)
                .Index(t => t.ParentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CourseId = c.Int(),
                        ModuleId = c.Int(),
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(),
                        FirstPost = c.Int(nullable: false),
                        Pinned = c.Boolean(nullable: false),
                        DiscussionVisibility = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.CourseModules", t => t.ModuleId)
                .Index(t => t.CourseId)
                .Index(t => t.ModuleId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.DutyRoster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExhibitionRoadshowId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventExhibitionRequest", t => t.ExhibitionRoadshowId)
                .Index(t => t.ExhibitionRoadshowId);
            
            CreateTable(
                "dbo.EventExhibitionRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefNo = c.String(),
                        EventName = c.String(),
                        Organiser = c.String(),
                        OrganiserEmail = c.String(),
                        OrganiserPhoneNo = c.String(),
                        AddressStreet1 = c.String(),
                        AddressStreet2 = c.String(),
                        AddressPoscode = c.String(),
                        AddressCity = c.String(),
                        State = c.Int(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        ParticipationRequirement = c.Int(),
                        ExhibitionStatus = c.Int(),
                        BranchId = c.Int(),
                        NomineeId = c.Int(),
                        ReceivedById = c.Int(),
                        ReceivedDate = c.DateTime(),
                        Receive_Via = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                        SLAReminderStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.User", t => t.NomineeId)
                .ForeignKey("dbo.User", t => t.ReceivedById)
                .Index(t => t.BranchId)
                .Index(t => t.NomineeId)
                .Index(t => t.ReceivedById)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.DutyRosterOfficer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DutyRosterId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DutyRoster", t => t.DutyRosterId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.DutyRosterId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EmailToSend",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                        IsSent = c.Boolean(nullable: false),
                        SentDate = c.DateTime(),
                        Retry = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailToSendAddress",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmailToSendId = c.Long(nullable: false),
                        IsCC = c.Boolean(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailToSend", t => t.EmailToSendId)
                .Index(t => t.EmailToSendId);
            
            CreateTable(
                "dbo.ErrorLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Module = c.Int(),
                        UserId = c.Int(),
                        Source = c.String(),
                        IPAddress = c.String(),
                        ErrorDescription = c.String(),
                        ErrorDetails = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EventAttendance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendeeName = c.String(),
                        UserType = c.Int(),
                        CompanyName = c.String(),
                        BookingNumber = c.String(),
                        ICNo = c.String(),
                        CheckInStatus = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        EventId = c.Int(),
                        CreatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.EventBooking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        SeatAvailable = c.Int(),
                        Total = c.Single(nullable: false),
                        UserId = c.Int(),
                        EventId = c.Int(),
                        Tiket = c.Int(nullable: false),
                        BookingStatus = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.EventCalendar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalDay = c.Int(),
                        Remark = c.String(),
                        EventBookingId = c.Int(),
                        EventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .ForeignKey("dbo.EventBooking", t => t.EventBookingId)
                .Index(t => t.EventBookingId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.EventExhibitionRequestApproval",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovedDate = c.DateTime(),
                        Remark = c.String(),
                        Level = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        RequireNext = c.Boolean(nullable: false),
                        ApproverId = c.Int(),
                        ExhibitionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventExhibitionRequest", t => t.ExhibitionId)
                .Index(t => t.ExhibitionId);
            
            CreateTable(
                "dbo.EventFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileCategory = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileDocument", t => t.FileId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.EventMediaInterviewApproval",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovedDate = c.DateTime(),
                        Remark = c.String(),
                        Level = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        RequireNext = c.Boolean(nullable: false),
                        ApproverId = c.Int(),
                        MediaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventMediaInterviewRequest", t => t.MediaId)
                .Index(t => t.MediaId);
            
            CreateTable(
                "dbo.EventMediaInterviewRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefNo = c.String(),
                        MediaName = c.String(),
                        MediaType = c.Int(),
                        ContactPerson = c.String(),
                        ContactNo = c.String(),
                        AddressStreet1 = c.String(),
                        AddressStreet2 = c.String(),
                        AddressPoscode = c.String(),
                        AddressCity = c.String(),
                        State = c.Int(),
                        Email = c.String(),
                        DateStart = c.DateTime(),
                        DateEnd = c.DateTime(),
                        Time = c.DateTime(),
                        Location = c.String(),
                        Language = c.Int(),
                        Topic = c.String(),
                        MediaStatus = c.Int(),
                        BranchId = c.Int(),
                        UserId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                        SLAReminderStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.BranchId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.EventRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        RequestStatus = c.Int(),
                        RequestType = c.Int(),
                        SLAReminderStatusId = c.Int(),
                        EventId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.EventRequestApproval",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovedDate = c.DateTime(),
                        Remark = c.String(),
                        Level = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        RequireNext = c.Boolean(nullable: false),
                        ApproverId = c.Int(),
                        EventRequestId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventRequest", t => t.EventRequestId)
                .Index(t => t.EventRequestId);
            
            CreateTable(
                "dbo.ExhibitionNominee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExhibitionRoadshowId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventExhibitionRequest", t => t.ExhibitionRoadshowId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ExhibitionRoadshowId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FeedbackResponse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SurveyID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Email = c.String(),
                        ResponseDate = c.DateTime(nullable: false),
                        Contents = c.String(),
                        Answers = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FeedbackSurvey", t => t.SurveyID)
                .Index(t => t.SurveyID);
            
            CreateTable(
                "dbo.FeedbackSurvey",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FeedbackID = c.Int(nullable: false),
                        Contents = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InvitationEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MediaName = c.String(),
                        MediaType = c.String(),
                        UserId = c.Int(),
                        EventId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.KMCCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KMCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KMCCategoryId = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        IsEditor = c.Boolean(nullable: false),
                        KMCType = c.Int(),
                        EditorCode = c.String(),
                        FileId = c.Int(),
                        FileType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KMCCategory", t => t.KMCCategoryId)
                .ForeignKey("dbo.FileDocument", t => t.FileId)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.KMCCategoryId)
                .Index(t => t.FileId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.KMCUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KMCId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KMCs", t => t.KMCId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.KMCId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ManuscriptSubmission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        DateUploaded = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        EventId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Month = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Month);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NotificationType = c.Int(),
                        UserId = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Message = c.String(),
                        Link = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NotificationTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationType = c.Int(nullable: false),
                        TemplateName = c.String(),
                        TemplateSubject = c.String(),
                        TemplateRefNo = c.String(),
                        TemplateMessage = c.String(),
                        enableEmail = c.Boolean(nullable: false),
                        SMSMessage = c.String(),
                        enableSMSMessage = c.Boolean(nullable: false),
                        WebMessage = c.String(),
                        WebNotifyLink = c.String(),
                        enableWebMessage = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(),
                        NotificationCategory = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.PageLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParameterGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SLAEventType = c.Int(nullable: false),
                        TemplateParameterType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParticipantFeedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        FeedbackDescription = c.String(),
                        UserId = c.Int(),
                        EventId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.PasswordReset",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UID = c.String(),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsReset = c.Boolean(nullable: false),
                        ResetDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PromotionCode",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        MoneyValue = c.Int(nullable: false),
                        PercentageValue = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Used = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Publication",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Author = c.String(),
                        Coauthor = c.String(),
                        Title = c.String(),
                        Year = c.Int(),
                        Description = c.String(),
                        Language = c.String(),
                        ISBN = c.String(),
                        Hardcopy = c.Boolean(nullable: false),
                        Digitalcopy = c.Boolean(nullable: false),
                        HDcopy = c.Boolean(nullable: false),
                        FreeHCopy = c.Boolean(nullable: false),
                        FreeDCopy = c.Boolean(nullable: false),
                        FreeHDCopy = c.Boolean(nullable: false),
                        HPrice = c.Single(nullable: false),
                        DPrice = c.Single(nullable: false),
                        HDPrice = c.Single(nullable: false),
                        StockBalance = c.Int(),
                        CancelRemark = c.String(),
                        WithdrawalReason = c.String(),
                        WithdrawalDate = c.DateTime(),
                        DateAdded = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        RefNo = c.String(),
                        Status = c.Int(nullable: false),
                        DateCancelled = c.DateTime(),
                        ViewCount = c.Int(nullable: false),
                        PurchaseCount = c.Int(nullable: false),
                        DownloadCount = c.Int(nullable: false),
                        DmsPath = c.String(),
                        NotificationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PublicationCategory", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.PublicationApproval",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublicationID = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        ApproverId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        RequireNext = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publication", t => t.PublicationID)
                .Index(t => t.PublicationID);
            
            CreateTable(
                "dbo.PublicationCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicationWithdrawal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublicationID = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        ApproverId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        RequireNext = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publication", t => t.PublicationID)
                .Index(t => t.PublicationID);
            
            CreateTable(
                "dbo.PublicationDelivery",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Postcode = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicationDownloads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublicationID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicationFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileCategory = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FileDocument", t => t.FileId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.PublicationImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublicationID = c.Int(nullable: false),
                        CoverPicture = c.String(),
                        AuthorPicture = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicationPurchaseItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseOrderId = c.Int(),
                        PublicationID = c.Int(nullable: false),
                        Format = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicationRank",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublicationID = c.Int(nullable: false),
                        Position = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publication", t => t.PublicationID)
                .Index(t => t.PublicationID);
            
            CreateTable(
                "dbo.PublicationReview",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublicationID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        ReviewerId = c.Int(),
                        ReviewerName = c.String(),
                        ReviewDate = c.DateTime(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publication", t => t.PublicationID)
                .Index(t => t.PublicationID);
            
            CreateTable(
                "dbo.PublicationSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HardcopyReturnPeriod = c.Int(nullable: false),
                        MinimumPublishedYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicEventApproval",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovedDate = c.DateTime(),
                        Remark = c.String(),
                        ApprovalLevel = c.Int(nullable: false),
                        RequireNext = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        ApproverId = c.Int(),
                        EventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PublicEvent", t => t.EventId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DiscountCode = c.String(),
                        ProformaInvoiceNo = c.String(),
                        ReceiptNo = c.String(),
                        PaymentMode = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(),
                        TotalPrice = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        DeliveryStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        Description = c.String(),
                        PurchaseType = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .Index(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.Refund",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        PurchaseType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FullName = c.String(),
                        BankID = c.Int(nullable: false),
                        BankAccountNo = c.String(),
                        ReferenceNo = c.String(),
                        ReturnStatus = c.Int(nullable: false),
                        RefundStatus = c.Int(nullable: false),
                        Remarks = c.String(),
                        RefundReferenceNo = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BankInformation", t => t.BankID)
                .ForeignKey("dbo.PurchaseOrderItems", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.BankID);
            
            CreateTable(
                "dbo.RewardActivityPoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CourseId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.RewardRedemption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RewardCode = c.String(),
                        Description = c.String(),
                        DiscountValue = c.Int(nullable: false),
                        PointsToRedeem = c.Int(nullable: false),
                        ValidDuration = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.RoleDefault",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        DefaultRoleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ShareLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SLAReminder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SLAEventType = c.Int(nullable: false),
                        NotificationType = c.Int(nullable: false),
                        ETCode = c.String(),
                        SLAResolutionTime = c.Int(nullable: false),
                        IntervalDuration = c.Int(nullable: false),
                        SLADurationType = c.Int(),
                        NotificationCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SLAReminderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationType = c.Int(nullable: false),
                        NotificationReminderStatusType = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        closeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(),
                        Category = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        TargetGroup = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RequireLogin = c.Boolean(nullable: false),
                        Contents = c.String(),
                        TemplateName = c.String(),
                        TemplateDescription = c.String(),
                        Active = c.Boolean(nullable: false),
                        CancelRemark = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        RefNo = c.String(),
                        Status = c.Int(nullable: false),
                        DateCancelled = c.DateTime(),
                        InviteCount = c.Int(nullable: false),
                        SubmitCount = c.Int(nullable: false),
                        DmsPath = c.String(),
                        NotificationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SurveyApproval",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SurveyID = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        ApproverId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        RequireNext = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Survey", t => t.SurveyID)
                .Index(t => t.SurveyID);
            
            CreateTable(
                "dbo.SurveyFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileCategory = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FileDocument", t => t.FileId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.SurveyImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SurveyID = c.Int(nullable: false),
                        CoverPicture = c.String(),
                        AuthorPicture = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SurveyResponse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SurveyID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Email = c.String(),
                        ResponseDate = c.DateTime(nullable: false),
                        Contents = c.String(),
                        Answers = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Survey", t => t.SurveyID)
                .Index(t => t.SurveyID);
            
            CreateTable(
                "dbo.SystemSetting",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SystemTitle = c.String(),
                        ShortTitle = c.String(),
                        SystemFooter = c.String(),
                        SystemVersion = c.String(),
                        EmailFooter = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TabBulkEmail",
                c => new
                    {
                        DatID = c.Int(nullable: false, identity: true),
                        DatType = c.Int(nullable: false),
                        DatNotify = c.Int(nullable: false),
                        DTInsert = c.DateTime(),
                        DTSchedule = c.DateTime(),
                        DTExpired = c.DateTime(),
                        EmailTo = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        AttachmentState = c.Boolean(nullable: false),
                        Attachment_01 = c.String(),
                        Attachment_02 = c.String(),
                        Attachment_03 = c.String(),
                    })
                .PrimaryKey(t => t.DatID);
            
            CreateTable(
                "dbo.TabBulkSMS",
                c => new
                    {
                        DatID = c.Int(nullable: false, identity: true),
                        DatType = c.Int(nullable: false),
                        DatNotify = c.Int(nullable: false),
                        DTInsert = c.DateTime(),
                        DTSchedule = c.DateTime(),
                        DTExpired = c.DateTime(),
                        SMSTo = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.DatID);
            
            CreateTable(
                "dbo.TargetedGroupCities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StateID = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TargetedGroupMembers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TargetedGroupID = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Source = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TargetedGroups", t => t.TargetedGroupID)
                .Index(t => t.TargetedGroupID);
            
            CreateTable(
                "dbo.TargetedGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MinAge = c.Int(),
                        MaxAge = c.Int(),
                        Gender = c.Int(),
                        MinSalary = c.Int(),
                        MaxSalary = c.Int(),
                        DMPStatus = c.Int(),
                        Delinquent = c.Int(),
                        EmploymentType = c.Int(),
                        State = c.Int(),
                        CityCode = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TemplateParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationType = c.Int(nullable: false),
                        TemplateParameterType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TOTReport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Module = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Venue = c.String(),
                        NoOfParticipant = c.Int(nullable: false),
                        AgeR1NoOfMale = c.Int(nullable: false),
                        AgeR1NoOfFemale = c.Int(nullable: false),
                        AgeR2NoOfMale = c.Int(nullable: false),
                        AgeR2NoOfFemale = c.Int(nullable: false),
                        AgeR3NoOfMale = c.Int(nullable: false),
                        AgeR3NoOfFemale = c.Int(nullable: false),
                        AgeR4NoOfMale = c.Int(nullable: false),
                        AgeR4NoOfFemale = c.Int(nullable: false),
                        AgeR5NoOfMale = c.Int(nullable: false),
                        AgeR5NoOfFemale = c.Int(nullable: false),
                        SalaryR1NoOfMale = c.Int(nullable: false),
                        SalaryR1NoOfFemale = c.Int(nullable: false),
                        SalaryR2NoOfMale = c.Int(nullable: false),
                        SalaryR2NoOfFemale = c.Int(nullable: false),
                        SalaryR3NoOfMale = c.Int(nullable: false),
                        SalaryR3NoOfFemale = c.Int(nullable: false),
                        SalaryR4NoOfMale = c.Int(nullable: false),
                        SalaryR4NoOfFemale = c.Int(nullable: false),
                        SalaryR5NoOfMale = c.Int(nullable: false),
                        SalaryR5NoOfFemale = c.Int(nullable: false),
                        SalaryR6NoOfMale = c.Int(nullable: false),
                        SalaryR6NoOfFemale = c.Int(nullable: false),
                        Organization = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.TOTReportFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TOTReportId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileDocument", t => t.FileId)
                .ForeignKey("dbo.TOTReport", t => t.TOTReportId)
                .Index(t => t.TOTReportId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.UserLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Module = c.Int(nullable: false),
                        UserId = c.Int(),
                        IPAddress = c.String(),
                        GeoLocation = c.String(),
                        LogDate = c.DateTime(nullable: false),
                        Activity = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRewardPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        PointsReceived = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RewardType = c.Int(nullable: false),
                        AwardReason = c.String(),
                        RewardedBy = c.Int(),
                        DateReceived = c.DateTime(nullable: false),
                        Display = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.User", t => t.RewardedBy)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId)
                .Index(t => t.RewardedBy);
            
            CreateTable(
                "dbo.UserRewardRedemption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RewardRedemptionId = c.Int(nullable: false),
                        RedeemDate = c.DateTime(nullable: false),
                        RewardStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RewardRedemption", t => t.RewardRedemptionId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RewardRedemptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRewardRedemption", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRewardRedemption", "RewardRedemptionId", "dbo.RewardRedemption");
            DropForeignKey("dbo.UserRewardPoints", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRewardPoints", "RewardedBy", "dbo.User");
            DropForeignKey("dbo.UserRewardPoints", "CourseId", "dbo.Course");
            DropForeignKey("dbo.UserLog", "UserId", "dbo.User");
            DropForeignKey("dbo.TOTReportFile", "TOTReportId", "dbo.TOTReport");
            DropForeignKey("dbo.TOTReportFile", "FileId", "dbo.FileDocument");
            DropForeignKey("dbo.TOTReport", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.TargetedGroupMembers", "TargetedGroupID", "dbo.TargetedGroups");
            DropForeignKey("dbo.SurveyResponse", "SurveyID", "dbo.Survey");
            DropForeignKey("dbo.SurveyFile", "FileId", "dbo.FileDocument");
            DropForeignKey("dbo.SurveyApproval", "SurveyID", "dbo.Survey");
            DropForeignKey("dbo.RoleDefault", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RewardRedemption", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.RewardActivityPoint", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.RewardActivityPoint", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Refund", "ItemId", "dbo.PurchaseOrderItems");
            DropForeignKey("dbo.Refund", "BankID", "dbo.BankInformation");
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PublicEventApproval", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.PublicationReview", "PublicationID", "dbo.Publication");
            DropForeignKey("dbo.PublicationRank", "PublicationID", "dbo.Publication");
            DropForeignKey("dbo.PublicationFile", "FileId", "dbo.FileDocument");
            DropForeignKey("dbo.PublicationWithdrawal", "PublicationID", "dbo.Publication");
            DropForeignKey("dbo.Publication", "CategoryID", "dbo.PublicationCategory");
            DropForeignKey("dbo.PublicationApproval", "PublicationID", "dbo.Publication");
            DropForeignKey("dbo.PasswordReset", "UserId", "dbo.User");
            DropForeignKey("dbo.ParticipantFeedback", "UserId", "dbo.User");
            DropForeignKey("dbo.ParticipantFeedback", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.ParticipantFeedback", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.NotificationTemplate", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.Notification", "UserId", "dbo.User");
            DropForeignKey("dbo.ManuscriptSubmission", "UserId", "dbo.User");
            DropForeignKey("dbo.ManuscriptSubmission", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.ManuscriptSubmission", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.KMCUser", "UserId", "dbo.User");
            DropForeignKey("dbo.KMCUser", "KMCId", "dbo.KMCs");
            DropForeignKey("dbo.KMCs", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.KMCs", "FileId", "dbo.FileDocument");
            DropForeignKey("dbo.KMCs", "KMCCategoryId", "dbo.KMCCategory");
            DropForeignKey("dbo.InvitationEvent", "UserId", "dbo.User");
            DropForeignKey("dbo.InvitationEvent", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.InvitationEvent", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.FeedbackResponse", "SurveyID", "dbo.FeedbackSurvey");
            DropForeignKey("dbo.ExhibitionNominee", "UserId", "dbo.User");
            DropForeignKey("dbo.ExhibitionNominee", "ExhibitionRoadshowId", "dbo.EventExhibitionRequest");
            DropForeignKey("dbo.EventRequestApproval", "EventRequestId", "dbo.EventRequest");
            DropForeignKey("dbo.EventRequest", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.EventMediaInterviewApproval", "MediaId", "dbo.EventMediaInterviewRequest");
            DropForeignKey("dbo.EventMediaInterviewRequest", "UserId", "dbo.User");
            DropForeignKey("dbo.EventMediaInterviewRequest", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.EventMediaInterviewRequest", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.EventFile", "FileId", "dbo.FileDocument");
            DropForeignKey("dbo.EventExhibitionRequestApproval", "ExhibitionId", "dbo.EventExhibitionRequest");
            DropForeignKey("dbo.EventCalendar", "EventBookingId", "dbo.EventBooking");
            DropForeignKey("dbo.EventCalendar", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.EventBooking", "UserId", "dbo.User");
            DropForeignKey("dbo.EventBooking", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.EventBooking", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.EventAttendance", "UserId", "dbo.User");
            DropForeignKey("dbo.EventAttendance", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.EventAttendance", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.ErrorLog", "UserId", "dbo.User");
            DropForeignKey("dbo.EmailToSendAddress", "EmailToSendId", "dbo.EmailToSend");
            DropForeignKey("dbo.DutyRosterOfficer", "UserId", "dbo.User");
            DropForeignKey("dbo.DutyRosterOfficer", "DutyRosterId", "dbo.DutyRoster");
            DropForeignKey("dbo.DutyRoster", "ExhibitionRoadshowId", "dbo.EventExhibitionRequest");
            DropForeignKey("dbo.EventExhibitionRequest", "ReceivedById", "dbo.User");
            DropForeignKey("dbo.EventExhibitionRequest", "NomineeId", "dbo.User");
            DropForeignKey("dbo.EventExhibitionRequest", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.EventExhibitionRequest", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.DiscussionAttachment", "PostId", "dbo.DiscussionPosts");
            DropForeignKey("dbo.DiscussionPosts", "UserId", "dbo.User");
            DropForeignKey("dbo.DiscussionPosts", "ParentId", "dbo.DiscussionPosts");
            DropForeignKey("dbo.DiscussionPosts", "DiscussionId", "dbo.Discussions");
            DropForeignKey("dbo.Discussions", "ModuleId", "dbo.CourseModules");
            DropForeignKey("dbo.Discussions", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Discussions", "CourseId", "dbo.Course");
            DropForeignKey("dbo.DiscussionAttachment", "AttachmentId", "dbo.FileDocument");
            DropForeignKey("dbo.CourseProgresses", "LearnerId", "dbo.Learners");
            DropForeignKey("dbo.Enrollments", "LearnerId", "dbo.Learners");
            DropForeignKey("dbo.Enrollments", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.EnrollmentHistories", "EnrollmentId", "dbo.Enrollments");
            DropForeignKey("dbo.CourseProgresses", "EnrollmentId", "dbo.Enrollments");
            DropForeignKey("dbo.Enrollments", "CourseEventId", "dbo.CourseEvents");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Course");
            DropForeignKey("dbo.CourseInvitations", "CourseEventId", "dbo.CourseEvents");
            DropForeignKey("dbo.CourseInvitations", "CourseId", "dbo.Course");
            DropForeignKey("dbo.CourseEvents", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Trainers", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Trainers", "UserId", "dbo.User");
            DropForeignKey("dbo.TrainerGroups", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.TrainerGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupMembers", "LearnerId", "dbo.Learners");
            DropForeignKey("dbo.Learners", "UserId", "dbo.User");
            DropForeignKey("dbo.GroupMembers", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.TrainerCourses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.TrainerCourses", "CourseId", "dbo.Course");
            DropForeignKey("dbo.CourseModules", "CourseId", "dbo.Course");
            DropForeignKey("dbo.CourseContents", "CourseModuleId", "dbo.CourseModules");
            DropForeignKey("dbo.Course", "IntroMaterialId", "dbo.FileDocument");
            DropForeignKey("dbo.GamificationCriterias", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Course", "CourseCertificateId", "dbo.CourseCertificates");
            DropForeignKey("dbo.CourseEvents", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "CourseCertificateTemplateId", "dbo.CourseCertificateTemplates");
            DropForeignKey("dbo.CourseApprovalLogs", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "CategoryId", "dbo.RefCourseCategories");
            DropForeignKey("dbo.CourseContents", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.CourseContents", "ContentFileId", "dbo.ContentFiles");
            DropForeignKey("dbo.CourseCertificates", "FileUploadId", "dbo.FileUpload");
            DropForeignKey("dbo.FileUpload", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.CourseApprovalLogs", "ApproverId", "dbo.User");
            DropForeignKey("dbo.ContentQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.OrderAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.MultipleChoiceAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.FreeTextAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ContentFiles", "FileDocumentId", "dbo.FileDocument");
            DropForeignKey("dbo.CarouselFile", "FileId", "dbo.FileDocument");
            DropForeignKey("dbo.FileDocument", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.Carousel", "LastModifiedBy", "dbo.User");
            DropForeignKey("dbo.Carousel", "DeletedBy", "dbo.User");
            DropForeignKey("dbo.Carousel", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.AssignedSpeaker", "PublicEventId", "dbo.PublicEvent");
            DropForeignKey("dbo.AssignedSpeaker", "EventSpeakerId", "dbo.EventSpeaker");
            DropForeignKey("dbo.EventSpeaker", "UserId", "dbo.User");
            DropForeignKey("dbo.EventSpeaker", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.AssignedExternalExhibitor", "PublicEventId", "dbo.PublicEvent");
            DropForeignKey("dbo.AssignedExternalExhibitor", "ExternalExhibitorId", "dbo.EventExternalExhibitor");
            DropForeignKey("dbo.EventExternalExhibitor", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.AssessmentResponse", "SurveyID", "dbo.AssessmentSurvey");
            DropForeignKey("dbo.AgendaScript", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.PublicEvent", "EventCategoryId", "dbo.EventCategory");
            DropForeignKey("dbo.EventAgenda", "PersonInChargeId", "dbo.User");
            DropForeignKey("dbo.EventAgenda", "EventId", "dbo.PublicEvent");
            DropForeignKey("dbo.EventAgenda", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.PublicEvent", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.ActivateAccount", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.UserAccount");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserAccount", "UserId", "dbo.User");
            DropForeignKey("dbo.StaffProfile", "UserId", "dbo.User");
            DropForeignKey("dbo.StaffProfile", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.StaffProfile", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.StaffProfile", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Branch", "StateId", "dbo.State");
            DropForeignKey("dbo.IndividualProfile", "UserId", "dbo.User");
            DropForeignKey("dbo.IndividualProfile", "StateId", "dbo.State");
            DropForeignKey("dbo.IndividualProfile", "CountryId", "dbo.Country");
            DropForeignKey("dbo.IndividualProfile", "CitizenshipId", "dbo.Country");
            DropForeignKey("dbo.CompanyProfile", "UserId", "dbo.User");
            DropForeignKey("dbo.CompanyProfile", "StateId", "dbo.State");
            DropForeignKey("dbo.CompanyProfile", "SectorId", "dbo.Sector");
            DropForeignKey("dbo.CompanyProfile", "MinistryId", "dbo.Ministry");
            DropForeignKey("dbo.CompanyProfile", "CountryId", "dbo.Country");
            DropForeignKey("dbo.RoleAccess", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleAccess", "UserAccess", "dbo.Access");
            DropIndex("dbo.UserRewardRedemption", new[] { "RewardRedemptionId" });
            DropIndex("dbo.UserRewardRedemption", new[] { "UserId" });
            DropIndex("dbo.UserRewardPoints", new[] { "RewardedBy" });
            DropIndex("dbo.UserRewardPoints", new[] { "UserId" });
            DropIndex("dbo.UserRewardPoints", new[] { "CourseId" });
            DropIndex("dbo.UserLog", new[] { "UserId" });
            DropIndex("dbo.TOTReportFile", new[] { "FileId" });
            DropIndex("dbo.TOTReportFile", new[] { "TOTReportId" });
            DropIndex("dbo.TOTReport", new[] { "CreatedBy" });
            DropIndex("dbo.TargetedGroupMembers", new[] { "TargetedGroupID" });
            DropIndex("dbo.SurveyResponse", new[] { "SurveyID" });
            DropIndex("dbo.SurveyFile", new[] { "FileId" });
            DropIndex("dbo.SurveyApproval", new[] { "SurveyID" });
            DropIndex("dbo.RoleDefault", new[] { "RoleId" });
            DropIndex("dbo.RewardRedemption", new[] { "CreatedBy" });
            DropIndex("dbo.RewardActivityPoint", new[] { "CreatedBy" });
            DropIndex("dbo.RewardActivityPoint", new[] { "CourseId" });
            DropIndex("dbo.Refund", new[] { "BankID" });
            DropIndex("dbo.Refund", new[] { "ItemId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PublicEventApproval", new[] { "EventId" });
            DropIndex("dbo.PublicationReview", new[] { "PublicationID" });
            DropIndex("dbo.PublicationRank", new[] { "PublicationID" });
            DropIndex("dbo.PublicationFile", new[] { "FileId" });
            DropIndex("dbo.PublicationWithdrawal", new[] { "PublicationID" });
            DropIndex("dbo.PublicationApproval", new[] { "PublicationID" });
            DropIndex("dbo.Publication", new[] { "CategoryID" });
            DropIndex("dbo.PasswordReset", new[] { "UserId" });
            DropIndex("dbo.ParticipantFeedback", new[] { "CreatedBy" });
            DropIndex("dbo.ParticipantFeedback", new[] { "EventId" });
            DropIndex("dbo.ParticipantFeedback", new[] { "UserId" });
            DropIndex("dbo.NotificationTemplate", new[] { "CreatedBy" });
            DropIndex("dbo.Notification", new[] { "UserId" });
            DropIndex("dbo.ManuscriptSubmission", new[] { "CreatedBy" });
            DropIndex("dbo.ManuscriptSubmission", new[] { "EventId" });
            DropIndex("dbo.ManuscriptSubmission", new[] { "UserId" });
            DropIndex("dbo.KMCUser", new[] { "UserId" });
            DropIndex("dbo.KMCUser", new[] { "KMCId" });
            DropIndex("dbo.KMCs", new[] { "CreatedBy" });
            DropIndex("dbo.KMCs", new[] { "FileId" });
            DropIndex("dbo.KMCs", new[] { "KMCCategoryId" });
            DropIndex("dbo.InvitationEvent", new[] { "CreatedBy" });
            DropIndex("dbo.InvitationEvent", new[] { "EventId" });
            DropIndex("dbo.InvitationEvent", new[] { "UserId" });
            DropIndex("dbo.FeedbackResponse", new[] { "SurveyID" });
            DropIndex("dbo.ExhibitionNominee", new[] { "UserId" });
            DropIndex("dbo.ExhibitionNominee", new[] { "ExhibitionRoadshowId" });
            DropIndex("dbo.EventRequestApproval", new[] { "EventRequestId" });
            DropIndex("dbo.EventRequest", new[] { "EventId" });
            DropIndex("dbo.EventMediaInterviewRequest", new[] { "CreatedBy" });
            DropIndex("dbo.EventMediaInterviewRequest", new[] { "UserId" });
            DropIndex("dbo.EventMediaInterviewRequest", new[] { "BranchId" });
            DropIndex("dbo.EventMediaInterviewApproval", new[] { "MediaId" });
            DropIndex("dbo.EventFile", new[] { "FileId" });
            DropIndex("dbo.EventExhibitionRequestApproval", new[] { "ExhibitionId" });
            DropIndex("dbo.EventCalendar", new[] { "EventId" });
            DropIndex("dbo.EventCalendar", new[] { "EventBookingId" });
            DropIndex("dbo.EventBooking", new[] { "CreatedBy" });
            DropIndex("dbo.EventBooking", new[] { "EventId" });
            DropIndex("dbo.EventBooking", new[] { "UserId" });
            DropIndex("dbo.EventAttendance", new[] { "CreatedBy" });
            DropIndex("dbo.EventAttendance", new[] { "EventId" });
            DropIndex("dbo.EventAttendance", new[] { "UserId" });
            DropIndex("dbo.ErrorLog", new[] { "UserId" });
            DropIndex("dbo.EmailToSendAddress", new[] { "EmailToSendId" });
            DropIndex("dbo.DutyRosterOfficer", new[] { "UserId" });
            DropIndex("dbo.DutyRosterOfficer", new[] { "DutyRosterId" });
            DropIndex("dbo.EventExhibitionRequest", new[] { "CreatedBy" });
            DropIndex("dbo.EventExhibitionRequest", new[] { "ReceivedById" });
            DropIndex("dbo.EventExhibitionRequest", new[] { "NomineeId" });
            DropIndex("dbo.EventExhibitionRequest", new[] { "BranchId" });
            DropIndex("dbo.DutyRoster", new[] { "ExhibitionRoadshowId" });
            DropIndex("dbo.Discussions", new[] { "GroupId" });
            DropIndex("dbo.Discussions", new[] { "ModuleId" });
            DropIndex("dbo.Discussions", new[] { "CourseId" });
            DropIndex("dbo.DiscussionPosts", new[] { "UserId" });
            DropIndex("dbo.DiscussionPosts", new[] { "ParentId" });
            DropIndex("dbo.DiscussionPosts", new[] { "DiscussionId" });
            DropIndex("dbo.DiscussionAttachment", new[] { "AttachmentId" });
            DropIndex("dbo.DiscussionAttachment", new[] { "PostId" });
            DropIndex("dbo.EnrollmentHistories", new[] { "EnrollmentId" });
            DropIndex("dbo.Enrollments", new[] { "GroupId" });
            DropIndex("dbo.Enrollments", new[] { "LearnerId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "CourseEventId" });
            DropIndex("dbo.CourseProgresses", new[] { "LearnerId" });
            DropIndex("dbo.CourseProgresses", new[] { "EnrollmentId" });
            DropIndex("dbo.CourseInvitations", new[] { "CourseId" });
            DropIndex("dbo.CourseInvitations", new[] { "CourseEventId" });
            DropIndex("dbo.Learners", new[] { "UserId" });
            DropIndex("dbo.GroupMembers", new[] { "LearnerId" });
            DropIndex("dbo.GroupMembers", new[] { "GroupId" });
            DropIndex("dbo.TrainerGroups", new[] { "GroupId" });
            DropIndex("dbo.TrainerGroups", new[] { "TrainerId" });
            DropIndex("dbo.TrainerCourses", new[] { "CourseId" });
            DropIndex("dbo.TrainerCourses", new[] { "TrainerId" });
            DropIndex("dbo.Trainers", new[] { "Course_Id" });
            DropIndex("dbo.Trainers", new[] { "UserId" });
            DropIndex("dbo.CourseModules", new[] { "CourseId" });
            DropIndex("dbo.GamificationCriterias", new[] { "Course_Id" });
            DropIndex("dbo.Course", new[] { "CourseCertificateTemplateId" });
            DropIndex("dbo.Course", new[] { "CourseCertificateId" });
            DropIndex("dbo.Course", new[] { "IntroMaterialId" });
            DropIndex("dbo.Course", new[] { "Code" });
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropIndex("dbo.CourseEvents", new[] { "GroupId" });
            DropIndex("dbo.CourseEvents", new[] { "CourseId" });
            DropIndex("dbo.CourseEvents", new[] { "EnrollmentCode" });
            DropIndex("dbo.CourseContents", new[] { "QuestionId" });
            DropIndex("dbo.CourseContents", new[] { "ContentFileId" });
            DropIndex("dbo.CourseContents", new[] { "CourseModuleId" });
            DropIndex("dbo.FileUpload", new[] { "CreatedBy" });
            DropIndex("dbo.CourseCertificates", new[] { "FileUploadId" });
            DropIndex("dbo.CourseApprovalLogs", new[] { "ApproverId" });
            DropIndex("dbo.CourseApprovalLogs", new[] { "CourseId" });
            DropIndex("dbo.OrderAnswers", new[] { "QuestionId" });
            DropIndex("dbo.MultipleChoiceAnswers", new[] { "QuestionId" });
            DropIndex("dbo.FreeTextAnswers", new[] { "QuestionId" });
            DropIndex("dbo.ContentQuestions", new[] { "QuestionId" });
            DropIndex("dbo.ContentFiles", new[] { "FileDocumentId" });
            DropIndex("dbo.FileDocument", new[] { "CreatedBy" });
            DropIndex("dbo.CarouselFile", new[] { "FileId" });
            DropIndex("dbo.Carousel", new[] { "LastModifiedBy" });
            DropIndex("dbo.Carousel", new[] { "CreatedBy" });
            DropIndex("dbo.Carousel", new[] { "DeletedBy" });
            DropIndex("dbo.Carousel", new[] { "Sequence" });
            DropIndex("dbo.EventSpeaker", new[] { "CreatedBy" });
            DropIndex("dbo.EventSpeaker", new[] { "UserId" });
            DropIndex("dbo.AssignedSpeaker", new[] { "EventSpeakerId" });
            DropIndex("dbo.AssignedSpeaker", new[] { "PublicEventId" });
            DropIndex("dbo.EventExternalExhibitor", new[] { "CreatedBy" });
            DropIndex("dbo.AssignedExternalExhibitor", new[] { "PublicEventId" });
            DropIndex("dbo.AssignedExternalExhibitor", new[] { "ExternalExhibitorId" });
            DropIndex("dbo.AssessmentResponse", new[] { "SurveyID" });
            DropIndex("dbo.EventAgenda", new[] { "CreatedBy" });
            DropIndex("dbo.EventAgenda", new[] { "PersonInChargeId" });
            DropIndex("dbo.EventAgenda", new[] { "EventId" });
            DropIndex("dbo.PublicEvent", new[] { "CreatedBy" });
            DropIndex("dbo.PublicEvent", new[] { "EventCategoryId" });
            DropIndex("dbo.AgendaScript", new[] { "EventId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserAccount", new[] { "UserId" });
            DropIndex("dbo.Branch", new[] { "StateId" });
            DropIndex("dbo.StaffProfile", new[] { "DesignationId" });
            DropIndex("dbo.StaffProfile", new[] { "BranchId" });
            DropIndex("dbo.StaffProfile", new[] { "DepartmentId" });
            DropIndex("dbo.StaffProfile", new[] { "UserId" });
            DropIndex("dbo.IndividualProfile", new[] { "CountryId" });
            DropIndex("dbo.IndividualProfile", new[] { "StateId" });
            DropIndex("dbo.IndividualProfile", new[] { "CitizenshipId" });
            DropIndex("dbo.IndividualProfile", new[] { "UserId" });
            DropIndex("dbo.CompanyProfile", new[] { "CountryId" });
            DropIndex("dbo.CompanyProfile", new[] { "StateId" });
            DropIndex("dbo.CompanyProfile", new[] { "MinistryId" });
            DropIndex("dbo.CompanyProfile", new[] { "SectorId" });
            DropIndex("dbo.CompanyProfile", new[] { "UserId" });
            DropIndex("dbo.ActivateAccount", new[] { "UserId" });
            DropIndex("dbo.RoleAccess", new[] { "UserAccess" });
            DropIndex("dbo.RoleAccess", new[] { "RoleId" });
            DropTable("dbo.UserRewardRedemption");
            DropTable("dbo.UserRewardPoints");
            DropTable("dbo.UserLog");
            DropTable("dbo.TOTReportFile");
            DropTable("dbo.TOTReport");
            DropTable("dbo.TemplateParameters");
            DropTable("dbo.TargetedGroups");
            DropTable("dbo.TargetedGroupMembers");
            DropTable("dbo.TargetedGroupCities");
            DropTable("dbo.TabBulkSMS");
            DropTable("dbo.TabBulkEmail");
            DropTable("dbo.SystemSetting");
            DropTable("dbo.SurveyResponse");
            DropTable("dbo.SurveyImages");
            DropTable("dbo.SurveyFile");
            DropTable("dbo.SurveyApproval");
            DropTable("dbo.Survey");
            DropTable("dbo.SLAReminderStatus");
            DropTable("dbo.SLAReminder");
            DropTable("dbo.ShareLogs");
            DropTable("dbo.RoleDefault");
            DropTable("dbo.RewardRedemption");
            DropTable("dbo.RewardActivityPoint");
            DropTable("dbo.Refund");
            DropTable("dbo.PurchaseOrderItems");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PublicEventApproval");
            DropTable("dbo.PublicationSettings");
            DropTable("dbo.PublicationReview");
            DropTable("dbo.PublicationRank");
            DropTable("dbo.PublicationPurchaseItem");
            DropTable("dbo.PublicationImages");
            DropTable("dbo.PublicationFile");
            DropTable("dbo.PublicationDownloads");
            DropTable("dbo.PublicationDelivery");
            DropTable("dbo.PublicationWithdrawal");
            DropTable("dbo.PublicationCategory");
            DropTable("dbo.PublicationApproval");
            DropTable("dbo.Publication");
            DropTable("dbo.PromotionCode");
            DropTable("dbo.PasswordReset");
            DropTable("dbo.ParticipantFeedback");
            DropTable("dbo.ParameterGroup");
            DropTable("dbo.PageLogs");
            DropTable("dbo.NotificationTemplate");
            DropTable("dbo.Notification");
            DropTable("dbo.Months");
            DropTable("dbo.ManuscriptSubmission");
            DropTable("dbo.KMCUser");
            DropTable("dbo.KMCs");
            DropTable("dbo.KMCCategory");
            DropTable("dbo.InvitationEvent");
            DropTable("dbo.FeedbackSurvey");
            DropTable("dbo.FeedbackResponse");
            DropTable("dbo.ExhibitionNominee");
            DropTable("dbo.EventRequestApproval");
            DropTable("dbo.EventRequest");
            DropTable("dbo.EventMediaInterviewRequest");
            DropTable("dbo.EventMediaInterviewApproval");
            DropTable("dbo.EventFile");
            DropTable("dbo.EventExhibitionRequestApproval");
            DropTable("dbo.EventCalendar");
            DropTable("dbo.EventBooking");
            DropTable("dbo.EventAttendance");
            DropTable("dbo.ErrorLog");
            DropTable("dbo.EmailToSendAddress");
            DropTable("dbo.EmailToSend");
            DropTable("dbo.DutyRosterOfficer");
            DropTable("dbo.EventExhibitionRequest");
            DropTable("dbo.DutyRoster");
            DropTable("dbo.Discussions");
            DropTable("dbo.DiscussionPosts");
            DropTable("dbo.DiscussionAttachment");
            DropTable("dbo.EnrollmentHistories");
            DropTable("dbo.Enrollments");
            DropTable("dbo.CourseProgresses");
            DropTable("dbo.CourseInvitations");
            DropTable("dbo.Learners");
            DropTable("dbo.GroupMembers");
            DropTable("dbo.Groups");
            DropTable("dbo.TrainerGroups");
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.Trainers");
            DropTable("dbo.CourseModules");
            DropTable("dbo.GamificationCriterias");
            DropTable("dbo.RefCourseCategories");
            DropTable("dbo.Course");
            DropTable("dbo.CourseEvents");
            DropTable("dbo.CourseContents");
            DropTable("dbo.CourseCertificateTemplates");
            DropTable("dbo.FileUpload");
            DropTable("dbo.CourseCertificates");
            DropTable("dbo.CourseApprovalLogs");
            DropTable("dbo.OrderAnswers");
            DropTable("dbo.MultipleChoiceAnswers");
            DropTable("dbo.FreeTextAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.ContentQuestions");
            DropTable("dbo.ContentFiles");
            DropTable("dbo.Client");
            DropTable("dbo.CarouselImages");
            DropTable("dbo.FileDocument");
            DropTable("dbo.CarouselFile");
            DropTable("dbo.Carousel");
            DropTable("dbo.BulkNotification");
            DropTable("dbo.BankInformation");
            DropTable("dbo.EventSpeaker");
            DropTable("dbo.AssignedSpeaker");
            DropTable("dbo.EventExternalExhibitor");
            DropTable("dbo.AssignedExternalExhibitor");
            DropTable("dbo.AssessmentSurvey");
            DropTable("dbo.AssessmentResponse");
            DropTable("dbo.EventCategory");
            DropTable("dbo.EventAgenda");
            DropTable("dbo.PublicEvent");
            DropTable("dbo.AgendaScript");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserAccount");
            DropTable("dbo.Designation");
            DropTable("dbo.Department");
            DropTable("dbo.Branch");
            DropTable("dbo.StaffProfile");
            DropTable("dbo.IndividualProfile");
            DropTable("dbo.State");
            DropTable("dbo.Sector");
            DropTable("dbo.Ministry");
            DropTable("dbo.Country");
            DropTable("dbo.CompanyProfile");
            DropTable("dbo.User");
            DropTable("dbo.ActivateAccount");
            DropTable("dbo.AccountSetting");
            DropTable("dbo.Role");
            DropTable("dbo.RoleAccess");
            DropTable("dbo.Access");
        }
    }
}
