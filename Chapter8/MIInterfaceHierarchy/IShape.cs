namespace MIInterfaceHierarchy
{
    interface IDrawable
    {
        void Draw();
    }
    interface IPrintable
    {
        void Print();
        void Draw(); // <-- Возможен конфликт имен!
    }

    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
