using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 4, 17, 28 };
        int n = 13;

        int lastDigit = n % 10;
        int lowerBound = 1;
        int upperBound = 10 + lastDigit;

        Console.WriteLine($"numbers: [{lowerBound},{upperBound}]:");

        foreach (int num in numbers)
        {
            if (num >= lowerBound && num <= upperBound)
            {
                Console.WriteLine(num);
            }
        }
    }
}
