namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Manager : User
    {
        public Manager()
        {
            Role = "Manager";
        }

        public override string GetRole()
        {
            return "Manager";
        }

        public override string GetDashboardTitle()
        {
            return "Manager Dashboard";
        }
    }
}
