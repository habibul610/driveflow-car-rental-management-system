using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class GPSBLL
    {
        private GPSDAL gpsDAL = new GPSDAL();

        public bool LogPosition(int carId, decimal lat, decimal lng, decimal speed)
        {
            GPSLog log = new GPSLog
            {
                CarID = carId,
                Latitude = lat,
                Longitude = lng,
                Speed = speed
            };
            return gpsDAL.InsertLog(log);
        }

        public DataTable GetLatestTrackingInfo()
        {
            return gpsDAL.GetLatestLogs();
        }

        public DataTable GetHistory(int carId)
        {
            return gpsDAL.GetHistoryForCar(carId);
        }
    }
}
