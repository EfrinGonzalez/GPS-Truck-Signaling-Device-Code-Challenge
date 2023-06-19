using DFDS_Code_Challengue.models;

namespace DFDS_Code_Challengue.utils
{
    public static class CoordinatesDistanceExtensions
    {
        public static double DistanceTo(this Coordinate baseCoordinates, Coordinate targetCoordinates)
        {
            return DistanceTo(baseCoordinates, targetCoordinates, UnitOfLength.Kilometers);
        }

        public static double DistanceTo(this Coordinate baseCoordinates, Coordinate targetCoordinates, UnitOfLength unitOfLength)
        {
            var baseRad = Math.PI * baseCoordinates.Latitud / 180;
            var targetRad = Math.PI * targetCoordinates.Latitud / 180;
            var theta = baseCoordinates.Longitud - targetCoordinates.Longitud;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unitOfLength.ConvertFromMiles(dist);
        }
      
    }
}
//For reference on how the distance is calculated. 
//STackoverflow thread: https://stackoverflow.com/questions/6366408/calculating-distance-between-two-latitude-and-longitude-geocoordinates 
