using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System.Collections.Generic;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class ReviewBLL
    {
        private ReviewDAL dal = new ReviewDAL();

        public bool CreateReview(Review review)
        {
            if (review.Rating < 1 || review.Rating > 5) throw new System.Exception("Rating must be between 1 and 5.");
            return dal.CreateReview(review);
        }

        public List<Review> GetAllReviews()
        {
            return dal.GetAllReviews();
        }

        public bool UpdateReview(int reviewId, int rating, string comment)
        {
            if (rating < 1 || rating > 5) throw new System.Exception("Rating must be between 1 and 5.");
            return dal.UpdateReview(reviewId, rating, comment);
        }

        public bool DeleteReview(int reviewId)
        {
            return dal.DeleteReview(reviewId);
        }
    }
}
