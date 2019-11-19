using System;
namespace school_app
{
    public class Student : Person
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StudyProgram { get; set; }

        public Student() { }

        // constructor not used
        public Student(string id, string name, DateTime birthdate, Address address, DateTime startDate, DateTime endDate, string studyProgram)
            : base(id, name, birthdate, address)
        {
            StartDate = startDate;
            EndDate = endDate;
            StudyProgram = studyProgram;
        }

        protected override void PrintAdditionalInfo()
        {
            Console.WriteLine($"Start date: {StartDate.ToShortDateString()}");
            Console.WriteLine($"End date: {EndDate.ToShortDateString()}");
            Console.WriteLine($"Study program: {StudyProgram}");
        }
    }
}
