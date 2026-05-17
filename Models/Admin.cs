using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Admin : User
    {
        // Demonstrating Base class vs. Derived class constructors
        public Admin() : base() { }

        public Admin(string username) : base(username) { }

        public override string GetRole()
        {
            return "Admin";
        }

        public override string GetDashboardTitle()
        {
            return "Admin Dashboard";
        }
    }
}
