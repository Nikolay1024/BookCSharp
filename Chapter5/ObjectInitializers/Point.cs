using System;

namespace ObjectInitializers
{
    class Point
    {
        public enum ColorType
        {
            Blue,
            Red,
            Gold,
        };

        public int X { get; set; }
        public int Y { get; set; }
        public ColorType Color { get; set; }

        public Point() { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(ColorType color)
        {
            Color = color;
        }
        
        public void DisplayStats()
        {
            Console.WriteLine("[{0}; {1}] color: {2}", X, Y, Color);
        }
    }
}
