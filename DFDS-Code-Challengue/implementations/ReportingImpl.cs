using DFDS_Code_Challengue.interfaces;
using DFDS_Code_Challengue.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDS_Code_Challengue.implementations
{
    public class ReportingImpl : IReporting
    {    
        /*"How many kilometers did
           drivers over the age of 50 drive in Germany in February 2018 ?*/
        public double Report(List<TruckRoute> collection) {
            var limitDate = new DateOnly(1970, 1, 1);

            double totalKilometers = collection
                    .Where(route =>
                        route.StartPosition.Country == "Germany" &&
                        route.EndPosition.Country == "Germany" &&
                        //route.TruckInUse.Driver.BirthDay <= DateTime.Now.AddYears(-50)
                        route.TruckInUse.Driver.BirthDay.Year < limitDate.Year &&
                        route.GPSPositionTrackingPoints.Any(point =>
                            point.TimeStamp.Year == 2018 &&
                            point.TimeStamp.Month == 2 &&
                            point.Country == "Germany"
                        )
                    )
                    .Sum(route => route.TotalDistanceTravelled);

            return totalKilometers;
        }


       
    }
}
