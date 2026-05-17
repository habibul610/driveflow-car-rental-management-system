using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public abstract class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        // Demonstrating Encapsulation (Access modifiers & Properties)
        private string _email;
        public string Email 
        { 
            get { return _email; } 
            set 
            { 
                if (!string.IsNullOrEmpty(value) && value.Contains("@"))
                    _email = value;
                else
                    _email = "invalid@domain.com";
            } 
        }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        // Demonstrating Constructors
        public User() { }

        public User(string username)
        {
            Username = username;
        }


        public abstract string GetRole();
        
        public virtual string GetDashboardTitle()
        {
            return "User Dashboard";
        }
    }
}
