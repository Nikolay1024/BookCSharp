using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeApp
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;        // Динамик
        public bool hasSubWoofers;      // Сабвуфер
        public double[] stationPresets; // Предустановки станций
        [NonSerialized]
        public string radioID = "XF-552RR6";
        public override string ToString()
        {
            string stationPresetsString = stationPresets.Aggregate("", (accumulate, elem) => accumulate + "-" + elem.ToString());
            return $"hasTweeters : { hasTweeters }\n" +
                   $"hasSubWoofers : { hasSubWoofers }\n" +
                   $"stationPresets : { stationPresetsString }\n" +
                   $"radioID : { radioID }\n";
        }
    }
    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
        public override string ToString()
        {
            return $"{ theRadio }" +
                   $"isHatchBack : { isHatchBack }\n";
        }
    }

    [Serializable]
    public class JamesBondCar : Car
    {
        public bool canFly;
        public bool canSubmerge;
        public override string ToString()
        {
            return $"{ base.ToString() }" +
                   $"canFly : { canFly }\n" +
                   $"canSubmerge : { canSubmerge }\n";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Сериализация объектов с использованием BinaryFormatter");
            // Создать объект JamesBondCar и установить состояние.
            Radio radio = new Radio
            {
                hasTweeters = true,
                stationPresets = new double[] { 89.3, 105.1, 97.1 }
            };
            JamesBondCar jamesBondCar = new JamesBondCar
            {
                canFly = true,
                canSubmerge = false,
                theRadio = radio
            };
            // Сохранить объект JamesBondCar в указанном файле в двоичном формате.
            BinaryFormaterSerialize(jamesBondCar, "CarData.dat");
            Console.ReadLine();
            BinaryFormaterDeserialize("CarData.dat");
            Console.ReadLine();
        }

        static void BinaryFormaterSerialize(object objGraph, string fileName)
        {
            // Сохранить граф объектов в файл CarData.dat в двоичном виде.
            BinaryFormatter binaryFormater = new BinaryFormatter();
            using (FileStream fileStream = File.OpenWrite(fileName))
                binaryFormater.Serialize(fileStream, objGraph);
        }
        static void BinaryFormaterDeserialize(string fileName)
        {
            BinaryFormatter binaryFormater = new BinaryFormatter();
            // Прочитать объект JamesBondCar из двоичного файла.
            JamesBondCar jamesBondCar = null;
            using (FileStream fileStream = File.OpenRead(fileName))
                jamesBondCar = (JamesBondCar)binaryFormater.Deserialize(fileStream);
            Console.WriteLine(jamesBondCar);
        }
    }
}
