using System;

namespace LazyObjectlnstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Ленивое создание объектов");
            // Память под объект AllTracks здесь не выделяется!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();
            Console.ReadKey();
            // Размещение объекта AllTracks происходит
            // только в случае вызова метода GetAllTracks().
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();
            Console.ReadKey();
        }
    }
}
