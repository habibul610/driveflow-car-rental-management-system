using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    // Interface demonstrating Abstraction and Implementation
    public interface IVehicle
    {
        string GetVehicleDescription();
        bool IsAvailableForRent();
    }
}
