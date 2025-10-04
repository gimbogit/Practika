namespace _4._1
{
    
    public interface IFigure
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    
    public class Circle : IFigure
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть положительным");
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    
    public class Rectangle : IFigure
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Стороны должны быть положительными");
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }
    }

    
    public class Triangle : IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны должны быть положительными");

            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("Треугольник с такими сторонами не существует");

            SideA = a;
            SideB = b;
            SideC = c;
        }

        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public double CalculateArea()
        {
            
            double p = CalculatePerimeter() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
    


    class Program
    {
        static void Main()
        {
            
            while (true)
            {
                
                IFigure[] figures = {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5)
        };

                foreach (var figure in figures)
                {
                    Console.WriteLine($"Тип: {figure.GetType().Name}");
                    Console.WriteLine($"Площадь: {figure.CalculateArea():F2}");
                    Console.WriteLine($"Периметр: {figure.CalculatePerimeter():F2}\n");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    }
