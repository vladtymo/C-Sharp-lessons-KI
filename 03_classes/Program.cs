using System;

namespace _03_classes
{
    // Access Specificators
    /*
     * private (default for fields, methods...)
     * protected 
     * internal - access from assembly (default for classes)
     * protected internal
     * public
     */
    public class Rectangle
    {
        // ---------------------- Fields ----------------------
        private float height;
        private float width;
        private char symbol;

        // ---------------------- Properties ----------------------
        // (field + getter & setter)
        public float Width
        {
            get { return width; }
            set 
            { 
                if (value > 0)    
                    width = value; 
            }
        }
        // ---------------------- Readonly Property ----------------------
        //public double Area
        //{
        //    get { return height * width; }
        //}
        public double Area => height * width;

        // ---------------------- Full Property ----------------------
        // snippet: propfull
        //private ConsoleColor color;
        //public ConsoleColor Color
        //{
        //    get { return color; }
        //    set { color = value; }
        //}

        // ---------------------- Auto Property ----------------------
        // snippet: prop
        public ConsoleColor Color { get; set; }

        // setter & setter 
        public void SetWidth(float w)
        {
            if (w > 0)
                this.width = w;
        }
        public float GetWidth()
        {
            return this.width;
        }

        // constructors
        public Rectangle(float h, float w, char s, ConsoleColor c)
        {
            this.width = w;
            this.height = h;
            this.symbol = s;
            this.Color = c;
        }

        // methods
        public void Show()
        {
            Console.ForegroundColor = Color;

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ResetColor();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 7, '@', ConsoleColor.Magenta); // constructor

            //rect.height = 5;
            //rect.width = 7;
            //rect.color = ConsoleColor.Magenta;
            //rect.symbol = '@';

            rect.Show();

            rect.SetWidth(-20);
            float w = rect.GetWidth();

            rect.Width = 12;
            w = rect.Width;

            rect.Show();

            rect.Show();

            Console.WriteLine("Area: " + rect.Area);
        }
    }
}
