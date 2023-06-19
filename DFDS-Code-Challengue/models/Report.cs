namespace DFDS_Code_Challengue.models
{
    internal class Report
    {
        public List<TruckRoute> TruckRoutes { get; set; }

        public Report(List<TruckRoute> truckRoutes)
        {
            TruckRoutes = truckRoutes;
        }
    }
}
