using System;

namespace ClassExampleApp
{
    class Bicycle
    {
        public int DriverIntensity;
        public string DriverName;

        public Bicycle(int intensity = 0, string name = "")
        {
            if (intensity > 10)
                intensity = 10;
            DriverIntensity = intensity;
            DriverName = name;
        }

        public void PrintState()
        {
            if (DriverName == String.Empty)
                Console.WriteLine("Безымянный велосипедист имеет силу {0}", DriverIntensity);
            else
                Console.WriteLine("Велосипедист {0} имеет силу {1}", DriverName, DriverIntensity);
        }
    }
}
