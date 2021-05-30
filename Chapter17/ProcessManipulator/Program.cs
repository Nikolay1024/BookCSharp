using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProcessManipulator
{
    class Program
    {
        static void Main()
        {
            ListAllRunningProcesses();
            GetProcessByPID();
            EnumThreadsForPID();
            EnumModulesForPID();
            StartAndKillProcess();
            Console.ReadKey();
        }

        static void ListAllRunningProcesses()
        {
            Console.WriteLine("=> Перечисление выполняющихся процессов");
            // Получить все процессы на локальной машине, упорядоченные по PID.
            IEnumerable<Process> processes = from proc in Process.GetProcesses(".")
                                             orderby proc.Id
                                             select proc;
            foreach (Process proc in processes)
                Console.WriteLine("PID: {0,-7}Process name: {1}", proc.Id, proc.ProcessName);
            Console.WriteLine();
        }
        static void GetProcessByPID()
        {
            Console.WriteLine("=> Получение процесса по PID");
            try
            {
                Process proc = Process.GetProcessById(987);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
        static void EnumThreadsForPID()
        {
            Console.WriteLine("=> Получение набора потоков процесса");
            Console.Write("Введите PID: ");
            int pid = int.Parse(Console.ReadLine());
            Process proc;
            try
            {
                proc = Process.GetProcessById(pid);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return;
            }
            Console.WriteLine("Потоки выполняющиеся в процессе: {0}", proc.ProcessName);
            ProcessThreadCollection threads = proc.Threads;
            foreach (ProcessThread thread in threads)
            {
                Console.WriteLine("Thread ID: {0,-7}Start Time: {1,-7}Priority: {2}",
                    thread.Id, thread.StartTime.ToShortTimeString(), thread.PriorityLevel);
            }
            Console.WriteLine();
        }
        static void EnumModulesForPID()
        {
            Console.WriteLine("=> Получение набора модулей процесса");
            Console.Write("Введите PID: ");
            int pid = int.Parse(Console.ReadLine());
            Process proc;
            try
            {
                proc = Process.GetProcessById(pid);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return;
            }
            Console.WriteLine("Модули загруженные процессом: {0}", proc.ProcessName);
            ProcessModuleCollection modules = proc.Modules;
            foreach (ProcessModule module in modules)
                Console.WriteLine("Module name: {0}", module.ModuleName);
            Console.WriteLine();
        }
        static void StartAndKillProcess()
        {
            Process proc;
            try
            {
                proc = Process.Start("notepad.exe");
                ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                proc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.Write("Нажмите клавишу, чтобы завершить процесс: {0}", proc.ProcessName);
            Console.ReadLine();
            try
            {
                proc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
    }
}
