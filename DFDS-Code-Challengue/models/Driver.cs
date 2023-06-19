using DFDS_Code_Challengue.enums;

namespace DFDS_Code_Challengue.models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Nationality { get; set; }
        public string Residency { get; set; }
        public string Seniority { get; set; }
        public DrivingLicenceType LicenceType { get; set; }

        public Driver(int id, string name, DateOnly birthDay, string nationality, string residency, string seniority, DrivingLicenceType licenceType)
        {
            Id = id;
            Name = name;
            BirthDay = birthDay;
            Nationality = nationality;
            Residency = residency;
            Seniority = seniority;
            LicenceType = licenceType;
        }
    }
}
