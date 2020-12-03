using System;
using System.IO;
using System.Linq;

var Passwords = from DataBaseLine in File.ReadAllLines("Input.txt")
                let Policy = DataBaseLine.Split(": ").First()
                let PolicyPositions = Policy.Split(" ").First()
                select new
                {
                    Phrase = DataBaseLine.Split(": ").Last(),
                    PolicyChar = Policy.Split(" ").Last().Single(),
                    PolicyFirstPosition = int.Parse(PolicyPositions.Split("-").First()),
                    PolicySecondPosition = int.Parse(PolicyPositions.Split("-").Last()),
                };

var ValidPasswords = from Password in Passwords
                     let FirstPositionValid = Password.Phrase.ElementAt(Password.PolicyFirstPosition - 1) == Password.PolicyChar
                     let SecondPositionValid = Password.Phrase.ElementAt(Password.PolicySecondPosition - 1) == Password.PolicyChar
                     where FirstPositionValid ^ SecondPositionValid
                     select Password;

Console.WriteLine(ValidPasswords.Count());