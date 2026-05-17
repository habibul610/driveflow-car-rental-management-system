using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Customer : User
    {
        // Demonstrating Base class vs. Derived class constructors
        public Customer() : base() { }

        public Customer(string username) : base(username) { }

        public override string GetRole()
        {
            return "Customer";
        }

        public override string GetDashboardTitle()
        {
            return "Customer Dashboard";
        }
    }
}
