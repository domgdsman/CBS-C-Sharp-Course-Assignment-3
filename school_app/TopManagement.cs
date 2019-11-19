using System;
namespace school_app
{
    public class TopManagement : AdministrationStaff
    {
        public int YearsExperience { get; set; }
        public ManagementArea ManagementArea { get; set; }

        public TopManagement() { }

        // constructor not used
        public TopManagement(string id, string name, DateTime birthdate, Address address, string department, string role, DateTime startDate, int yearsExperience, ManagementArea managementArea)
            : base(id, name, birthdate, address, department, role, startDate)
        {
            YearsExperience = yearsExperience;
            ManagementArea = managementArea;
        }

        protected override void PrintManagementInfo()
        {
            Console.WriteLine($"Years of working experience: {YearsExperience}");
            Console.WriteLine($"Area of management: {ManagementArea}");
        }
    }
}
