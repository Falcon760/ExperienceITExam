﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryExpressionPattern
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }

    class Program
    {

        private static string[] departments = 
        {
            "rabbits",
            "birds",
            "hunters"
        };

        private static Employee[] employees = 
        {
            new Employee{FirstName="Bugs", LastName="Bunny", Age=45, Department="rabbits"},
            new Employee{FirstName="Porky", LastName="Pig", Age=38, Department="hunters"},
            new Employee{FirstName="Daffy", LastName="Duck", Age=57, Department="birds"},
            new Employee{FirstName="Tweety", LastName="Bird", Age=12, Department="birds"},
            new Employee{FirstName="Sylverster", LastName="Cat", Age=6, Department="hunters"},
            new Employee{FirstName="Elmer", LastName="Fudd", Age=64, Department="hunters"},
            new Employee{FirstName="Road", LastName="Runner", Age=19, Department="birds"},
            new Employee{FirstName="Wile", LastName="Coyote", Age=27, Department="hunters"}
        };
        static void Main(string[] args)
        {
            // Convert each of the following Fluent Syntax methods into queries:
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var smallNumbers = numbers.Where((n) => n < 5);
            var smallNumbers2 = from n in numbers
                                where n < 5
                                select n;
            foreach (int item in smallNumbers2)
            {
                Console.WriteLine(item);
            }
            


            var allNumbers = numbers.Select(n => n);
            var allNumbers2 = from m in numbers
                              select m;
            foreach (var item in allNumbers2)
            {
                var x = item * 2;
                Console.WriteLine(x);
            }

            var squares = numbers.Select(n => new { Number = n, Square = n * n });

            var people = employees.Where(e => e.Age > 30).
                OrderBy(e => e.LastName).
                ThenBy(e => e.FirstName).
                ThenBy(e => e.Age);

            
             var people2 = from f in employees
                          where f.Age < 30
                          select (f.LastName, f.FirstName, f.Age);



            var results = employees.GroupBy(e => e.Department).
                Select(d => new { Department = d.Key, Size = d.Count() });

            var results2 = employees.GroupBy(e => e.Department).
                Select(d => new
                {
                    Department = d.Key,
                    Employees = d.AsEnumerable()
                });

            int[] odds = {1,3,5,7};
            int[] evens = {2,4,6,8};
            var values = odds.SelectMany(oddNumber => evens,
                (oddNumber, evenNumber) =>
                new { oddNumber, evenNumber, Sum = oddNumber + evenNumber });

        for (int i = 0; i < odds.Length; i++)
			{
            if (odds[i] + evens[i] % 2 == 0)
                Console.WriteLine("What");
			}

            var values2 = odds.SelectMany(oddNumber => evens,
                (oddNumber, evenNumber) =>
                new { oddNumber, evenNumber })
                .Where(pair => pair.oddNumber > pair.evenNumber).
                Select(pair => new
                {
                    pair.oddNumber,
                    pair.evenNumber,
                    Sum = pair.oddNumber + pair.evenNumber
                });

            var nums = new int[] { 1, 2, 3 };
            var words = new string[] { "one", "two", "three" };
            var romanNumerals = new string[] { "I", "II", "III" };
            var triples = nums.SelectMany(n => words,
                (n, s) => new { n, s }).
                SelectMany(pair => romanNumerals,
                (pair, n) => new { Arabic = pair.n, Word = pair.s, Roman = n });

            var digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var labels = new string[] { "0", "1", "2", "3", "4", "5" };
            var query = digits.Join(labels, num => num.ToString(), label => label,
                (num, label) => new { num, label });
            var query2 = from n in digits, labels
                where n inner join 




            var groups = departments.GroupJoin(employees,
                p => p, e => e.Department, (p, emps) =>
                    new { Department = p, Employees = emps});

            Console.ReadLine();
        }
    }
}
