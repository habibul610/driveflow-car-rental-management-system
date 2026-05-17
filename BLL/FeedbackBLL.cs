using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class FeedbackBLL
    {
        private FeedbackDAL feedbackDAL = new FeedbackDAL();

        public bool SubmitFeedback(int userId, int rating, string comments)
        {
            Feedback fb = new Feedback
            {
                UserID = userId,
                Rating = rating,
                Comments = comments
            };
            return feedbackDAL.InsertFeedback(fb);
        }

        public DataTable GetAllFeedback()
        {
            return feedbackDAL.GetAllFeedback();
        }

        public bool DeleteFeedback(int feedbackId)
        {
            return feedbackDAL.DeleteFeedback(feedbackId);
        }
    }
}
