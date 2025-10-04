namespace _4._5
{
    public interface IDrawing
    {
        void DrawLine(int x1, int y1, int x2, int y2);        
        void DrawCircle(int x, int y, int radius);             
        void DrawRectangle(int x, int y, int width, int height); 
    }

   
    public class Canvas : IDrawing
    {
        private List<string> shapes;

        public Canvas()
        {
            shapes = new List<string>();
            Console.WriteLine("Холст создан");
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            string line = $"Линия от ({x1},{y1}) до ({x2},{y2})";
            shapes.Add(line);
            Console.WriteLine($"Нарисована: {line}");
        }

        public void DrawCircle(int x, int y, int radius)
        {
            string circle = $"Круг в точке ({x},{y}) радиусом {radius}";
            shapes.Add(circle);
            Console.WriteLine($"Нарисован: {circle}");
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            string rectangle = $"Прямоугольник в ({x},{y}) размером {width}x{height}";
            shapes.Add(rectangle);
            Console.WriteLine($"Нарисован: {rectangle}");
        }

        
        public void DisplayAllShapes()
        {
            Console.WriteLine("\nВсе фигуры на холсте:");
            Console.WriteLine("======================");

            if (shapes.Count == 0)
            {
                Console.WriteLine("Холст пуст");
                return;
            }

            for (int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {shapes[i]}");
            }
        }

       
        public void ClearCanvas()
        {
            shapes.Clear();
            Console.WriteLine("Холст очищен");
        }
    }

    
    class Program
    {
        static void Main()
        {
            
            Canvas canvas = new Canvas();

            
            Console.WriteLine("\nПроцесс рисования:");
            Console.WriteLine("===================");

            
            IDrawing drawing = canvas;

            drawing.DrawLine(0, 0, 100, 100);
            drawing.DrawCircle(50, 50, 25);
            drawing.DrawRectangle(10, 10, 80, 60);
            drawing.DrawLine(100, 100, 200, 50);
            drawing.DrawCircle(150, 75, 30);

            
            canvas.DisplayAllShapes();

            
            Console.WriteLine("\nОчистка холста:");
            Console.WriteLine("================");
            canvas.ClearCanvas();
            canvas.DisplayAllShapes();

           
            Console.WriteLine("\nРисуем заново:");
            Console.WriteLine("==============");
            drawing.DrawRectangle(5, 5, 50, 30);
            drawing.DrawCircle(25, 25, 15);
            canvas.DisplayAllShapes();
        }
    }
}
