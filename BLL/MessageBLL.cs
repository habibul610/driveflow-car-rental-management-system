using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class MessageBLL
    {
        private MessageDAL messageDAL = new MessageDAL();

        public bool SendMessage(int senderId, int receiverId, string subject, string body)
        {
            if (receiverId == 0)
                throw new Exception("Please select a receiver.");
            if (string.IsNullOrWhiteSpace(subject))
                throw new Exception("Subject cannot be empty.");
            if (string.IsNullOrWhiteSpace(body))
                throw new Exception("Message body cannot be empty.");

            CAR_RENTAL_MANAGEMENT_SYSTEM.Models.Message msg = new CAR_RENTAL_MANAGEMENT_SYSTEM.Models.Message
            {
                SenderID = senderId,
                ReceiverID = receiverId,
                Subject = subject,
                MessageBody = body
            };

            return messageDAL.SendMessage(msg);
        }

        public DataTable GetInbox(int userId)
        {
            return messageDAL.GetMessagesForUser(userId);
        }

        public bool MarkAsRead(int messageId)
        {
            return messageDAL.MarkAsRead(messageId);
        }

        public int GetUnreadMessageCount(int userId)
        {
            return messageDAL.GetUnreadCount(userId);
        }

        public DataTable GetAvailableReceivers()
        {
            return messageDAL.GetAllUsersForMessaging();
        }
    }
}
