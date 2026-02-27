using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassDesign;

//Usage of JsonIgnore: https://stackoverflow.com/questions/10169648/how-to-exclude-property-from-json-serialization
public class Customer
{
    //auto-implemented properties
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required DateOnly DateOfBirth { get; init; }

    // computed properties
    //[JsonIgnore]
    public string FullName => FirstName + " " + LastName;

    [JsonIgnore]
    public int Age
    {
        get
        {   //Todo: Refactoring (Extract and Move to Utility Class)
            //from : https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
            var today = DateTime.Today;
            var birth = DateOfBirth.ToDateTime(new TimeOnly());
            var age = today.Year - birth.Year;

            // If the birthdate hasn't arrived yet, subtract one year.
            if (birth.Date > today.AddYears(-age)) 
                age--;

            return age;
        }
    }

    public Customer() { } // Empty Constructor

    [SetsRequiredMembers]
    public Customer(Customer obj) // Copy Constructor
    {
        FirstName = obj.FirstName;
        LastName = obj.LastName;
        DateOfBirth = obj.DateOfBirth;
    }

    public override string ToString() => $"(FirstName={FirstName},DOB={DateOfBirth})";
}
