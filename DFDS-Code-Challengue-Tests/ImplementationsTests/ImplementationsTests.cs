using Microsoft.VisualStudio.TestTools.UnitTesting;
using DFDS_Code_Challengue.enums;
using DFDS_Code_Challengue.implementations;
using DFDS_Code_Challengue.models;
using DFDS_Code_Challengue.services;
using System;
using System.Collections.Generic;

namespace DFDS_Code_Challengue_Tests.ImplementationsTests
{
    [TestClass]
    public class ImplementationsTests
    {

        Driver? DriverOne;
        Driver? DriverTwo;
        Driver? DriverThree;

        Truck? TruckOne;
        Truck? TruckTwo;
        Truck? TruckThree;

        Coordinate? StartPosition;
        Coordinate? EndPosition;

        TruckRoute? TruckRouteOne;
        TruckRoute? TruckRouteTwo;
        TruckRoute? TruckRouteThree;

        TruckPlanImpl? TuckPlanOne;
        TruckPlanImpl? TuckPlanTwo;
        TruckPlanImpl? TuckPlanThree;

        TruckPlanService? TruckPlanServiceOne;
        TruckPlanService? TruckPlanServiceTwo;
        TruckPlanService? TruckPlanServiceThree;

        [TestInitialize]
        public void testInit()
        {
             DriverOne = new Driver(1, "Driver One", new DateOnly(1980, 10, 12), "Denmark", "Denmark", "Senior", DrivingLicenceType.LICENSE_A);
             DriverTwo = new Driver(1, "Driver One", new DateOnly(1969, 10, 12), "Denmark", "Denmark", "Mid-Senior", DrivingLicenceType.LICENSE_B);
             DriverThree = new Driver(1, "Driver One", new DateOnly(1969, 10, 12), "Denmark", "Denmark", "Senior", DrivingLicenceType.LICENSE_A);


             TruckOne = new Truck(1, "ONE", 0, 0, 0, TruckType.NON_REFRIGERATED, DriverOne);
             TruckTwo = new Truck(1, "TWO", 0, 0, 0, TruckType.NON_REFRIGERATED, DriverTwo);
             TruckThree = new Truck(1, "THREE", 0, 0, 0, TruckType.NON_REFRIGERATED, DriverThree);

             StartPosition = new Coordinate(Guid.NewGuid(), 48.672309, 15.695585, new DateTime(2018, 2, 1), "Germany");
             EndPosition = new Coordinate(Guid.NewGuid(), 48.237867, 16.389477, new DateTime(2018, 2, 2), "Germany");

             TruckRouteOne = new TruckRoute(TruckOne, StartPosition, EndPosition, null, 0);
             TruckRouteTwo = new TruckRoute(TruckTwo, StartPosition, EndPosition, null, 0);
             TruckRouteThree = new TruckRoute(TruckThree, StartPosition, EndPosition, null, 0);

             TuckPlanOne = new TruckPlanImpl(TruckRouteOne);
             TuckPlanTwo = new TruckPlanImpl(TruckRouteTwo);
             TuckPlanThree = new TruckPlanImpl(TruckRouteThree);

             TruckPlanServiceOne = new TruckPlanService(TuckPlanOne);
             TruckPlanServiceTwo = new TruckPlanService(TuckPlanTwo);
             TruckPlanServiceThree = new TruckPlanService(TuckPlanThree);         
        }


        [TestMethod]
        public void RequestGPSPositions()
        {
            TruckRouteOne.GPSPositionTrackingPoints = TruckPlanServiceOne.GetGPSPositions();
            Assert.IsNotNull(TruckRouteOne.GPSPositionTrackingPoints);
            Assert.IsTrue(TruckRouteOne.GPSPositionTrackingPoints.Count > 0);
        }

        [TestMethod]
        public void CalculateTotalRouteDistance()
        {
            TruckRouteOne.GPSPositionTrackingPoints = TruckPlanServiceOne.GetGPSPositions();
            var TotalDistanceOne = TruckPlanServiceOne.CalcutaTripDistance(TruckRouteOne.GPSPositionTrackingPoints);
            TruckRouteOne.TotalDistanceTravelled = TotalDistanceOne;
            Assert.AreEqual(TruckRouteOne.TotalDistanceTravelled, 70.36745570052427);
        }


        [TestMethod]
        public void GetCountry()
        {
            var country = TruckPlanServiceOne.CalculateCountry(StartPosition); 
            Assert.IsNotNull(country);
            Assert.AreEqual("Germany", country);
        }
        
        [TestMethod]
        public void TestReport()
        {            
            List<TruckRoute> plans = new List<TruckRoute>();
            plans.Add(TruckRouteOne);
            plans.Add(TruckRouteTwo);
            plans.Add(TruckRouteThree);
            ReportingImpl report = new ReportingImpl();
            ReportService ReportService = new ReportService(report);

            TruckRouteOne.GPSPositionTrackingPoints = TruckPlanServiceOne.GetGPSPositions();
            TruckRouteOne.TotalDistanceTravelled = TruckPlanServiceOne.CalcutaTripDistance(TruckRouteOne.GPSPositionTrackingPoints);

            TruckRouteTwo.GPSPositionTrackingPoints = TruckPlanServiceTwo.GetGPSPositions();
            TruckRouteTwo.TotalDistanceTravelled = TruckPlanServiceTwo.CalcutaTripDistance(TruckRouteTwo.GPSPositionTrackingPoints);

            TruckRouteThree.GPSPositionTrackingPoints = TruckPlanServiceThree.GetGPSPositions();
            TruckRouteThree.TotalDistanceTravelled = TruckPlanServiceThree.CalcutaTripDistance(TruckRouteOne.GPSPositionTrackingPoints);
        
            double distanceDriveByFifties = ReportService.ReportingKilometerDriven(plans);
            Console.WriteLine("The total distance of the of 50 years old is: " + distanceDriveByFifties);

            Assert.IsTrue(distanceDriveByFifties > 0);           
            //Note: More tests can be calculated once the distance function is precise on doing the calculations.
        }
    }
}
