using System;

class Program
{
    static void Main(string[] args)
    {
        int studentNumber = 3;
        int arrayLength = 10 + (studentNumber % 10);
        int[] X = new int[arrayLength];
        Random rnd = new Random();

        for (int i = 0; i < X.Length; i++)
        {
            X[i] = rnd.Next(-50, 50);
        }

        Console.Write("Введіть число М ");
        int M = int.Parse(Console.ReadLine());

        int[] Y = Array.FindAll(X, num => Math.Abs(num) > M);

        Console.WriteLine($"Число M {M}");
        Console.WriteLine("Масив Х");
        PrintArray(X);
        Console.WriteLine("Масив Y");
        PrintArray(Y);
    }

    static void PrintArray(int[] arr)
    {
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
