using DFDS_Code_Challengue.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDS_Code_Challengue.services
{
    internal class DummyLocationGPSData
    {
        List<Coordinate> coordinates;
        //Build a collection with coordinates

        public List<Coordinate> GetData() {
            coordinates = new List<Coordinate> ();
            coordinates.Add(new Coordinate(Guid.NewGuid(), 48.672309, 15.695585, new DateTime(2018, 2, 1), "Germany"));
            coordinates.Add(new Coordinate(Guid.NewGuid(), 48.237867, 16.389477, new DateTime(2018, 2, 1), "Germany"));

            return coordinates;
        }
    }
}
