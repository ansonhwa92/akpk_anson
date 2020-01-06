﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEP.Model
{
    [Table("NewsArticle")]
    public class NewsArticle
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), StringLength(50), Required(ErrorMessage = "This field is required"), Display(Name = "Title *")]
        public string Title { get; set; }
        [MaxLength(250), StringLength(250)]
        public string Description { get; set; }
        public string NewsArticleImage { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? PublishedBy { get; set; }
        [DefaultValue(true)]
        public bool Display { get; set; }
        public DateTime? DisplayDate { get; set; }
        public string Source { get; set; }
        public string SourceLink { get; set; }
        [Index]
        public int Sequence { get; set; }
        [Column(TypeName = "ntext")]
        public string FreeTextArea { get; set; }
        public int NewsCategory { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string RefNo { get; set; }
        [ForeignKey("PublishedBy")]
        public virtual User PublishedByUser { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual User DeletedByUser { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }
        [ForeignKey("LastModifiedBy")]
        public virtual User LastModifiedByUser { get; set; }
    }

    [Table("NewsArticleFile")]
    public class NewsArticleFile
    {
        [Key]
        public int ID { get; set; }
        public int FileId { get; set; }
        public int ParentId { get; set; }
        [ForeignKey("FileId")]
        public virtual FileDocument FileDocument { get; set; }
    }

    [Table("NewsArticleImages")]
    public class NewsArticleImages
    {
        [Key]
        public int ID { get; set; }
        public int NewsArticleID { get; set; }
        public string CoverPicture { get; set; }
    }

    [Table("NewsArticleCategory")]
    public class NewsArticleCategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Display { get; set; }
    }
}