using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        public User AuthenticateUser(string username, string password)
        {
            User user = userDAL.GetUserByUsername(username);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    return user;
                }
            }
            return null;
        }

        public bool RegisterCustomer(string fullName, string username, string email, string phone, string password)
        {
            // Validate: non-empty, at least 3 characters, not purely numeric
            if (string.IsNullOrWhiteSpace(fullName) || fullName.Trim().Length < 3 || fullName.Trim().All(c => char.IsDigit(c)))
            {
                throw new Exception("Please enter a valid full name (minimum 3 characters).");
            }

            if (userDAL.UsernameExists(username))
            {
                throw new Exception("Username already exists.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            Customer newCustomer = new Customer
            {
                FullName = fullName,
                Username = username,
                Email = email,
                Phone = phone,
                PasswordHash = passwordHash,
                Role = "Customer"
            };

            return userDAL.InsertUser(newCustomer);
        }

        public bool RegisterManager(string fullName, string username, string email, string phone, string password)
        {
            if (userDAL.UsernameExists(username))
            {
                throw new Exception("Username already exists.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            Manager newManager = new Manager
            {
                FullName = fullName,
                Username = username,
                Email = email,
                Phone = phone,
                PasswordHash = passwordHash,
                Role = "Manager"
            };

            return userDAL.InsertUser(newManager);
        }

        public DataTable GetAllCustomers()
        {
            return userDAL.GetAllCustomers();
        }

        public bool DeleteUser(int userId)
        {
            BookingDAL bookingDAL = new BookingDAL();
            if (bookingDAL.HasActiveBooking(userId))
            {
                throw new Exception("Cannot delete user with active bookings.");
            }
            return userDAL.DeleteUser(userId);
        }

        public bool UpdateUserProfile(int userId, string fullName, string email, string phone, string newPassword = null)
        {
            string passwordHash = null;
            if (!string.IsNullOrEmpty(newPassword))
            {
                passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            return userDAL.UpdateUserProfile(userId, fullName, email, phone, passwordHash);
        }

        public bool UpdateProfile(User user)
        {
            return UpdateUserProfile(user.UserID, user.FullName, user.Email, user.Phone, null);
        }

        public bool ChangePassword(int userId, string currentPassword, string newPassword)
        {
            User user = userDAL.GetUserByID(userId);
            if (user != null && BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash))
            {
                string newHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                return userDAL.UpdateUserProfile(userId, user.FullName, user.Email, user.Phone, newHash);
            }
            return false;
        }
    }
}
