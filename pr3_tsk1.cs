using System;

class Book
{
    private readonly string title;
    private string author;
    private string content;

    public Book(string title, string author, string content)
    {
        this.title = title;
        this.author = author;
        this.content = content;
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Title: {title}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Author: {author}");
        Console.ResetColor();
        Console.WriteLine($"Content: {content}");
    }

    public string GetTitle()
    {
        return title;
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string Content
    {
        get { return content; }
        set { content = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book("топ 10 сумних hello world!", "Vladysalv Kysil", "можу розказать анекдот про тумбачку...");

        book.Show();

        Console.WriteLine("\nпісля зміни:");
        book.Author = "Vlad KYsil";
        book.Content = "0_0";

        book.Show();
    }
}
