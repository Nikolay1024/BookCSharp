namespace ConstDataApp
{
    class MyMathClass
    {
        public const double PI = 3.14;
        public readonly double TAU;
        public static readonly double E;

        public MyMathClass()
        {
            TAU = PI * 2;
        }
        static MyMathClass()
        {
            E = 2.72;
        }
    }
}