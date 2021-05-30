using System;
using System.Text;

namespace StringApp
{
    class Program
    {
        static void Main()
        {
            StringMethods();
            EscapeChars();
            StringEquality();
            StringEqualityCompareRules();
            StringIsImmutable();
            StringBuilderMethod();
            StringInterpolation();
            Console.ReadKey();
        }

        static void StringMethods()
        {
            Console.WriteLine("=> Функциональность строк:");
            string firstName = "Николай";
            Console.WriteLine("Имя: {0}", firstName);
            Console.WriteLine("В имени {0} символов.", firstName.Length);
            Console.WriteLine("Имя в верхнем регистре: {0}", firstName.ToUpper());
            Console.WriteLine("Имя в нижнем регистре: {0}", firstName.ToLower());
            Console.WriteLine("Имя содержит символ 'й'? {0}", firstName.Contains("й"));
            Console.WriteLine("Имя после замены \"лай\": {0}", firstName.Replace("лай", ""));
            Console.WriteLine("Конкатенация строк: {0}", firstName + " Андреевич");
            Console.WriteLine("Конкатенация строк: {0}", String.Concat("Зоринов ", firstName));
            Console.WriteLine();
        }
        static void EscapeChars()
        {
            Console.WriteLine("=> Управляющие последовательности:");
            Console.WriteLine("Одинарная кавычка - \'");
            Console.WriteLine("Двойная кавычка - \"");
            Console.WriteLine("Обратная косая черта - \\");
            Console.WriteLine("Null\0");
            Console.WriteLine("Предупреждение\a");
            Console.WriteLine("Backspace***\b\b\b   ");
            Console.WriteLine("Перевод страницы\f");
            Console.WriteLine("Новая строка\n");
            Console.WriteLine("***Возврат каретки\r   ");
            Console.WriteLine("Горизонтальная\tтабуляция");
            Console.WriteLine("Вертикальная\vтабуляция");
            Console.WriteLine("Escape-последовательность Юникода (UTF-16) - \u00A7");
            Console.WriteLine("Escape-последовательность Юникода (UTF-32) - \U0001F98A'");
            Console.WriteLine("Escape-последовательность Юникода отличается длиной переменной - \x00A7, \x0A7, \xA7");
            Console.WriteLine(@"Дословная строка С:\Users\Николай\Documents");
            Console.WriteLine(@"Я сказал: ""Мои документы в С:\Users\Николай\Documents""");
            Console.WriteLine();
        }
        static void StringEquality()
        {
            Console.WriteLine("=> Сравнение строк:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo!.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine("String.Compare(s1, s1): {0}", String.Compare(s1, s1));
            Console.WriteLine("String.Compare(s1, s2): {0}", String.Compare(s1, s2));
            Console.WriteLine("String.Compare(s2, s1): {0}", String.Compare(s2, s1));
            Console.WriteLine();
        }
        static void StringEqualityCompareRules()
        {
            Console.WriteLine("=> Равенство строк без учета регистра (StringComparison)");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            Console.WriteLine("Правила по умолчанию: s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));
            Console.WriteLine("Без учета регистра:");
            Console.WriteLine("   s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase): {0}",
                s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine("Без учета регистра, со стандартной культурой:");
            Console.WriteLine("   s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}",
                s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
            Console.WriteLine("Правила по умолчанию: s1.IndexOf(\"E\"): {1}", s1, s1.IndexOf("E"));
            Console.WriteLine("Без учета регистра:");
            Console.WriteLine("   s1.IndexOf(\"E\", StringComparison.CurrentCultureIgnoreCase): {0}",
                s1.IndexOf("E", StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine("Без учета регистра, со стандартной культурой:");
            Console.WriteLine("   s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}",
                s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
        }
        static void StringIsImmutable()
        {
            string s2 = "My other string";
            s2 = "New string value";
        }
        static void StringBuilderMethod()
        {
            Console.WriteLine("=> Использование StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 256);
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb содержит {0} символов.", sb.Length);
            Console.WriteLine();
        }
        static void StringInterpolation()
        {
            int age = 24;
            string name = "Николай";
            DateTime dt = DateTime.Now;
            // Использование синтаксиса с фигурными скобками
            string greeting = string.Format("Привет, {0}. Тебе {1} года.\n\rДата: {2,12:d}.",
                name.ToUpper(), age, dt);
            Console.WriteLine(greeting);
            // Использование интерполяции строк
            string greeting2 = $"Привет, {name.ToUpper()}. Тебе {age} года.\n\rДата: {dt,12:d}.";
            Console.WriteLine(greeting2);
        }
    }
}