using DFDS_Code_Challengue.interfaces;
using DFDS_Code_Challengue.models;

namespace DFDS_Code_Challengue.services
{
    public class ReportService
    {
        private IReporting Reporting;

        public ReportService(IReporting reporting)
        {
            Reporting = reporting;
        }     

        public double ReportingKilometerDriven(List<TruckRoute> collection)
        {

            return Reporting.Report(collection);
        }

    }
}
