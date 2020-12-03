using System;
using System.IO;
using System.Linq;

// Part one
//var ExpenseReport = from Expense in File.ReadAllLines("Input.txt") select int.Parse(Expense);
//var Matches = from x in ExpenseReport
//              where ExpenseReport.Any(y => x + y == 2020)
//              select x;
//Console.WriteLine(Matches.ElementAt(0) * Matches.ElementAt(1));

// Part two
var ExpenseReport = from Expense in File.ReadAllLines("Input.txt") select int.Parse(Expense);
var Matches = from x in ExpenseReport
              from y in ExpenseReport
              from z in ExpenseReport
              where x + y + z == 2020
              select x * y * z;
Console.WriteLine(Matches.Distinct().Single());