using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Services.Services
{
    public class ReviewService
    {
        private readonly Guid _userID;
        public ReviewService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
            {
                OwnerID = _userID ,
                CareproviderID = model.CareproviderID,
                Report = model.Report,
                Description = model.Description,
                Score = model.Score,
                IsRecommended = model.IsRecommended,
                IsReported = model.IsReported,
                CreatedUTC = DateTimeOffset.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }



        public IEnumerable<ReviewListItem> GetReview()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Reviews.Where(e => e.OwnerID == _userID).Select(e => new ReviewListItem
                {
                    ReviewID = e.ReviewID,
                    Report = e.Report,
                    Description = e.Description,
                    Score = e.Score,
                    IsRecommended = e.IsRecommended,
                    IsReported = e.IsReported,
                    ProviderName = e.Careprovider.ProviderName,
                    ChildrenEnrolled = e.Careprovider.ChildrenEnrolled.Count,  
                    CareproviderID = e.Careprovider.CareproviderID, 
                    CreatedUTC = e.CreatedUTC
                });

                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewID == iD && e.OwnerID == _userID);

                return new ReviewDetail
                {
                    CareproviderID = entity.CareproviderID,
                    ReviewID = entity.ReviewID,
                    Report = entity.Report,
                    Description = entity.Description,
                    Score = entity.Score,
                    IsRecommended = entity.IsRecommended,
                    IsReported = entity.IsReported,
                    CreatedUTC = entity.CreatedUTC,
                    Modified = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateReivew(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewID == model.ReviewID && e.OwnerID == _userID);

                entity.ReviewID = model.ReviewID;
                entity.Report = model.Report;
                entity.Description = model.Description;
                entity.Score = model.Score;
                entity.IsRecommended = model.IsRecommended;
                entity.IsReported = model.IsRecommended;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewID == reviewID && e.OwnerID == _userID);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
