namespace LinqOverCollections
{
    class Car
    {
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";

        public override string ToString()
            => $"{Color} {Make} {Name} едет {Speed} км/ч.";
    }
}