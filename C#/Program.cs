namespace Paulsen_Arnold_PRG1782_CT1
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public enum MenuOption
        {
            EnterDetails = 1,
            DisplayEmployees,
            SearchEmployees,
            Exit
        }

        static Dictionary<int, string> employeeDictionary = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Please select a Menu Option:");
                Console.WriteLine("To choose Enter Details, press 1");
                Console.WriteLine("To choose Display Employees, press 2");
                Console.WriteLine("To choose Search Employees, press 3");
                Console.WriteLine("To choose Exit, press 4");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();
                Console.WriteLine("============================================");

                if (Enum.TryParse(input, out MenuOption userOption))
                {
                    switch (userOption)
                    {
                        case MenuOption.EnterDetails:
                            Console.WriteLine("Employee Details Capture");
                            bool stop = false;
                            while (!stop)
                            {
                                Console.WriteLine("Enter employee number: ");
                                int employeeNumber = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter employee name: ");
                                string employeeName = Console.ReadLine();

                                AddEmployeeDetails(employeeNumber, employeeName);

                                Console.WriteLine("Would you like to continue? Y/N");
                                string stopping = Console.ReadLine();

                                if (stopping.ToUpper() == "N")
                                {
                                    stop = true;
                                }
                            }
                            break;

                        case MenuOption.DisplayEmployees:
                            Console.WriteLine("\nEmployee Details:");
                            foreach (var employee in employeeDictionary)
                            {
                                Console.WriteLine($"Employee Number: {employee.Key}, Employee Name: {employee.Value}");
                            }
                            break;

                        case MenuOption.SearchEmployees:
                            while (true)
                            {
                                Console.WriteLine("\nEnter employee number to search: ");
                                int searchEmployeeNumber = Convert.ToInt32(Console.ReadLine());

                                if (employeeDictionary.ContainsKey(searchEmployeeNumber))
                                {
                                    string employeeName = employeeDictionary[searchEmployeeNumber];
                                    Console.WriteLine($"Employee Number: {searchEmployeeNumber}, Employee Name: {employeeName}");
                                }
                                else
                                {
                                    Console.WriteLine("Employee number not found.");
                                }

                                Console.WriteLine("Would you like to continue searching? Y/N");
                                string continueSearch = Console.ReadLine();

                                if (continueSearch.ToUpper() == "N")
                                {
                                    break;
                                }
                            }
                            break;

                        case MenuOption.Exit:
                            Console.WriteLine("Thank you.");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option chosen, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

        static void AddEmployeeDetails(int employeeNumber, string employeeName)
        {
            if (!employeeDictionary.ContainsKey(employeeNumber))
            {
                employeeDictionary.Add(employeeNumber, employeeName);
                Console.WriteLine("Employee details added successfully.");
            }
            else
            {
                Console.WriteLine("Employee number already exists. Please enter a unique employee number.");
            }
        }
    }
}


