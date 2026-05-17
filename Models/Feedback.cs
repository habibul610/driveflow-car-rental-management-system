using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; } // For UI display
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
