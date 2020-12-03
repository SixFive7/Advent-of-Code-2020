using System;
using System.IO;
using System.Linq;

var ExpenseReport = from Expense in File.ReadAllLines("Input.txt") select int.Parse(Expense);
var Matches = from x in ExpenseReport
              from y in ExpenseReport
              from z in ExpenseReport
              where x + y + z == 2020
              select x * y * z;
Console.WriteLine(Matches.Distinct().Single());