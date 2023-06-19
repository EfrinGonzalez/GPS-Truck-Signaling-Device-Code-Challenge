using DFDS_Code_Challengue.interfaces;
using DFDS_Code_Challengue.models;

namespace DFDS_Code_Challengue.services
{
    public class TruckPlanService
    {
        private ITruckPlan truckPlan;

        public TruckPlanService(ITruckPlan truckPlan)
        {
            this.truckPlan = truckPlan;
        }

        public List<Coordinate> GetGPSPositions()
        {
            return truckPlan.RequestGPSPositions();           
        }

        public double CalcutaTripDistance(List<Coordinate> coordinates) 
        {            
            return truckPlan.CalculateTotalRouteDistance(coordinates); 
        }

        public string CalculateCountry(Coordinate coordinate) 
        { 
            return truckPlan.GetCountry(coordinate);
        }

    }
}
