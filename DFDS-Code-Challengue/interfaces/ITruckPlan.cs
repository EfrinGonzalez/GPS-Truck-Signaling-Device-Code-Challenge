using DFDS_Code_Challengue.models;

namespace DFDS_Code_Challengue.interfaces
{
    public interface ITruckPlan
    {  
        List<Coordinate> RequestGPSPositions();
        double CalculateTotalRouteDistance(List<Coordinate> RouteGPSCoordiantes);

        string GetCountry(Coordinate coordinate); 
    }
}
