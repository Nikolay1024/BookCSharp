namespace GenericPoint
{
    // Обобщенная структура Point.
    public struct Point<T>
    {
        // Обобщенные свойства.
        public T X { get; set; }
        public T Y { get; set; }
        // Обобщенный конструктор.
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }
        public override string ToString() => $"[{X}; {Y}]";
        // Сбросить поля в стандартные значения для заданного параметра типа.
        public void ResetPoint()
        {
            X = default;
            Y = default;
        }
    }
}
