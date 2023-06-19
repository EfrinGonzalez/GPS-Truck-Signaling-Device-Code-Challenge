namespace DFDS_Code_Challengue.models
{
    public class TruckRoute
    {
        public Truck TruckInUse { get; set; }
        public Coordinate StartPosition { get; set; }
        public Coordinate EndPosition { get; set; }
        /// <summary>
        /// //Used for requesting current position and add to the collection.
        /// as well as the sum of distances
        /// </summary>
        public List<Coordinate> GPSPositionTrackingPoints { get; set; }
        public double TotalDistanceTravelled { get; set; }

        public TruckRoute(Truck truckInUse, Coordinate startPosition, Coordinate endPosition, List<Coordinate> gPSPositionTrackingPoints, double totalDistanceTravelled)
        {
            TruckInUse = truckInUse;
            StartPosition = startPosition;
            EndPosition = endPosition;
            GPSPositionTrackingPoints = gPSPositionTrackingPoints;
            TotalDistanceTravelled = totalDistanceTravelled;
        }
    }
}
