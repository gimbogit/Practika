namespace _3._1
{
    internal class Program
    {
        delegate double forTwoPar(int width, int height);

        static void Main(string[] args)
        {
           
            forTwoPar operation1 = RectangleArea;
            forTwoPar operation2 = TriangleArea;

            
            forTwoPar operation3 = CircleArea;

           
            double rectArea = operation1(10, 5);
            double triArea = operation2(10, 5);
            double circleArea = operation3(5, 0);
            Console.WriteLine($"Площадь круга {circleArea}");
            Console.WriteLine($"Площадь треугольника {triArea}");
            Console.WriteLine($"Площадь прямоугольника {rectArea}");
        }

        static double RectangleArea(int width, int height)
        {
            return new Rectangle(width, height).Area();
        }

        static double TriangleArea(int width, int height)
        {
            return new Triangle(width, height).Area();
        }

        static double CircleArea(int radius, int ignored)
        {
            return new Circle(radius).Area();
        }

        class Figure
        {
            public virtual double Area()
            {
                return 0;
            }
        }

        class Circle : Figure
        {
            private int _radius;
            public Circle(int radius)
            {
                _radius = radius;
            }
            public override double Area()
            {
                return Math.PI * _radius * _radius;
            }
        }

        class Rectangle : Figure
        {
            private int _width;
            private int _height;

            public Rectangle(int width, int height)
            {
                _width = width;
                _height = height;
            }
            public override double Area()
            {
                return _width * _height;
            }
        }

        class Triangle : Figure
        {
            private int _width;
            private int _height;

            public Triangle(int width, int height)
            {
                _width = width;
                _height = height;
            }
            public override double Area()
            {
                return (_width * _height) / 2.0;
            }
        }
    }
}