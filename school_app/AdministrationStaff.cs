using System;
namespace school_app
{
    public class AdministrationStaff : Person
    {
        public string Department { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }

        public AdministrationStaff() { }

        // constructor not used
        public AdministrationStaff(string id, string name, DateTime birthdate, Address address, string department, string role, DateTime startDate)
            : base(id, name, birthdate, address)
        {
            Department = department;
            Role = role;
            StartDate = startDate;
        }

        protected override void PrintAdditionalInfo()
        {
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Start date: {StartDate.ToShortDateString()}");
            PrintManagementInfo();
        }

        protected virtual void PrintManagementInfo()
        {
            // method override in TopManagement
        }
    }
}
