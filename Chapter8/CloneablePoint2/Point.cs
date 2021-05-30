using System;

namespace CloneablePoint2
{
    public class PointDescription
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public PointDescription(string name = "NoName")
        {
            Name = name;
            ID = Guid.NewGuid();
        }
    }

    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription Description = new PointDescription();

        public Point() { }
        public Point(int x, int y, string name)
        {
            X = x;
            Y = y;
            Description.Name = name;
        }

        public override string ToString()
            => $"X = {X}; Y = {Y}; Name = {Description.Name}; ID = {Description.ID};";

        public object Clone()
        {
            // Получить поверхностную копию
            Point point = (Point)MemberwiseClone();
            // Создать копию полей ссылочных типов
            point.Description = new PointDescription(Description.Name);
            return point;
        }
    }
}
