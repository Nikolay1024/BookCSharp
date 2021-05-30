using System;

namespace ClassExampleApp
{
    class Motorcycle
    {
        public int DriverIntensity;
        public string DriverName;

        public Motorcycle(int intensity)
            : this(intensity, "")
        { }

        public Motorcycle(int intensity, string name)
        {
            if (intensity > 10)
                intensity = 10;
            DriverIntensity = intensity;
            DriverName = name;
        }

        public void PrintState()
        {
            if (DriverName == String.Empty)
                Console.WriteLine("Безымянный мотоциклист имеет силу {0}", DriverIntensity);
            else
                Console.WriteLine("Мотоциклист {0} имеет силу {1}", DriverName, DriverIntensity);
        }
    }
}
