using System;

namespace InterfaceNameClash
{
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        // Явно привязать реализации Draw() к конкретным интерфейсам
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Рисует восьмиугольник в форме");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Рисует восьмиугольник в памяти");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Рисует восьмиугольник на принтере");
        }
    }
}
