using System;
using System.Data;
using System.Linq;
using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class CarBLL
    {
        private CarDAL carDAL = new CarDAL();

        public bool InsertCar(Car car)
        {
            return carDAL.InsertCar(car);
        }

        public bool UpdateCar(Car car)
        {
            return carDAL.UpdateCar(car);
        }

        public bool DeleteCar(int carId)
        {
            if (carDAL.IsCarRented(carId))
            {
                throw new Exception("Cannot delete a car that is currently rented.");
            }
            return carDAL.DeleteCar(carId);
        }

        public DataTable GetAllCars()
        {
            return carDAL.GetAllCars();
        }

        public Car GetCarByID(int carId)
        {
            return carDAL.GetCarByID(carId);
        }

        public DataTable GetAvailableCars()
        {
            return carDAL.GetAvailableCars();
        }

        public async System.Threading.Tasks.Task<DataTable> GetAvailableCarsAsync()
        {
            return await carDAL.GetAvailableCarsAsync();
        }

        public void AssignRandomImages(string[] imageFiles)
        {
            DataTable cars = carDAL.GetAllCars();
            Random rand = new Random();

            foreach (DataRow row in cars.Rows)
            {
                int carId = Convert.ToInt32(row["CarID"]);
                string randomImg = imageFiles[rand.Next(imageFiles.Length)];
                carDAL.UpdateCarImagePath(carId, "images/" + randomImg);
            }
        }

    }
}
