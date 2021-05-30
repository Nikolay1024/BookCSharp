using System;

namespace ObjectInitializers
{
    class Rectangle
    {
        public Point TopLeft { get; set; } = new Point();
        public Point BottomRight { get; set; } = new Point();

        public void DisplayStats()
        {
            Console.WriteLine("Rectangle");
            Console.Write("TopLeft: ");
            TopLeft.DisplayStats();
            Console.Write("BottomRight: ");
            BottomRight.DisplayStats();
        }
    }
}
