namespace DynamicKeyword
{
    class VeryDynamicClass
    {
        // Динамическое поле.
        static dynamic myDynamicField;
        // Динамическое свойство.
        public dynamic DynamicProperty { get; set; }
        // Динамический тип возврата и динамический тип параметра.
        public dynamic DynamicMethod(dynamic dynamicParam)
        {
            // Динамическая локальная переменная.
            dynamic dynamicLocalVar = "Local variable";
            int myInt = 10;
            if (dynamicParam is int)
                return dynamicLocalVar;
            else
                return myInt;
        }
    }
}
