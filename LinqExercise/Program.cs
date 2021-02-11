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
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers //done
            var sum = numbers.Sum();
            Console.WriteLine(sum);
            Console.WriteLine(".................................................");

            var average = numbers.Average();
            Console.WriteLine(average);
            Console.WriteLine(".................................................");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(x => x);
            
            foreach (int x in ascending)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("...................................................");
            
            var descending = numbers.OrderByDescending(x => x);
            foreach (int x in descending)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("...................................................");
            
            //Print to the console only the numbers greater than 6
           
            //Video Answer:
            var greaterThanSix = numbers.Where(x => x >6);
            foreach(var x in greaterThanSix)
            {
                Console.WriteLine(x);
            }
            
            //My Original
            var sixPlus = ascending.Skip(7).Take(3);
            foreach(int x in sixPlus)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("...................................................");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var onlyFourNumbers = ascending.Take(4);
            foreach(int x in onlyFourNumbers)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("...................................................");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 27;
            Console.WriteLine("My age included");
            foreach(var x in numbers.OrderByDescending(x => x))
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("....................................................");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            Console.WriteLine("....................................................");

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            var cOrS = employees.Where(x => x.FirstName[0] == 'C' || x.FirstName[0] == 'S');
            foreach(var x in cOrS)
            {
                Console.WriteLine(x.FullName);
            }

            Console.WriteLine("....................................................");

            //Order this in acesnding order by FirstName.
            var byFirst = employees.OrderBy(x => x.FirstName);
            foreach(var x in byFirst)
            {
                Console.WriteLine(x.FirstName);
            }

            Console.WriteLine(".....................................................");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            var fullNameAndAge = employees.Where(x => x.Age > 26);
            foreach (var x in fullNameAndAge)
            {
                Console.WriteLine(x.FullName);
            }
            Console.WriteLine(".....................................................");
            
            //Order this by Age first and then by FirstName in the same result.
            var ageThenFirst = fullNameAndAge.OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var x in ageThenFirst)
            {
                Console.WriteLine(x.FullName);
            }

            Console.WriteLine("......................................................");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($" Sum =  { years.Sum(x => x.YearsOfExperience)} Average =  { years.Average(x => x.YearsOfExperience)}");

            Console.WriteLine("......................................................");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append( new Employee("Hampton", "Rodgers",25,1)).ToList();
            foreach (var x in employees)
            {
                Console.WriteLine($" Name: {x.FirstName} , Age:  {x.Age}");
                //Console.WriteLine(x.Name , x.Age)
            }

            
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
