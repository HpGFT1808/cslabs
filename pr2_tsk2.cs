using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть сторонри трикутника:");
        Console.Write("Сторона A ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Сторона B ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Сторона C ");
        double c = double.Parse(Console.ReadLine());

        if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a)
        {
            double perimeter = a + b + c;
            double s = perimeter / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            Console.WriteLine($"Периметр трикутника {perimeter}");
            Console.WriteLine($"Площа трикутника {area}");

            if (a == b && b == c)
                Console.WriteLine("Трикутник рівносторонній");
            else if (a == b || a == c || b == c)
                Console.WriteLine("Трикутник рівнобедрений");
            else
                Console.WriteLine("Трикутник різносторонній");
        }
        else
        {
            Console.WriteLine("Трикутника такого не існує.");
        }
    }
}
