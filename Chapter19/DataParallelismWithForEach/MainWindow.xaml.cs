using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Новая переменная уровня Window.
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }

        void cmdCancel_Click(object sender, EventArgs e)
        {
            // Используется для сообщения всем рабочим потокам о необходимости останова!
            cancelTokenSource.Cancel();
        }
        void cmdProcess_Click(object sender, EventArgs e)
        {
            // Запустить новую "задачу" для обработки файлов.
            Task.Factory.StartNew(() => ProcessFiles());
        }
        void ProcessFiles()
        {
            // Использовать экземпляр ParallelOptions для хранения CancellationToken.
            ParallelOptions parallelOpts = new ParallelOptions
            {
                CancellationToken = cancelTokenSource.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            // Загрузить все файлы *.jpg и создать новый каталог для модифицированных данных.
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = @".\ModifiedPictures";
            Directory.CreateDirectory(newDir);
            try
            {
                // Обработать данные изображений в параллельном режиме.
                Parallel.ForEach(files, parallelOpts, currentFile =>
                {
                    parallelOpts.CancellationToken.ThrowIfCancellationRequested();
                    string filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));
                    }
                    // Вызвать Invoke() на объекте Dispatcher, чтобы позволить вторичным потокам
                    // получать доступ к элементам управления в безопасной к потокам манере.
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        this.Title = $"Файл {filename} обрабатывается потоком: " +
                            $"{Thread.CurrentThread.ManagedThreadId}";
                    }));
                    Thread.Sleep(5000);
                });
                this.Dispatcher.Invoke(new Action(() =>
                {
                    this.Title = "Готово!";
                }));
            }
            catch (OperationCanceledException ex)
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    this.Title = ex.Message;
                }));
            }
        }
    }
}
