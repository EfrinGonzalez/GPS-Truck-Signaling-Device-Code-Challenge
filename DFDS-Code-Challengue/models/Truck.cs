using DFDS_Code_Challengue.enums;

namespace DFDS_Code_Challengue.models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double WeightCapacity { get; set; }
        public int NumberOfWheels { get; set; }
        public double LengthOfTruck { get; set; }
        public TruckType type { get; set; }
        public Driver Driver { get; set; }

        public Truck(int id, string brand, double weightCapacity, int numberOfWheels, double lengthOfTruck, TruckType type, Driver driver)
        {
            Id = id;
            Brand = brand;
            WeightCapacity = weightCapacity;
            NumberOfWheels = numberOfWheels;
            LengthOfTruck = lengthOfTruck;
            this.type = type;
            Driver = driver;
        }
    }
}
