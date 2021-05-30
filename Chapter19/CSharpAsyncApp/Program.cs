using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAsyncApp
{
    class Program
    {
        static readonly int time = 1000;
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static void Main()
        {
            Console.WriteLine("=> Асинхронные вызовы с помощью ключевых слов async/await");
            ReturnVoidAsync();
            Test();
            Console.ReadKey();

            Task task = ReturnTaskAsync();
            // Блокирует текущий поток до завершения асинхронной задачи.
            task.Wait();
            Console.ReadKey();

            Task<string> taskString = ReturnTaskRefTypeAsync();
            // Блокирует текущий поток до получения результата ссылочного типа.
            string myStr = taskString.Result;
            Console.WriteLine("{0}\n\r", myStr);
            Console.ReadKey();

            ValueTask<int> taskInt = ReturnTaskValueTypeAsync();
            // Блокирует текущий поток до получения результата значимого типа.
            int myInt = taskInt.Result;
            Console.WriteLine("{0}\n\r", myInt);
            Console.ReadKey();

            // Последовательное выполнение асинхронных задач.
            SequentialTasksAsync();
            Console.ReadKey();

            // Параллельное выполнение асинхронных задач.
            ParallelTasksAsync();
            Console.ReadKey();

            // Обработка исключения в асинхронном методе.
            TryCatchAsync();
            Console.ReadKey();

            // Обработка нескольких исключений в асинхронном методе.
            TryCatchParallelTasksAsync();
            Console.ReadKey();

            // Вызов асинхронных задач в блоках catch и finally.
            TryCatchFinallyAsync();
            Console.ReadKey();

            // Отмена асинхронных задач.
            CancelTaskAsync(cancelTokenSource.Token);
            Cancel();
            Console.ReadKey();
        }

        static void Test()
        {
            Console.WriteLine("  -> Начало Test()");
            Console.Write("  Первичный поток не заблокирован и позволяет ввести текст асинхронно с работой метода: ");
            Console.WriteLine("  Ваш текст: {0}", Console.ReadLine());
            Console.WriteLine("  -> Конец Test()");
        }
        static async void ReturnVoidAsync()
        {
            Console.WriteLine("-> Начало ReturnVoidAsync()");
            // Ожидает завершения задачи, возвращая управление вызывающему потоку (методу Main()).
            await Task.Run(() =>
            {
                Thread.Sleep(time);
            });
            Console.WriteLine("-> Конец ReturnVoidAsync()\n\r");
        }
        static async Task ReturnTaskAsync()
        {
            Console.WriteLine("-> Начало ReturnTaskAsync()");
            await Task.Run(() =>
            {
                Thread.Sleep(time);
            });
            Console.WriteLine("-> Конец ReturnTaskAsync()\n\r");
        }
        static async Task<string> ReturnTaskRefTypeAsync()
        {
            Console.WriteLine("-> Начало ReturnTaskRefTypeAsync()");
            string result = await Task.Run(() =>
            {
                Thread.Sleep(time);
                return "Сообщение";
            });
            Console.WriteLine("-> Конец ReturnTaskRefTypeAsync()");
            return result;
        }
        // Для работы необходимо установить NuGet-пакет System.Threading.Tasks.Extensions
        static async ValueTask<int> ReturnTaskValueTypeAsync()
        {
            Console.WriteLine("-> Начало ReturnTaskValueTypeAsync()");
            int result = await Task.Run(() =>
            {
                Thread.Sleep(time);
                return 10;
            });
            Console.WriteLine("-> Конец ReturnTaskValueTypeAsync()");
            return result;
        }

        static async void SequentialTasksAsync()
        {
            Console.WriteLine("-> Начало SequentialTasksAsync()");
            await Task.Run(() =>
            {
                Thread.Sleep(time);
                Console.WriteLine("Конец задачи 1");
            });
            await Task.Run(() =>
            {
                Thread.Sleep(time);
                Console.WriteLine("Конец задачи 2");
            });
            await Task.Run(() =>
            {
                Thread.Sleep(time);
                Console.WriteLine("Конец задачи 3");
            });
            Console.WriteLine("-> Конец SequentialTasksAsync()\n\r");
        }
        static async void ParallelTasksAsync()
        {
            Console.WriteLine("-> Начало ParallelTasksAsync()");
            Task t1 = Task.Run(() =>
            {
                Thread.Sleep(time);
                Console.WriteLine("Конец задачи 1");
            });
            Task t2 = Task.Run(() =>
            {
                Thread.Sleep(time);
                Console.WriteLine("Конец задачи 2");
            });
            Task t3 = Task.Run(() =>
            {
                Thread.Sleep(time);
                Console.WriteLine("Конец задачи 3");
            });
            // Создает задачу, которая будет завершена, когда все задачи в массиве будут завершены.
            await Task.WhenAll(new Task[] { t1, t2, t3 });
            Console.WriteLine("-> Конец ParallelTasksAsync()\n\r");
        }
        static async void TryCatchAsync()
        {
            Task task = null;
            try
            {
                task = Task.Run(() =>
                {
                    int a = 0;
                    int b = 10 / a;
                });
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Завершилась ли задача из-за исключения? {0}", task.IsFaulted);
                Console.WriteLine("ex.Message = {0}", ex.Message);
                Console.WriteLine("task.Exception.InnerException.Message = {0}\n\r", task.Exception.InnerException.Message);
            }
        }
        static async void TryCatchParallelTasksAsync()
        {
            Task tasks = null;
            try
            {
                Task t1 = Task.Run(() =>
                {
                    int a = 0;
                    int b = 10 / a;
                });
                Task t2 = Task.Run(() =>
                {
                    int[] arr = null;
                    arr[0] = 0;
                });
                Task t3 = Task.Run(() =>
                {
                    int[] arr = new int[0];
                    arr[0] = 0;
                });
                tasks = Task.WhenAll(new Task[] { t1, t2, t3 });
                await tasks;
            }
            catch (Exception)
            {
                Console.WriteLine("Завершилась ли задача из-за исключения? {0}", tasks.IsFaulted);
                foreach (Exception ex in tasks.Exception.InnerExceptions)
                    Console.WriteLine("Вложенное исключение: {0}", ex.Message);
                Console.WriteLine();
            }
        }
        static async void TryCatchFinallyAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    int a = 0;
                    int b = 10 / a;
                });
            }
            catch (Exception ex)
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("Исключение: {0}", ex.Message);
                    Console.WriteLine("Блок catch завершен");
                });
            }
            finally
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("Блок finally завершен\n\r");
                });
            }
        }

        static void Cancel()
        {
            Console.Write("Введите Q для отмены задачи: ");
            string answer = Console.ReadLine();
            if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                cancelTokenSource.Cancel();
        }
        static async void CancelTaskAsync(CancellationToken token)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(time);
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Задача отменена токеном отмены\n\r");
                    return;
                }
                Console.WriteLine("Задача выполнена\n\r");
            });
        }
    }
}