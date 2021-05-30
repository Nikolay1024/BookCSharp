using System;

namespace InterfaceHierarchy
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Иерархия интерфейсов");
            BitmapImage myBitmap = new BitmapImage();
            myBitmap.Draw();
            myBitmap.DrawInBoundingBox(10, 10, 100, 150);
            myBitmap.DrawUpsideDown();
            // Получить IAdvancedDraw явным образом.
            if (myBitmap is IAdvancedDraw advancedDraw)
                advancedDraw.DrawUpsideDown();
            Console.ReadKey();
        }
    }
}
