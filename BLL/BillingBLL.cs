using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class BillingBLL
    {
        private BillingDAL billingDAL = new BillingDAL();

        public DataTable GetAllBillingRecords()
        {
            return billingDAL.GetAllBillingRecords();
        }

        public DataTable GetBillingRecordsByUserID(int userId)
        {
            return billingDAL.GetBillingRecordsByUserID(userId);
        }

        public bool UpdatePaymentStatus(int billId, string status)
        {
            return billingDAL.UpdatePaymentStatus(billId, status);
        }
    }
}
