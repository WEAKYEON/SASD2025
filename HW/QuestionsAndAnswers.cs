using System;

namespace Refactoring101
{
    public class CustomDate
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public CustomDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public string Format()
        {
            return $"{Day:00}/{Month:00}/{Year:0000}";
        }
    }

    public class QuestionsAndAnswers
    {
        // 1. Mysterious Name
        public double GetMax(double number1, double number2)
        {
            return number1 > number2 ? number1 : number2;
        }

        // 2. Duplicate Code
        public void Print()
        {
            PrintBanner("Mr.Harry Potter");
            PrintBanner("Ms.Mary Poppin");
            PrintBanner("Mr.Johny Black");
        }

        private void PrintBanner(string name)
        {
            Console.WriteLine("***********************");
            Console.WriteLine($"   {name}");
            Console.WriteLine("***********************");
            Console.WriteLine();
        }

        // 3. Shotgun Surgery
        public static class SchoolConfig
        {
            public const int TotalStudentCount = 48;
        }

        public class Shotgun1
        {
            public void DisplayStudents()
            {
                Console.WriteLine("Student Count = " + SchoolConfig.TotalStudentCount);
            }
        }

        public class Shotgun2
        {
            public void PrintTotal()
            {
                Console.WriteLine("Total Students : " + SchoolConfig.TotalStudentCount);
            }
        }

        // 4. Data Clump
        public void PrintDate_Step4(CustomDate date)
        {
            Console.WriteLine($"{date.Day:00}/{date.Month:00}/{date.Year:0000}");
        }

        // 5. Feature Envy
        public void PrintDate_Step5(CustomDate date)
        {
            Console.WriteLine(date.Format());
        }
    }
}