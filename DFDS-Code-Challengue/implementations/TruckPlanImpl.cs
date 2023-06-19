using DFDS_Code_Challengue.interfaces;
using DFDS_Code_Challengue.models;
using DFDS_Code_Challengue.services;
using DFDS_Code_Challengue.utils;

namespace DFDS_Code_Challengue.implementations
{
    public class TruckPlanImpl : ITruckPlan
    {
        public TruckRoute truckRoute ;
        
        public TruckPlanImpl(TruckRoute truckRoute)
        {
            this.truckRoute = truckRoute;
        }      

        public List<Coordinate> RequestGPSPositions()
        {
            //We need to request and add it to the collection
            DummyLocationGPSData dummyLocationDataService = new DummyLocationGPSData();
            return truckRoute.GPSPositionTrackingPoints =  dummyLocationDataService.GetData();
        }       

        public double CalculateTotalRouteDistance(List<Coordinate> RouteGPSCoordiantes)
        {
            double total = 0;

            for (int index = 0; index < (RouteGPSCoordiantes.Count - 1); index++)
            {                
                var distance = RouteGPSCoordiantes[index]
                                .DistanceTo(RouteGPSCoordiantes[index+1],
                                            UnitOfLength.Kilometers
                                            );
                total += distance;
            }

            //Add the distances from start to first in collection
            var a = this.truckRoute.StartPosition;
            var b = RouteGPSCoordiantes.First();
            var extra1 = a.DistanceTo(b,UnitOfLength.Kilometers);
            //add the last in collection to end position
            var c = this.truckRoute.EndPosition;
            var d = RouteGPSCoordiantes.Last();
            var extra2 = c.DistanceTo(d, UnitOfLength.Kilometers);

            return total+extra1+extra2; 
        }

        public string GetCountry(Coordinate coordinate)
        {
            return coordinate.Country; 
        }
    }
}
