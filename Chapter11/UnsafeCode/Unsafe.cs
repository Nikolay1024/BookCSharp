namespace UnsafeCode
{
    // Эта структура целиком является небезопасной и может
    // использоваться только в небезопасном контексте.
    public unsafe struct Node1
    {
        public int Value;
        public Node1* Left;
        public Node1* Right;
    }

    // Эта структура безопасна, но члены Node2* - нет.
    // Формально извне небезопасного контекста можно
    // обращаться к Value, но не к Left и Right.
    public struct Node2
    {
        public int Value;
        // Эти члены доступны только в небезопасном контексте!
        public unsafe Node2* Left;
        public unsafe Node2* Right;

        public static unsafe void SquareIntPointer(int* myIntPtr)
        {
            // Возвести значение в квадрат просто для тестирования.
            *myIntPtr *= *myIntPtr;
        }
    }
}
