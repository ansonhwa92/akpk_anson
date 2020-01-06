using FEP.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEP.Model;
using FEP.WebApiModel.FileDocuments;
using System.Web;
using System.Web.Mvc;

namespace FEP.WebApiModel.NewsArticle
{
    public class NewsArticleModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "NewsArticle Image")]

        public string Source { get; set; }

        public string SourceLink { get; set; }
        public string NewsArticleImage { get; set; }
        public bool Display { get; set; }
        [Display(Name = "Display Start Date")]
        public DateTime? DisplayDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public string NewsCategory { get; set; }
        public int Sequence { get; set; }
        [AllowHtml]
        [Display(Name = "Free Text Area")]
        public string FreeTextArea { get; set; }
        [Display(Name = "Free Text Location")]
        public FreeTextLocation TextLocation { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }
    }

    public class NewsArticleImagesModel
    {
        public int ID { get; set; }
        public int NewsArticleID { get; set; }
        public string CoverPicture { get; set; }
    }
    // for creating
    public class CreateNewsArticleModel : NewsArticleModel
    {
        public CreateNewsArticleModel()
        {
            CoverPictures = new List<Attachment>();
            CoverPictureFiles = new List<HttpPostedFileBase>();
            CoverFilesId = new List<int>();
        }

        [Display(Name = "NewsArticle Pictures")]
        public IEnumerable<Attachment> CoverPictures { get; set; }
        public IEnumerable<HttpPostedFileBase> CoverPictureFiles { get; set; }

        public List<int> CoverFilesId { get; set; }
    }

    // for editing
    public class EditNewsArticleModel : NewsArticleModel
    {
        public EditNewsArticleModel()
        {
            CoverPictures = new List<Attachment>();
            CoverPictureFiles = new List<HttpPostedFileBase>();
            CoverFilesId = new List<int>();
        }

        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "NewsArticle Pictures")]
        public IEnumerable<Attachment> CoverPictures { get; set; }
        public IEnumerable<HttpPostedFileBase> CoverPictureFiles { get; set; }

        public List<int> CoverFilesId { get; set; }
    }

    public class NewsArticleModelNoFile
    {
        [Required(ErrorMessageResourceName = "ValidRequiredTitle", ErrorMessageResourceType = typeof(Language.NewsArticle))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "ValidRequiredDescription", ErrorMessageResourceType = typeof(Language.NewsArticle))]
        public string Description { get; set; }

        public string NewsArticleImage { get; set; }
        public bool Display { get; set; }
        public DateTime? DisplayDate { get; set; }
        public int Sequence { get; set; }
        public string FreeTextArea { get; set; }
        public FreeTextLocation TextLocation { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }
        public string Source { get; set; }
        public string SourceLink { get; set; }
    }

    // for details

    // class for updating of publication information by client app
    // used to create and edit publication information
    public class DetailsNewsArticleModel : NewsArticleModelNoFile
    {
        public DetailsNewsArticleModel() { }

        [Required]
        public int ID { get; set; }

        [Display(Name = "NewsArticle Pictures", ResourceType = typeof(Language.NewsArticle))]
        public IEnumerable<Attachment> CoverPictures { get; set; }

        [Display(Name = "NewsArticle Pictures", ResourceType = typeof(Language.NewsArticle))]
        public string CoverPicture { get; set; }
    }

    // for creating
    public class CreateNewsArticleModelNoFile : NewsArticleModelNoFile
    {
        public CreateNewsArticleModelNoFile()
        {
            CoverPictures = new List<Attachment>();
        }

        public IEnumerable<Attachment> CoverPictures { get; set; }

        public List<int> CoverFilesId { get; set; }
    }
    //for editing

    public class EditNewsArticleModelNoFile : NewsArticleModelNoFile
    {
        public EditNewsArticleModelNoFile()
        {
            CoverPictures = new List<Attachment>();
        }

        [Required]
        public int Id { get; set; }

        public IEnumerable<Attachment> CoverPictures { get; set; }

        public List<int> CoverFilesId { get; set; }
    }
    public class ListNewsArticleModel
    {
        public FilterNewsArticleModel Filter { get; set; }

        public NewsArticleModel List { get; set; }
    }

    // class for setting and returning filters for the datatable list of publications
    public class FilterNewsArticleModel : DataTableModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "NewsArticle Image")]
        public string NewsArticleImage { get; set; }
    }
}
