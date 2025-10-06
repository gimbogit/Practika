using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _5._1
{
    public partial class Form1 : Form
    {
        public enum DrawMode { Line, Circle, Rectangle }
        private DrawMode currentMode = DrawMode.Line;
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing = false;
        private List<Shape> shapes = new List<Shape>();
        private Pen drawingPen = new Pen(Color.Black, 2);
        private ColorDialog colorDialog = new ColorDialog();

        public Form1()
        {
            InitializeComponent();
            SetupEventHandlers();
            this.DoubleBuffered = true;
        }

        private void SetupEventHandlers()
        {
            btnLine.Click += (s, e) => currentMode = DrawMode.Line;
            btnCircle.Click += (s, e) => currentMode = DrawMode.Circle;
            btnRectangle.Click += (s, e) => currentMode = DrawMode.Rectangle;
            btnClear.Click += (s, e) => { shapes.Clear(); this.Invalidate(); };
            btnColor.Click += BtnColor_Click;
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingPen.Color = colorDialog.Color;
                panelColor.BackColor = colorDialog.Color;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                isDrawing = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;

                Shape newShape = new Shape(currentMode, startPoint, endPoint, drawingPen.Color);
                shapes.Add(newShape);

                isDrawing = false;
                this.Invalidate();
            }
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Рисуем все сохраненные фигуры
            for (int i = 0; i < shapes.Count; i++)
            {
                DrawShape(e.Graphics, shapes[i]);
            }

            // Рисуем текущую фигуру (предпросмотр)
            if (isDrawing)
            {
                Shape tempShape = new Shape(currentMode, startPoint, endPoint, drawingPen.Color);
                DrawShape(e.Graphics, tempShape);
            }

            base.OnPaint(e);
        }

        private void DrawShape(Graphics g, Shape shape)
        {
            using (Pen shapePen = new Pen(shape.ShapeColor, 2))
            {
                Point start = shape.StartPoint;
                Point end = shape.EndPoint;

                switch (shape.Type)
                {
                    case DrawMode.Line:
                        g.DrawLine(shapePen, start, end);
                        break;
                    case DrawMode.Circle:
                        int circleWidth = Math.Abs(end.X - start.X);
                        int circleHeight = Math.Abs(end.Y - start.Y);
                        int circleX = start.X < end.X ? start.X : end.X;
                        int circleY = start.Y < end.Y ? start.Y : end.Y;
                        g.DrawEllipse(shapePen, circleX, circleY, circleWidth, circleHeight);
                        break;
                    case DrawMode.Rectangle:
                        int rectSize = GetMinSize(Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
                        int rectX = start.X < end.X ? start.X : start.X - rectSize;
                        int rectY = start.Y < end.Y ? start.Y : start.Y - rectSize;
                        g.DrawRectangle(shapePen, rectX, rectY, rectSize, rectSize);
                        break;
                }
            }
        }

        private int GetMinSize(int a, int b)
        {
            return a < b ? a : b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Дополнительная инициализация при загрузке формы
        }
    }

    public class Shape
    {
        public Form1.DrawMode Type { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color ShapeColor { get; set; }

        public Shape(Form1.DrawMode type, Point start, Point end, Color color)
        {
            Type = type;
            StartPoint = start;
            EndPoint = end;
            ShapeColor = color;
        }
    }
}