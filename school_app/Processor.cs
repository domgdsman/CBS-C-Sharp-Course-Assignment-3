using System;
using System.Collections.Generic;

namespace school_app
{
    public class Processor
    {
        private bool firstStart = true;
        private List<Person> Persons = new List<Person>();
        private int MainMenuInput()
        {
            if (firstStart)
            {
                Console.WriteLine("**** Welcome to your School App Human Resource Software ****");
                firstStart = false;
            }

            if (!firstStart)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome back to the main menu");
            }

            Console.WriteLine("Please select one of the options from the main menu");
            Console.WriteLine("1. Add new Person");
            Console.WriteLine("2. List all the Persons");
            Console.WriteLine("3. Exit");

            int selection; //default 0

            try
            {
                string actionSelection = Console.ReadLine();
                if (int.TryParse(actionSelection, out selection) == false)
                {
                    throw new Exception("Invalid selection");
                }

                if (selection < 1 || selection > 3)
                {
                    throw new Exception("Invalid selection");
                }

                return selection;

            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}. An error occurred. Please try again.");
                MainMenuInput();
            }

            return 3; // unreachable code
        }

        public void Process()
        {

            int selection;
            do
            {
                selection = MainMenuInput();

                switch (selection)
                {
                    case 1:
                        AddPerson();
                        break;
                    case 2:
                        PrintPersons();
                        break;
                    default:
                        Console.WriteLine("Program closed.");
                        break;
                }


            } while (selection != 3);
        }

        private void AddPerson()
        {
            Console.WriteLine();
            Console.WriteLine("### Add person in process ###");

            Console.WriteLine("What type of person would you like to add?");
            Console.WriteLine("Type in your selection by number");

            Console.WriteLine("1. Student");
            Console.WriteLine("2. Administration staff");
            Console.WriteLine("3. Top management");

            int personType = int.Parse(Console.ReadLine());

            switch (personType)
            {
                case 1:
                    Student student = ReadStudentInfo();
                    Persons.Add(student);
                    Console.WriteLine("Person added to Register");
                    break;
                case 2:
                    AdministrationStaff administrationStaff = ReadAdminInfo();
                    Persons.Add(administrationStaff);
                    Console.WriteLine("Person added to Register");
                    break;
                case 3:
                    TopManagement topManagement = ReadManagementInfo();
                    Persons.Add(topManagement);
                    Console.WriteLine("Person added to Register");
                    break;
                default:
                    return;
            }
        }

        private void PrintPersons()
        {
            if (Persons.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No persons listed");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("List of all persons registered:");
            Console.WriteLine();
            foreach (Person person in Persons)
            {
                person.PrintInfo();
                Console.WriteLine();
            }
        }

        // Reading methods to collect user input info for person creation
        private void ReadGenericPersonInfo(Person person)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[8];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            person.Id = new String(stringChars);

            Console.WriteLine("Random person id generated...");

            Console.WriteLine("Enter persons name:");
            person.Name = Console.ReadLine();

            Console.WriteLine("Enter date of birth:");
            DateTime birthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.WriteLine("Please type a valid date format YYYY-MM-DD!");
            }
            person.Birthdate = birthDate;

            Console.WriteLine("Starting to collect address information now...");

            Console.WriteLine("Enter street name and no.:");
            string streetNumber = Console.ReadLine();

            Console.WriteLine("Enter zip code:");
            string zipCode = Console.ReadLine();

            Console.WriteLine("Enter city:");
            string city = Console.ReadLine();

            Console.WriteLine("Enter country:");
            string country = Console.ReadLine();

            Address address = new Address(streetNumber, zipCode, city, country);
            person.AddAddress(address);
        }

        private Student ReadStudentInfo()
        {
            Student student = new Student();

            ReadGenericPersonInfo(student as Person); // upcasting student to person for shared values

            student.StartDate = DateTime.Today; // assuming starting date is today
            student.EndDate = student.StartDate.AddYears(2); // assuming a study duration of 2 years

            Console.WriteLine("Enter study program:");
            student.StudyProgram = Console.ReadLine();

            return student;
        }

        private AdministrationStaff ReadAdminInfo()
        {
            AdministrationStaff admin = new AdministrationStaff();

            ReadGenericPersonInfo(admin as Person); // upcasting admin to person for shared values

            Console.WriteLine("Enter department:");
            admin.Department = Console.ReadLine();

            Console.WriteLine("Enter role:");
            admin.Role = Console.ReadLine();

            admin.StartDate = DateTime.Today; // assuming starting date is today

            return admin;
        }

        private AdministrationStaff ReadAdminInfo(AdministrationStaff admin)
        {
            ReadGenericPersonInfo(admin as Person); // upcasting admin to person for shared values

            Console.WriteLine("Enter department:");
            admin.Department = Console.ReadLine();

            Console.WriteLine("Enter role:");
            admin.Role = Console.ReadLine();

            admin.StartDate = DateTime.Today; // assuming starting date is today

            return admin;
        }

        private TopManagement ReadManagementInfo()
        {
            TopManagement manager = new TopManagement();

            ReadAdminInfo(manager as AdministrationStaff);

            Console.WriteLine("Enter working experience in years:");
            int yearsExperience;
            while (!int.TryParse(Console.ReadLine(), out yearsExperience))
            {
                Console.WriteLine("Please type a valid time in form of an integer!");
            }
            manager.YearsExperience = yearsExperience;

            Console.WriteLine("Select management area from following options:\n1. Research\n2. Teaching\n3. Organizer");
            int areaInput;
            while (!int.TryParse(Console.ReadLine(), out areaInput))
            {
                Console.WriteLine("Please type a value in form of an integer [1/2/3]!");
            }

            switch (areaInput)
            {
                case 1:
                    manager.ManagementArea = ManagementArea.Research;
                    break;
                case 2:
                    manager.ManagementArea = ManagementArea.Teaching;
                    break;
                case 3:
                    manager.ManagementArea = ManagementArea.Organizer;
                    break;
                default:
                    manager.ManagementArea = ManagementArea.Undefined;
                    break;
            }

            return manager;
        }
    }
}
