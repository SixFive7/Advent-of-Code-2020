using System;
using System.IO;
using System.Linq;


// Read input.
var Passports = from RawPassport in File.ReadAllText("Input.txt").Split(Environment.NewLine + Environment.NewLine)
                select new Passport(RawPassport.Replace(Environment.NewLine, " "));

// Check validity.
var ValidPasswords = from Passport in Passports
                     where Passport.BirthYear is not null
                     where Passport.IsueYear is not null
                     where Passport.ExpirationYear is not null
                     where Passport.Height is not null
                     where Passport.HairColor is not null
                     where Passport.EyeColor is not null
                     where Passport.PassportID is not null
                     select Passport;

Console.WriteLine(ValidPasswords.Count());

internal class Passport
{
    internal readonly string BirthYear;
    internal readonly string IsueYear;
    internal readonly string ExpirationYear;
    internal readonly string Height;
    internal readonly string HairColor;
    internal readonly string EyeColor;
    internal readonly string PassportID;
    internal readonly string CountryID;

    internal Passport(string RawData)
    {
        foreach (var Attribute in RawData.Split(" "))
        {
            var Key = Attribute.Split(":").First();
            var Value = Attribute.Split(":").Last();
            _ = Key switch
            {
                "byr" => BirthYear = Value,
                "iyr" => IsueYear = Value,
                "eyr" => ExpirationYear = Value,
                "hgt" => Height = Value,
                "hcl" => HairColor = Value,
                "ecl" => EyeColor = Value,
                "pid" => PassportID = Value,
                "cid" => CountryID = Value,
                _ => throw new NotImplementedException(),
            };
        }
    }
}