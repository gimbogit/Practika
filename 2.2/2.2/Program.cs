namespace _2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(4,7);

            double areaC = circle.Area();
            double perimeterC = circle.Perimeter();

            Console.WriteLine($"Площадь круга:{areaC}");
            Console.WriteLine($"Периметр круга: {perimeterC}");

            double areaR = rectangle.Area();
            double perimeterR = rectangle.Perimeter();

            Console.WriteLine($"Площадь прямоугольника:{areaR}");
            Console.WriteLine($"Периметр круга: {perimeterR}");
        }
        class Shape
        {
            public virtual double Area() 
            {
                return 0;
            }
            public virtual double Perimeter()
            {
                return 0;
            }
        }
        class Circle : Shape 
        {
            private int _radius;

            public Circle(int radius)
            {
                _radius = radius;
            }
            public override double Area()
            {
                return Math.PI * _radius* _radius ;
                
            }
            public override double Perimeter()
            {
                return 2 * Math.PI * _radius; 
            }
        }
        class Rectangle : Shape
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
            public override double Perimeter()
            {
                return 2* (_height+_width);
            }
        }   
    }
}
