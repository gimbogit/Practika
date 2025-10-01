using System;

interface IDrawable
{
    void Draw();
}

class Circle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Создается круг ");
    }
}

class Rectangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Создается прямоугольник");
    }
}

class Triangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Создается Треугольник");
    }
}

class Program
{
    static void Main()
    {
        IDrawable[] shapes = new IDrawable[]
        {
            new Circle(),
            new Rectangle(),
            new Triangle()
        };

        foreach (IDrawable shape in shapes)
        {
            shape.Draw();
        }
    }
}
