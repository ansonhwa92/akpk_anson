//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Migrations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FEP.Model.Migrations
//{
//    public static class Carousel
//    {
//        public static void Seed(DbEntities db)
//        {
//            if (!db.CarouselImages.Any())
//            {
//                AddCarousel(db, new Model.Carousel
//                {
//                    Id = 1,
//                    Title = "Video raya AKPK ingatkan kita supaya bayar hutang",
//                    Description = "Video raya AKPK ingatkan kita supaya bayar hutang",
//                    PublishDate = DateTime.Parse("2019-09-07 23:59:59"),
//                    PublishedBy = 1,
//                    Display = true,
//                    DisplayDate = DateTime.Parse("2019-12-31 23:59:59"),
//                    CreatedBy = 1,
//                    CreatedDate = DateTime.Now,
//                    IsDeleted = false,
//                    Sequence = 1,
//                    NewsCategory = 2,
//                    RefNo = "NEWS/" + DateTime.Now.ToString("yyMM") + "/0001"
//                });
//            }
//            if (!db.NewsArticle.Any())
//            {
//                //News 1
//                AddCarousel(db, new Model.NewsArticle
//                {
//                    Id = 1,
//                    Title = "Video raya AKPK ingatkan kita supaya bayar hutang",
//                    Description = "Video raya AKPK ingatkan kita supaya bayar hutang",
//                    PublishDate = DateTime.Parse("2019-09-07 23:59:59"),
//                    PublishedBy = 1,
//                    Display = true,
//                    DisplayDate = DateTime.Parse("2019-12-31 23:59:59"),
//                    CreatedBy = 1,
//                    CreatedDate = DateTime.Now,
//                    IsDeleted = false,
//                    Sequence = 1,
//                    NewsCategory = 2,
//                    RefNo = "NEWS/" + DateTime.Now.ToString("yyMM") + "/0001"
//                });

//                //News 2
//                Carousel.AddNewsArticle(db, new Model.NewsArticle
//                {
//                    Id = 2,
//                    Title = "10 Ciri Yang Ada Pada Semua Rumah Idaman",
//                    Description = "10 Ciri Yang Ada Pada Semua Rumah Idaman",
//                    PublishDate = DateTime.Parse("2019-09-07 23:59:59"),
//                    PublishedBy = 1,
//                    Display = true,
//                    DisplayDate = DateTime.Parse("2019-12-31 23:59:59"),
//                    CreatedBy = 1,
//                    CreatedDate = DateTime.Now,
//                    IsDeleted = false,
//                    Sequence = 1,
//                    NewsCategory = 1,
//                    RefNo = "NEWS/" + DateTime.Now.ToString("yyMM") + "/0002"
//                });
//            }
//        }

//        public static void AddCarousel(DbEntities db, Model.CarouselImages CarouselImages)
//        {
//            var carouselImages = db.CarouselImages.Local.Where(r => r.Id == CarouselImages.Id).FirstOrDefault() ?? db.CarouselImages.Where(r => r.Id == NewsArticle.Id).FirstOrDefault();

//            if (carouselImages == null)
//            {
//                db.CarouselImages.Add(CarouselImages);
//            }
//        }
//    }
//}
