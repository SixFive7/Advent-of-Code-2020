using System;
using System.IO;
using System.Linq;
using System.Reflection;


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
    internal Passport(string RawData)
    {
        foreach (var Attribute in RawData.Split(" "))
        {
            var MethodInfo = typeof(Passport).GetMethod(Attribute.Split(":").First(), BindingFlags.Instance | BindingFlags.NonPublic);
            try { MethodInfo.Invoke(this, new object[] { Attribute.Split(":").Last() }); }
            catch (NullReferenceException) { throw new NotImplementedException("Unknown field type!"); }
        }
    }

    internal int? BirthYear;
    private void byr(string RawInput)
    {
        if (!int.TryParse(RawInput, out var Input)) { return; }
        BirthYear = Input switch
        {
            >= 1920 and <= 2002 => Input,
            _ => null
        };
    }

    internal int? IsueYear;
    private void iyr(string RawInput)
    {
        if (!int.TryParse(RawInput, out var Input)) { return; }
        IsueYear = Input switch
        {
            >= 2010 and <= 2020 => Input,
            _ => null
        };
    }

    internal int? ExpirationYear;
    private void eyr(string RawInput)
    {
        if (!int.TryParse(RawInput, out var Input)) { return; }
        ExpirationYear = Input switch
        {
            >= 2020 and <= 2030 => Input,
            _ => null
        };
    }

    internal int? Height;
    private void hgt(string RawInput)
    {
        var Unit = string.Concat(RawInput.TakeLast(2));
        if (!int.TryParse(string.Concat(RawInput.SkipLast(2)), out var Value)) { return; }
        Height = Unit switch
        {
            "cm" => Value switch
            {
                >= 150 and <= 193 => Value,
                _ => null
            },
            "in" => Value switch
            {
                >= 59 and <= 76 => Value,
                _ => null
            },
            _ => null
        };
    }

    internal string HairColor;
    private void hcl(string RawInput)
    {
        if (RawInput.Length != 7) { return; };
        if (RawInput.First() != '#') { return; };
        if (RawInput.Skip(1).Any(x => !"0123456789abcdef".Contains(x))) { return; }
        HairColor = string.Concat(RawInput.Skip(1));
    }

    internal string EyeColor;
    private void ecl(string RawInput)
    {
        if (new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(RawInput)) { EyeColor = RawInput; }
    }

    internal int? PassportID;
    private void pid(string RawInput)
    {
        if (RawInput.Length != 9) { return; };
        if (!int.TryParse(RawInput, out var Value)) { return; }
        PassportID = Value;
    }

    internal string CountryID;
    private void cid(string RawInput)
    {
        CountryID = RawInput;
    }
}