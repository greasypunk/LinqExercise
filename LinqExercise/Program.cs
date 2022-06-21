using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             */
            //TODONE: Print the Sum of numbers
            //TODO: Print the Average of numbers
            //TODONE: Order numbers in ascending order and print to the console
            //TODONE: Order numbers in decsending order adn print to the console
            //TODONE: Print to the console only the numbers greater than 6
            //TODONE: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            //TODONE: Change the value at index 4 to your age, then print the numbers in decsending order
            // List of employees ****Do not remove this****
            //TODONE: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            //TODONE: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            //TODONE: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            //TODONE: Add an employee to the end of the list without using employees.Add()
            
            Console.WriteLine($"\nnumbers sum: {numbers.Sum()}");
            Console.WriteLine($"\nnumbers average: {numbers.Average()}");
            var ascOrder = numbers.OrderBy(x => x);
            Console.WriteLine("\nascending order:");
            foreach (var num in ascOrder) { Console.WriteLine(num); }
            var descOrder = numbers.OrderByDescending(x => x);
            Console.WriteLine("\ndescending order:");
            foreach (var num in descOrder) { Console.WriteLine(num); }
            Console.WriteLine($"\ngreater than  6:");
            var greaterThenSix = numbers.Where(x => x > 6);
            foreach (var num in greaterThenSix) { Console.WriteLine(num); }
            Console.WriteLine("\nfirst four, ascending order:");
            foreach (var num in ascOrder.Take(4)) { Console.WriteLine(num); }
            numbers.SetValue(300, 4);
            var sortedAge = numbers.OrderByDescending(x => x);
            Console.WriteLine("\nage at index 4, printed in descending order:");
            foreach (var num in sortedAge) { Console.WriteLine(num); }
            var employees = CreateEmployees();
            Console.WriteLine("first aname starts with 'C' or 'S':");
            var cOrS = employees.Where(employee => employee.FirstName.StartsWith('C') || employee.FirstName.StartsWith('S')).OrderBy(employee => employee.FirstName);
            foreach (var guy in cOrS) { Console.WriteLine(guy.FullName); }
            var over26 = employees.Where(employee => employee.Age > 26).OrderBy(emplyoee => emplyoee.Age).ThenBy(employee => employee.FirstName);
            Console.WriteLine("\nemployees over 26, ordered by age then first name");
            foreach (var guy in over26) { Console.WriteLine($"{guy.FirstName}, {guy.Age}"); }
            var nosey = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            Console.WriteLine($"\nsum and average of employees with 10 years or less of experience who are also greater than 35 years old. \nsum: {nosey.Sum(employee => employee.YearsOfExperience)}, average: {nosey.Average(employee => employee.YearsOfExperience)}");
            employees = employees.Append(new Employee("Corey", "Martin", 31, 1)).ToList();
            Console.WriteLine("\nadded corey martin as employee. all employees:");
            foreach (var emp in employees) { Console.WriteLine($"{emp.FirstName} {emp.LastName}, Age: {emp.Age}, YOE: {emp.YearsOfExperience}"); }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
