using System;
using System.IO;
using System.Linq;

var ExpenseReport = from Expense in File.ReadAllLines("Input.txt") select int.Parse(Expense);
var Matches = from x in ExpenseReport
              where ExpenseReport.Any(y => x + y == 2020)
              select x;
Console.WriteLine(Matches.ElementAt(0) * Matches.ElementAt(1));