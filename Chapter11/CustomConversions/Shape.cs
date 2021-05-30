using System;

namespace CustomConversions
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }
        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        public override string ToString()
            => $"[Width = {Width}; Height = {Height}]";

        // Square можно неявно преобразовывать в Rectangle.
        public static implicit operator Rectangle(Square sq)
            => new Rectangle(sq.Length, sq.Length * 2);
    }

    public struct Square
    {
        public int Length { get; set; }
        public Square(int l) : this()
        {
            Length = l;
        }
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        public override string ToString()
            => $"[Length = {Length}]";

        // Rectangle можно явно преобразовывать в Square.
        public static explicit operator Square(Rectangle rect)
            => new Square(rect.Height);
        // Int можно явно преобразовывать в Square.
        public static explicit operator Square(int l)
            => new Square(l);
        // Square можно явно преобразовывать в Int.
        public static explicit operator int(Square sq)
            => sq.Length;
    }
}
