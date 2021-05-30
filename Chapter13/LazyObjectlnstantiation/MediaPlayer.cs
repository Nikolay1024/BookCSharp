using System;

namespace LazyObjectlnstantiation
{
    // Представляет одиночную композицию.
    class Track
    {
        public string Artist { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
    }
    // Представляет все композиции в проигрывателе.
    class AllTracks
    {
        // Наш проигрыватель может содержать максимум 10000 композиций.
        private Track[] allTracks = new Track[10000];
        public AllTracks()
        {
            Console.WriteLine("Заполнение массива объектов Track!");
        }
        public AllTracks(string name)
        {
            Console.WriteLine("Создание плейлиста: {0}", name);
        }
    }
    // Объект MediaPlayer имеет объекты AllTracks.
    class MediaPlayer
    {
        public void Play() { /* Воспроизведение композиции */ }
        private Lazy<AllTracks> allTracks = new Lazy<AllTracks>(() =>
        {
            Console.WriteLine("Создание объекта AllTracks");
            return new AllTracks("Мой плейлист");
        });
        public AllTracks GetAllTracks()
        {
            // Возвратить все композиции.
            return allTracks.Value;
        }
    }
}
