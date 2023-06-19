namespace DFDS_Code_Challengue.models
{
    public class Coordinate
    {
        public Guid UniqueIdentified { get; set; } 
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Country { get; set; }//Filled via api or conversion

        public Coordinate(Guid uniqueIdentified, double latitud, double longitud, DateTime timeStamp, string country)
        {
            UniqueIdentified = uniqueIdentified;
            Latitud = latitud;
            Longitud = longitud;
            TimeStamp = timeStamp;
            Country = country;
        }
    }
}
