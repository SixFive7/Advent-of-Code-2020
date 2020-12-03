using System;
using System.IO;
using System.Linq;

var Passwords = from DataBaseLine in File.ReadAllLines("Input.txt")
                let Policy = DataBaseLine.Split(": ").First()
                let PolicyMinMax = Policy.Split(" ").First()
                select new
                {
                    Phrase = DataBaseLine.Split(": ").Last(),
                    PolicyChar = Policy.Split(" ").Last().Single(),
                    PolicyMin = uint.Parse(PolicyMinMax.Split("-").First()),
                    PolicyMax = uint.Parse(PolicyMinMax.Split("-").Last()),
                };

var ValidPasswords = from Password in Passwords
                     let CharCount = Password.Phrase.Count(x => x == Password.PolicyChar)
                     where CharCount >= Password.PolicyMin
                     where CharCount <= Password.PolicyMax
                     select Password;

Console.WriteLine(ValidPasswords.Count());