using System;
using System.Numerics;

namespace BasicDataTypes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("BasicDataTypes Application.\n\r");
            LocalVarDeclarations();
            DefaultDeclarations();
            NewingDataTypes();
            ObjectFunctionality();
            DataTypeFunctionality();
            ParseFromString();
            TryParseFromString();
            UseDateTime();
            UseBiglnteger();
            DigitSeparators();
            BinaryLiterals();
            Console.ReadKey();
        }

        static void LocalVarDeclarations()
        {
            Console.WriteLine("=> Объявление и инициализация переменных:");
            int myInt = 0;
            string myString;
            myString = "Строка символов";
            bool bl = true, b2 = false, bЗ = bl;
            System.Boolean b4 = false;
            Console.WriteLine("   Переменные: {0}, {1}, {2}, {3}, {4}, {5}",
            myInt, myString, bl, b2, bЗ, b4);
            Console.WriteLine();
        }
        static void DefaultDeclarations()
        {
            Console.WriteLine("=> Инициализация значением по умолчанию:");
            bool myBool = default;
            int myInt = default;
            double myDouble = default;
            DateTime myDateTime = default;
            Console.WriteLine("   {0} - myBool, {1} - myInt, {2} - myDouble, {3} - myDateTime",
                myBool, myInt, myDouble, myDateTime);
            Console.WriteLine();
        }
        static void NewingDataTypes()
        {
            Console.WriteLine("=> Инициализация с помощью ключевого слова new:");
            bool myBool = new bool();
            int myInt = new int();
            double myDouble = new double();
            DateTime myDateTime = new DateTime();
            Console.WriteLine("   {0} - myBool, {1} - myInt, {2} - myDouble, {3} - myDateTime",
                myBool, myInt, myDouble, myDateTime);
            Console.WriteLine();
        }
        static void ObjectFunctionality()
        {
            Console.WriteLine("=> System.Object функциональность:");
            Console.WriteLine("   int.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("   int.Equals(obj) = {0}", 12.Equals(23));
            Console.WriteLine("   int.ToString() = {0}", 12.ToString());
            Console.WriteLine("   int.GetType() = {0}", 12.GetType());
            Console.WriteLine();
        }
        static void DataTypeFunctionality()
        {
            Console.WriteLine("=> Функциональность типов данных:");
            Console.WriteLine("   int.MaxValue: {0}", int.MaxValue);
            Console.WriteLine("   int.MinValue: {0}", int.MinValue);
            Console.WriteLine("   double.MaxValue: {0}", double.MaxValue);
            Console.WriteLine("   double.MinValue: {0}", double.MinValue);
            Console.WriteLine("   double.Epsilon (бесконечно малая величина): {0}", double.Epsilon);
            Console.WriteLine("   double.PositiveInfinity (бесконечно большая величина): {0}", double.PositiveInfinity);
            Console.WriteLine("   double.Negativelnfinity (бесконечно большая величина): {0}", double.NegativeInfinity);
            Console.WriteLine("   bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("   bool.TrueString: {0}", bool.TrueString);
            Console.WriteLine("   char.IsDigit('1') : {0}", char.IsDigit('1'));
            Console.WriteLine("   char.IsLetter('a') : {0}", char.IsLetter('a'));
            Console.WriteLine("   char.IsWhiteSpace(\\n): {0}", char.IsWhiteSpace('\n'));
            Console.WriteLine("   char.IsWhiteSpace(\"01234 67\", 5): {0}", char.IsWhiteSpace("01234 67", 5));
            Console.WriteLine("   char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
            Console.WriteLine();
        }
        static void ParseFromString()
        {
            Console.WriteLine("=> Структурный разбор Parse():");
            Console.WriteLine("   bool.Parse(True): {0} ", bool.Parse("True"));
            Console.WriteLine("   int.Parse(8): {0}", int.Parse("8"));
            Console.WriteLine("   double.Parse(9,4): {0}", double.Parse("9,4"));
            Console.WriteLine("   char.Parse(w): {0} ", char.Parse("w"));
            Console.WriteLine();
        }
        static void TryParseFromString()
        {
            Console.WriteLine("=> Обработка исключения структурного разбора TryParse():");
            string value = "Hello";
            if (double.TryParse(value, out double d))
                Console.WriteLine("   Значение double: {0}", d);
            else
            {
                Console.WriteLine("   Преобразование \"{0}\" в double потерпело неудачу.", value);
                Console.WriteLine("   Переменной d присвоено стандартное значение типа double: {0}.", d);
            }
            Console.WriteLine();
        }
        static void UseDateTime()
        {
            Console.WriteLine("=> Дата и время:");
            DateTime dt = new DateTime(2020, 12, 31);
            Console.WriteLine("   Год: {0}, месяц {1}, день {2}.", dt.Year, dt.Month, dt.Day);
            Console.WriteLine("   Через 2 месяца после {0:MMMM} будет {1:MMMM}.", dt, dt.AddMonths(2));
            Console.WriteLine("   Является ли {0:d} летним временем? {1}", dt, dt.IsDaylightSavingTime());
            TimeSpan ts = new TimeSpan(23, 0, 0);
            Console.WriteLine("   {0}", ts);
            TimeSpan sub = new TimeSpan(0, 0, 1);
            Console.WriteLine("   {0} - {1} = {2}", ts, sub, ts.Subtract(sub));
        }
        static void UseBiglnteger()
        {
            Console.WriteLine("=> Использование Biglnteger:");
            BigInteger big = BigInteger.Parse("9999999999999999999999999999999999999999999999");
            Console.WriteLine("   Значение big: {0}", big);
            Console.WriteLine("   {0} четное число? {1}", big, big.IsEven);
            Console.WriteLine("   {0} является ли степенью числа 2? {0}", big.IsPowerOfTwo);
            BigInteger big2 = BigInteger.Parse("8888888888888888888888888888888888888888888");
            Console.WriteLine("   {0} *\n\r   * {1} =\n\r   = {2}", big, big2, BigInteger.Multiply(big, big2));
            Console.WriteLine("   {0} *\n\r   * {1} =\n\r   = {2}", big2, big, big2 * big);
            Console.WriteLine();
        }
        static void DigitSeparators()
        {
            Console.WriteLine("=> Разделители групп цифр:");
            Console.WriteLine("   123_456 = {0}", 123_456);
            Console.WriteLine("   123_456_789L = {0}", 123_456_789L);
            Console.WriteLine("   123_456.1234F = {0}", 123_456.1234F);
            Console.WriteLine("   123_456.12 = {0}", 123_456.12);
            Console.WriteLine("   123_456.12M = {0}", 123_456.12M);
            Console.WriteLine();
        }
        static void BinaryLiterals()
        {
            Console.WriteLine("=> Двоичные литералы:");
            Console.WriteLine("   0b0001_0000 = {0}", 0b0001_0000);
            Console.WriteLine("   0b0010_0000 = {0}", 0b0010_0000);
            Console.WriteLine("   0b0100_0000 = {0}", 0b0100_0000);
            Console.WriteLine();
        }
    }
}
