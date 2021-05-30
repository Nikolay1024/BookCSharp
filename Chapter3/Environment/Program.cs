using System;

namespace EnvironmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вспомогательный метод внутри класса Program.
            ShowEnvironmentDetails();
            Console.ReadLine();
        }

        private static void ShowEnvironmentDetails()
        {
            // Properties
            Console.WriteLine("************************СВОЙСТВА************************");
            Console.WriteLine("1) Текущая директория: {0}", Environment.CurrentDirectory);
            Console.WriteLine("2) Количество процессоров: {0}", Environment.ProcessorCount);
            Console.WriteLine("3) Командная строка и аргументы для текущего процесса: {0}", Environment.CommandLine);
            Console.WriteLine("4) Код выхода: {0}", Environment.ExitCode);
            Console.WriteLine("5) Время с момента загрузки ОС (мс): {0}", Environment.TickCount);
            Console.WriteLine("6) Количество памяти на странице ОС (байт): {0}", Environment.SystemPageSize);
            Console.WriteLine("7) Символ новой строки ОС: {0}", Environment.NewLine);
            Console.WriteLine("8) Версия среды CLR: {0}", Environment.Version);
            Console.WriteLine("9) Объем физической памяти процесса (байт): {0}", Environment.WorkingSet);
            Console.WriteLine("10) ОС: {0}", Environment.OSVersion);
            Console.WriteLine("11) Сведения о трассировке стека:\r\n{0}", Environment.StackTrace);
            Console.WriteLine("12) Текущий процесс 64-разрядный? {0}", Environment.Is64BitProcess);
            Console.WriteLine("13) Текущая ОС 64-разрядная? {0}", Environment.Is64BitOperatingSystem);
            Console.WriteLine("14) CLR завершает работу (нет доступа к статическим членам)? {0}", Environment.HasShutdownStarted);
            Console.WriteLine("15) Пользователь ОС: {0}", Environment.UserName);
            Console.WriteLine("16) Выполняется ли текущий процесс в режиме взаимодействия с пользователем? {0}", Environment.UserInteractive);
            Console.WriteLine("17) Имя сетевого домена, связанное с текущим пользователем: {0}", Environment.UserDomainName);
            Console.WriteLine("18) Уникальный идентификатор текущего управляемого потока: {0}", Environment.CurrentManagedThreadId);
            Console.WriteLine("19) Полный путь к системному каталогу: {0}", Environment.SystemDirectory);
            Console.WriteLine("20) Имя NetBIOS данного локального компьютера: {0}", Environment.MachineName);
            Console.WriteLine();

            // Methods
            Console.WriteLine("************************МЕТОДЫ************************");
            Console.WriteLine("1) Завершает процесс и возвращает код выхода ОС: System.Environment.Exit(int)");

            Console.WriteLine("2) Замещает имена переменных среды, значением переменных:");
            Console.WriteLine(Environment.ExpandEnvironmentVariables("   Диск корневого каталога Windows - %SystemDrive%"));
            Console.WriteLine(Environment.ExpandEnvironmentVariables("   Путь до системной папки - %SystemRoot%"));

            Console.WriteLine("3) Завершает процесс, записывает сообщение в журнал событий приложений Windows,");
            Console.WriteLine("   отправляет отчет об ошибках в Майкрософт: System.Environment.FailFast(string, Exception)");

            Console.WriteLine("4) Возвращает аргументы командной строки для текущего процесса\r\n   {0}",
                String.Join("\r\n   ", Environment.GetCommandLineArgs()));

            Console.WriteLine("5) Возвращает значение переменной среды");
            Console.WriteLine("   для процесса: {0}", Environment.GetEnvironmentVariable("Temp", EnvironmentVariableTarget.Process));
            Console.WriteLine("   для пользователя: {0}", Environment.GetEnvironmentVariable("Temp", EnvironmentVariableTarget.User));
            Console.WriteLine("   для компьютера: {0}", Environment.GetEnvironmentVariable("Temp", EnvironmentVariableTarget.Machine));

            Console.WriteLine("6) Возвращает путь к особой папке, используя заданный параметр для доступа: {0}",
                String.Join(", ", Environment.GetFolderPath(Environment.SpecialFolder.Desktop, Environment.SpecialFolderOption.None)));

            Console.WriteLine("7) Логические диски: {0}", String.Join(", ", Environment.GetLogicalDrives()));

            Console.WriteLine("8) Создает, изменяет или удаляет переменную среды для процесса, пользователя или компьютера:");
            //Создает или изменяет переменную среды
            Environment.SetEnvironmentVariable("Test", @"C:\Users\Николай\AppData\Local\Temp\Test", EnvironmentVariableTarget.Process);
            Console.WriteLine(Environment.GetEnvironmentVariable("Test", EnvironmentVariableTarget.Process));
            //Удаляет переменную среды
            Environment.SetEnvironmentVariable("Test", null, EnvironmentVariableTarget.Process);

            Console.WriteLine("9) Возвращает имена и значения всех переменных среды");
            Console.WriteLine("************************для процесса************************");
            var var = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
            foreach (var key in var.Keys)
            {
                Console.WriteLine("   {0} - {1}", key.ToString(), var[key].ToString());
            }
            Console.WriteLine("************************для пользователя************************");
            var = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
            foreach (var key in var.Keys)
            {
                Console.WriteLine("   {0} - {1}", key.ToString(), var[key].ToString());
            }
            Console.WriteLine("************************для компьютера************************");
            var = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
            foreach (var key in var.Keys)
            {
                Console.WriteLine("   {0} - {1}", key.ToString(), var[key].ToString());
            }
        }
    }
}
