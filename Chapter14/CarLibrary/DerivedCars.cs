using System.Windows.Forms;

namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int max, int speed)
            : base(name, max, speed) { }
        public override void TurboBoost()
        {
            MessageBox.Show("Разгон!", "Чем быстрее тем лучше!");
        }
    }
    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int max, int speed)
            : base(name, max, speed) { }
        public override void TurboBoost()
        {
            // Минивэны имеют плохие возможности ускорения!
            egnState = EngineState.Dead;
            MessageBox.Show("Ой!", "Ваш блок двигателя взорвался!");
        }
    }
}