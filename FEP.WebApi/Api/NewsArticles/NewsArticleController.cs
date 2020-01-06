using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FEP.Helper;
using FEP.Model;
using FEP.WebApiModel.NewsArticle;
using FEP.WebApiModel.FileDocuments;


namespace FEP.WebApi.Api.NewsArticles
{

    [Route("api/NewsArticle/NewsArticle")]
    public class NewsArticleController : ApiController
    {
        private DbEntities db = new DbEntities();

        public IHttpActionResult Get()
        {
            var newsArticles = db.NewsArticle.Where(u => u.Display && !u.IsDeleted).OrderBy(x => x.Sequence).Select(s => new NewsArticleModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                PublishDate = s.PublishDate,
                Source = s.Source,
                SourceLink = s.SourceLink,
                FreeTextArea = s.FreeTextArea
            }).ToList();

            foreach (var d in newsArticles)
            {

                var crsimages = db.NewsArticleImages.Where(i => i.NewsArticleID == d.Id).Select(s => new NewsArticleImagesModel
                {
                    ID = s.ID,
                    CoverPicture = s.CoverPicture
                }).FirstOrDefault();


                if (crsimages != null)
                {
                    if ((crsimages.CoverPicture != null) && (crsimages.CoverPicture != ""))
                    {
                        d.NewsArticleImage = crsimages.CoverPicture.Substring(crsimages.CoverPicture.LastIndexOf('\\') + 1);
                    }
                }

            }
            return Ok(newsArticles);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var newsArticle = db.NewsArticle.Where(u => u.Id == id).Select(s => new CreateNewsArticleModel
            {
                Title = s.Title,
                Description = s.Description,
                Display = s.Display,
                DisplayDate = s.DisplayDate,
                Sequence = s.Sequence,
                PublishDate = s.PublishDate,
                Source = s.Source,
                SourceLink = s.SourceLink,
                FreeTextArea = s.FreeTextArea
            }).FirstOrDefault();

            if (newsArticle == null)
            {
                return NotFound();
            }

            newsArticle.CoverPictures = db.FileDocument.Where(f => f.Display).Join(db.NewsArticleFile.Where(p => p.ParentId == id), s => s.Id, c => c.FileId, (s, b) => new Attachment { Id = s.Id, FileName = s.FileName }).ToList();

            var crsimages = db.NewsArticleImages.Where(i => i.NewsArticleID == id).Select(s => new NewsArticleImagesModel
            {
                ID = s.ID,
                NewsArticleID = s.NewsArticleID,
                CoverPicture = s.CoverPicture
            }).FirstOrDefault();

            if (crsimages != null)
            {
                if ((crsimages.CoverPicture != null) && (crsimages.CoverPicture != ""))
                {
                    newsArticle.NewsArticleImage = crsimages.CoverPicture.Substring(crsimages.CoverPicture.LastIndexOf('\\') + 1);
                }
            }

            return Ok(newsArticle);
        }

        // Main DataTable function for listing and filtering
        // POST: api/NewsArticles/NewsArticle.GetAll (DataTable)
        [Route("api/NewsArticles/NewsArticle/GetAll")]
        [HttpPost]
        public IHttpActionResult Post(FilterNewsArticleModel request)
        {

            var query = db.NewsArticle.Where(p => !p.IsDeleted);   //TODO: all!!

            var totalCount = query.Count();

            //advance search
            //bool isconvertible = false;
            //int myType = 0;
            //isconvertible = int.TryParse(request.Type, out myType);

            /*
            query = query.Where(p => (request.Type == null || p.Category.Name.Contains(request.Type))
                && (request.Author == null || p.Author.Contains(request.Author))
                && (request.Title == null || p.Title.Contains(request.Title))
                && (request.ISBN == null || p.ISBN.Contains(request.ISBN))
                );
            */
            query = query.Where(p => (request.Title == null || p.Title.Contains(request.Title))
                && (request.Description == null || p.Description.Contains(request.Description))
                );

            //quick search 
            if (!string.IsNullOrEmpty(request.search.value))
            {
                var value = request.search.value.Trim();
                query = query.Where(p => p.Title.Contains(value)
                || p.Description.Contains(value)
                );
            }

            var filteredCount = query.Count();

            //order
            if (request.order != null)
            {
                string sortBy = request.columns[request.order[0].column].data;
                bool sortAscending = request.order[0].dir.ToLower() == "asc";

                switch (sortBy)
                {
                    case "Title":

                        if (sortAscending)
                        {
                            query = query.OrderBy(o => o.Title);
                        }
                        else
                        {
                            query = query.OrderByDescending(o => o.Title);
                        }

                        break;

                    case "Description":

                        if (sortAscending)
                        {
                            query = query.OrderBy(o => o.Description);
                        }
                        else
                        {
                            query = query.OrderByDescending(o => o.Description);
                        }

                        break;

                    default:
                        query = query.OrderBy(o => o.Id).OrderBy(o => o.Title);
                        break;
                }

            }
            else
            {
                query = query.OrderBy(o => o.Id).OrderBy(o => o.Title);
            }

            var data = query.Skip(request.start).Take(request.length)
                .Select(s => new CreateNewsArticleModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Sequence = s.Sequence,
                    Source = s.Source,
                    SourceLink = s.SourceLink,
                    PublishDate = s.PublishDate
                }).ToList();

            foreach (var d in data)
            {

                var crsimages = db.NewsArticleImages.Where(i => i.NewsArticleID == d.Id).Select(s => new NewsArticleImagesModel
                {
                    ID = s.ID,
                    NewsArticleID = s.NewsArticleID,
                    CoverPicture = s.CoverPicture
                }).FirstOrDefault();


                if (crsimages != null)
                {
                    if ((crsimages.CoverPicture != null) && (crsimages.CoverPicture != ""))
                    {
                        d.NewsArticleImage = crsimages.CoverPicture.Substring(crsimages.CoverPicture.LastIndexOf('\\') + 1);
                    }
                }

            }
            return Ok(new DataTableResponse
            {
                draw = request.draw,
                recordsTotal = totalCount,
                recordsFiltered = filteredCount,
                data = data.ToArray()
            });

        }

        // Function to save a publication (as draft) after creating a new one.
        // POST: api/NewsArticles/NewsArticle/Create
        [Route("api/NewsArticles/NewsArticle/Create")]
        [HttpPost]
        //[ValidationActionFilter]
        public string Create([FromBody] CreateNewsArticleModelNoFile model)
        {

            if (ModelState.IsValid)
            {
                int seq = 0;
                if (model.Sequence == 0)
                {
                    var record = db.NewsArticle.FirstOrDefault(c => !c.IsDeleted);

                    if (record != null)
                    {
                        seq = db.NewsArticle.Where(c => !c.IsDeleted).Max(x => x.Sequence);
                    }
                }

                seq++;

                var newsArticle = new NewsArticle
                {
                    Title = model.Title,
                    Description = model.Description,
                    Sequence = seq,
                    Display = (model.Display) ? true : false,
                    DisplayDate = model.DisplayDate,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy,
                    Source = model.Source,
                    SourceLink = model.SourceLink,
                    FreeTextArea = model.FreeTextArea
                };

                db.NewsArticle.Add(newsArticle);
                db.SaveChanges();

                //files 1
                foreach (var fileid in model.CoverFilesId)
                {
                    var coverfile = new NewsArticleFile
                    {
                        FileId = fileid,
                        ParentId = newsArticle.Id
                    };

                    db.NewsArticleFile.Add(coverfile);
                }

                // modify newsArticle by adding ref no based on year, month and new ID (Survey= SVP & SVT)
                var refno = "CRS/" + DateTime.Now.ToString("yyMM");
                refno += "/" + newsArticle.Id.ToString("D4");
                newsArticle.RefNo = refno;

                db.Entry(newsArticle).State = EntityState.Modified;
                db.SaveChanges();

                return newsArticle.Id.ToString() + "|" + model.Title;
            }
            return "";
        }

        [Route("api/NewsArticles/NewsArticle/Edit")]
        [HttpPost]
        [ValidationActionFilter]
        public string Edit([FromBody] CreateNewsArticleModel model)
        {

            if (ModelState.IsValid)
            {
                var newsArticle = db.NewsArticle.Where(p => p.Id == model.Id).FirstOrDefault();

                if (newsArticle != null)
                {
                    newsArticle.Title = model.Title;
                    newsArticle.Description = model.Description;
                    newsArticle.Display = model.Display;
                    newsArticle.DisplayDate = model.DisplayDate;
                    newsArticle.FreeTextArea = model.FreeTextArea;
                    newsArticle.LastModifiedBy = model.LastModifiedBy;
                    newsArticle.LastModifiedDate = DateTime.Now;
                    newsArticle.Source = model.Source;
                    newsArticle.SourceLink = model.SourceLink;

                    db.Entry(newsArticle).State = EntityState.Modified;

                    //files 1

                    var attachments1 = db.NewsArticleFile.Where(s => s.ParentId == model.Id).ToList();

                    if (attachments1 != null)
                    {
                        if (model.CoverPictures == null)
                        {
                            foreach (var attachment in attachments1)
                            {
                                attachment.FileDocument.Display = false;
                                db.FileDocument.Attach(attachment.FileDocument);
                                db.Entry(attachment.FileDocument).Property(m => m.Display).IsModified = true;
                                db.NewsArticleFile.Remove(attachment);
                            }
                        }
                        else
                        {
                            foreach (var attachment in attachments1)
                            {
                                if (!model.CoverPictures.Any(u => u.Id == attachment.FileDocument.Id))
                                {
                                    attachment.FileDocument.Display = false;
                                    db.FileDocument.Attach(attachment.FileDocument);
                                    db.Entry(attachment.FileDocument).Property(m => m.Display).IsModified = true;
                                    db.NewsArticleFile.Remove(attachment);
                                }
                            }
                        }
                    }

                    foreach (var fileid in model.CoverFilesId)
                    {
                        var coverfile = new NewsArticleFile
                        {
                            FileId = fileid,
                            ParentId = newsArticle.Id
                        };

                        db.NewsArticleFile.Add(coverfile);
                    }

                    db.SaveChanges();

                    return model.Title;
                }
            }
            return "";
        }

        [Route("api/NewsArticles/NewsArticle/UpdateSequence")]
        [HttpPost]
        public string UpdateSequence([FromBody] NewsArticleModel model)
        {
            var newsArticle = db.NewsArticle.Where(p => p.Id == model.Id).FirstOrDefault();
            string ptitle = string.Empty;
            if (newsArticle != null)
            {
                int currentSeq = newsArticle.Sequence;

                ptitle = newsArticle.Title;

                var beforeCurrentNewsArticle = db.NewsArticle.Where(p => p.Sequence < currentSeq).FirstOrDefault();
                if (beforeCurrentNewsArticle == null)
                {
                    int newsArticleSeq = newsArticle.Sequence;

                    var newsArticleList = db.NewsArticle.Where(p => (p.Sequence > currentSeq && p.Sequence <= model.Sequence));

                    foreach (var cl in newsArticleList)
                    {
                        cl.Sequence = newsArticleSeq;
                        newsArticleSeq++;
                    }
                }
                else
                {
                    int newsArticleSeq = newsArticle.Sequence;

                    var newsArticleList = db.NewsArticle.Where(p => (p.Sequence >= model.Sequence && p.Sequence < currentSeq));

                    foreach (var cl in newsArticleList)
                    {
                        cl.Sequence = newsArticleSeq;
                        newsArticleSeq++;
                    }
                }

                newsArticle.Sequence = model.Sequence;

                db.Entry(newsArticle).State = EntityState.Modified;

                db.SaveChanges();

                return model.Id.ToString();
            }
            return "";
        }
        // GET: api/NewsArticles/NewsArticle/UploadImages
        [Route("api/NewsArticles/NewsArticle/UploadImages")]
        [HttpGet]
        public int UploadImages(int pubid, string coverpic)
        {
            var crsimages = new NewsArticleImages
            {
                NewsArticleID = pubid,
                CoverPicture = coverpic
            };

            db.NewsArticleImages.Add(crsimages);
            db.SaveChanges();

            return crsimages.ID;
        }

        // GET: api/NewsArticles/NewsArticle/UpdateImages
        [Route("api/NewsArticles/NewsArticle/UpdateImages")]
        [HttpGet]
        public int UpdateImages(int pubid, string coverpic)
        {
            var crsimages = db.NewsArticleImages.Where(pi => pi.NewsArticleID == pubid).FirstOrDefault();

            if (crsimages != null)
            {
                crsimages.CoverPicture = coverpic;
                db.Entry(crsimages).State = EntityState.Modified;
                db.SaveChanges();

                return crsimages.ID;
            }

            return 0;
        }

        // GET: api/NewsArticles/NewsArticle/UpdateImagePublicationID
        [Route("api/NewsArticles/NewsArticle/UpdateImageNewsArticleID")]
        [HttpGet]
        public int UpdateImageNewsArticleID(int id, int pubid)
        {
            var crsimages = db.NewsArticleImages.Where(pi => pi.ID == id).FirstOrDefault();

            if (crsimages != null)
            {
                crsimages.NewsArticleID = pubid;
                db.Entry(crsimages).State = EntityState.Modified;
                db.SaveChanges();

                return crsimages.ID;
            }

            return 0;
        }

        [ValidationActionFilter]
        public IHttpActionResult Post(NewsArticleModel model)
        {
            int seq = 0;
            var record = db.NewsArticle.Where(r => !r.IsDeleted).OrderByDescending(x => x.Sequence).FirstOrDefault();

            if (record != null)
                seq = record.Sequence;

            seq++;

            var newsArticle = new NewsArticle
            {
                NewsArticleImage = model.NewsArticleImage,
                Title = model.Title,
                Description = model.Description,
                DeletedBy = model.DeletedBy,
                DeletedDate = (model.DeletedBy != null) ? model.DeletedDate : null,
                Display = (model.Display) ? true : false,
                FreeTextArea = model.FreeTextArea,
                Sequence = seq,
                DisplayDate = (model.DisplayDate != null) ? model.DisplayDate : DateTime.Now,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy,
                LastModifiedBy = model.CreatedBy,
                Source = model.Source,
                SourceLink = model.SourceLink
            };

            db.NewsArticle.Add(newsArticle);

            db.SaveChanges();

            return Ok(newsArticle.Id);
        }

        [ValidationActionFilter]
        public IHttpActionResult Put(NewsArticleModel model)
        {
            var newsArticle = db.NewsArticle.Where(r => r.Id == model.Id && !r.IsDeleted).FirstOrDefault();

            if (newsArticle == null)
            {
                return NotFound();
            }

            newsArticle.Title = model.Title;
            newsArticle.Description = model.Description;
            newsArticle.FreeTextArea = model.FreeTextArea;

            db.Entry(newsArticle).State = EntityState.Modified;

            db.SaveChanges();

            return Ok(true);
        }

        [Route("api/NewsArticles/NewsArticle/Delete")]
        //[HttpPost]
        public string Delete(int id)
        {
            var newsArticle = db.NewsArticle.Where(r => r.Id == id && !r.IsDeleted).FirstOrDefault();

            if (newsArticle != null)
            {
                int newsArticleSeq = newsArticle.Sequence;
                string ptitle = newsArticle.Title;

                var newsArticleFiles = db.NewsArticleFile.Where(s => s.ParentId == newsArticle.Id);

                foreach (var cf in newsArticleFiles)
                {
                    db.NewsArticleFile.Remove(cf);
                }

                var newsArticleImages = db.NewsArticleImages.Where(s => s.NewsArticleID == newsArticle.Id);

                foreach (var ci in newsArticleImages)
                {
                    db.NewsArticleImages.Remove(ci);
                }

                var newsArticleList = db.NewsArticle.Where(p => p.Sequence > newsArticleSeq);

                foreach (var cl in newsArticleList)
                {
                    cl.Sequence = newsArticleSeq;
                    newsArticleSeq++;
                }

                // delete record
                db.NewsArticle.Remove(NewsArticle);
                db.SaveChanges();

                return ptitle;
            }

            return "";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsArticleExists(int id)
        {
            return db.NewsArticle.Count(e => e.Id == id) > 0;
        }
    }
}
