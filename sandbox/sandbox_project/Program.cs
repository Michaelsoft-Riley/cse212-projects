using System;
using System.Diagnostics;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        var numberDict = new Dictionary<string, int>
        {
            {"two", 2},
            {"one", 1},
            {"three", 3},
            {"five", 5},
            {"four", 4}
        };
        // var numbers = numberDict.ToArray();
        // Array.Sort(numbers, (p1, p2) => p1.Value - p2.Value);
        var numbers = numberDict.OrderByDescending(n => n.Value).ToArray();

        foreach (var number in numbers) {
            Console.WriteLine(number);
        }
    }
}