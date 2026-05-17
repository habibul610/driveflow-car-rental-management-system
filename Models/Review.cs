using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int CarID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        
        // For joining data display
        public string UserName { get; set; }
        public string CarName { get; set; }
    }
}
