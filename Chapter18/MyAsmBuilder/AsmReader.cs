using System;
using System.Reflection;
using System.Reflection.Emit;

namespace MyAsmBuilder
{
    class AsmReader
    {
        static void Main()
        {
            Console.WriteLine("=> Выпуск динамической сборки");
            // Получить домен приложения для текущего потока.
            AppDomain currentAppDomain = AppDomain.CurrentDomain;
            Console.WriteLine("-> Создание динамической сборки MyAssembly.dll.");
            CreateMyAsm(currentAppDomain);
            
            Console.WriteLine("-> Загрузка динамической сборки MyAssembly.dll из файла.");
            Assembly asm = Assembly.Load("MyAssembly");
            // Получить тип HelloWorld.
            Type hello = asm.GetType("MyAssembly.HelloWorld");
            // Создать объект HelloWorld и вызвать специальный конструктор.
            Console.Write("-> Введите сообщение для передачи классу HelloWorld: ");
            string msg = Console.ReadLine();
            object[] ctorArgs = new object[] { msg };
            object obj = Activator.CreateInstance(hello, ctorArgs);

            Console.WriteLine("-> Вызов SayHello() через позднее связывание.");
            MethodInfo mi = hello.GetMethod("SayHello");
            mi.Invoke(obj, null);

            Console.WriteLine("-> Вызов GetMsg() через позднее связывание.");
            mi = hello.GetMethod("GetMsg");
            Console.WriteLine(mi.Invoke(obj, null));
            Console.ReadKey();
        }

        // Объект AppDomain отправляется вызывающим кодом.
        public static void CreateMyAsm(AppDomain currentAppDomain)
        {
            // Установить общие характеристики сборки.
            AssemblyName assemblyName = new AssemblyName
            {
                Name = "MyAssembly",
                Version = new Version("1.0.0.0")
            };
            // Создать новую сборку внутри текущего домена приложения.
            AssemblyBuilder dynamicAsm = currentAppDomain.DefineDynamicAssembly(
                assemblyName, AssemblyBuilderAccess.Save);
            // Поскольку строится однофайловая сборка, имя модуля будет таким же, как у сборки.
            ModuleBuilder module = dynamicAsm.DefineDynamicModule("MyAssembly", "MyAssembly.dll");
            // Определить открытый класс по имени HelloWorld.
            TypeBuilder helloWorldClass = module.DefineType(
                "MyAssembly.HelloWorld", TypeAttributes.Public);
            // Определить закрытую переменную-член типа String по имени theMessage.
            FieldBuilder msgField = helloWorldClass.DefineField(
                "theMessage", typeof(string), FieldAttributes.Private);
            // Создать специальный конструктор.
            Type[] paramTypes = new Type[] { typeof(string) };
            ConstructorBuilder ctor = helloWorldClass.DefineConstructor(
                MethodAttributes.Public, CallingConventions.Standard, paramTypes);
            ILGenerator ctorIL = ctor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);
            ConstructorInfo baseCtor = (typeof(object)).GetConstructor(new Type[0]);
            ctorIL.Emit(OpCodes.Call, baseCtor);
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Ldarg_1);
            ctorIL.Emit(OpCodes.Stfld, msgField);
            ctorIL.Emit(OpCodes.Ret);
            // Создать стандартный конструктор.
            helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);
            // Создать метод GetMsg().
            MethodBuilder getMsgMethod = helloWorldClass.DefineMethod(
                "GetMsg", MethodAttributes.Public, typeof(string), null);
            ILGenerator methodIL = getMsgMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, msgField);
            methodIL.Emit(OpCodes.Ret);
            // Создать метод SayHello().
            MethodBuilder sayHiMethod = helloWorldClass.DefineMethod(
                "SayHello", MethodAttributes.Public, null, null);
            methodIL = sayHiMethod.GetILGenerator();
            methodIL.EmitWriteLine("Hello from the HelloWorld class!");
            methodIL.Emit(OpCodes.Ret);
            // Выпустить класс HelloWorld.
            helloWorldClass.CreateType();
            // (Дополнительно) сохранить сборку в файле.
            dynamicAsm.Save("MyAssembly.dll");
        }
    }
}
