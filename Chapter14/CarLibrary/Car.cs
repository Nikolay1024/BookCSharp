using System.Windows.Forms;

namespace CarLibrary
{
    // Представляет состояние двигателя.
    public enum EngineState
    { Alive, Dead }
    // Тип музыкального устройства, установленного в автомобиле.
    public enum MusicMedia
    { musicCd, musicTape, musicRadio, musicMp3 }

    // Абстрактный базовый класс в иерархии.
    public abstract class Car
    {
        public string Name { get; set; } = "";
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        protected EngineState egnState = EngineState.Alive;
        public EngineState EngineState => egnState;

        public Car() => MessageBox.Show("CarLibrary(v2.0.0.0)");
        public Car(string name, int max, int speed)
        {
            MessageBox.Show("CarLibrary(v2.0.0.0)");
            Name = name; MaxSpeed = max; Speed = speed;
        }

        public abstract void TurboBoost();
        public void TurnOnRadio(bool musicOn, MusicMedia mm)
            => MessageBox.Show(musicOn ? $"Радио вкл ({mm})" : "Радио выкл");
    }
}
