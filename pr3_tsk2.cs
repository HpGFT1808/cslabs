using System;
class Point
{
    private int x;
    private int y;
    private string name;
    public Point(int x, int y, string name)
    {
        this.x = x;
        this.y = y;
        this.name = name;
    }
    public int X
    {
        get { return x; }
    }
    public int Y
    {
        get { return y; }
    }
    public string Name
    {
        get { return name; }
    }
}
class Figure
{
    private Point[] points;
    public Figure(Point A, Point B, Point C)
    {
        points = new Point[] { A, B, C };
    }
    public Figure(Point A, Point B, Point C, Point D)
    {
        points = new Point[] { A, B, C, D };
    }
    public Figure(Point A, Point B, Point C, Point D, Point E)
    {
        points = new Point[] { A, B, C, D, E };
    }
    private double LengthSide(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
    }
    public void PerimeterCalculator()
    {
        double perimeter = 0;
        for (int i = 0; i < points.Length - 1; i++)
        {
            perimeter += LengthSide(points[i], points[i + 1]);
        }
        perimeter += LengthSide(points[points.Length - 1], points[0]);
        Console.WriteLine($"Периметр багатокутника: {perimeter}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Point A = new Point(0, 0, "A");
        Point B = new Point(3, 0, "B");
        Point C = new Point(3, 4, "C");
        Point D = new Point(0, 4, "D");
        Figure figure = new Figure(A, B, C, D);
        figure.PerimeterCalculator();
    }
}
