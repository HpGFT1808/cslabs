using System;

class Program
{
    static void Main(string[] args)
    {
        int studentNumber = 13;
        int arrayLength = 10 + (studentNumber % 10);

        int[] X = new int[arrayLength];
        Random rnd = new Random();
        for (int i = 0; i < X.Length; i++)
        {
            X[i] = rnd.Next(100);
        }

        int min = X[0];
        int max = X[0];

        for (int i = 1; i < X.Length; i++)
        {
            if (X[i] < min)
            {
                min = X[i];
            }
            else if (X[i] > max)
            {
                max = X[i];
            }
        }

         Console.WriteLine("Масив X");
        foreach (int num in X)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        Console.WriteLine($"Мінімальне значення {min}");
        Console.WriteLine($"Максимальне значення {max}");
    }
}
