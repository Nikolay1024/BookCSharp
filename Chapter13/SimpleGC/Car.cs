namespace SimpleGC
{
    class Car
    {
        public int Speed { get; set; }
        public string Name { get; set; }
        public Car() { }
        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
        public override string ToString() => $"{Name} едет {Speed} км/ч";
    }
}
