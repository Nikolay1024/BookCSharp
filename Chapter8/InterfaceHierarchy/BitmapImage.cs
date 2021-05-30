using System;

namespace InterfaceHierarchy
{
    class BitmapImage : IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Рисует");
        }
        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Рисует в рамке");
        }
        public void DrawUpsideDown()
        {
            Console.WriteLine("Рисует вверх ногами");
        }
    }
}
