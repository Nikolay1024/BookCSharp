using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SerializeApp
{
    [Serializable]
    public class Radio
    {
        public bool HasTweeters;        // Динамик
        public bool HasSubWoofers;      // Сабвуфер
        public double[] StationPresets; // Предустановки станций
        [NonSerialized]
        public string RadioID = "XF-552RR6";
        public override string ToString()
        {
            string stationPresetsString = StationPresets?.Aggregate("", (accumulate, elem) => accumulate + "-" + elem.ToString());
            return $"HasTweeters : { HasTweeters }\n" +
                   $"HasSubWoofers : { HasSubWoofers }\n" +
                   $"StationPresets : { stationPresetsString }\n" +
                   $"RadioID : { RadioID }\n";
        }
    }
    [Serializable]
    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool IsHatchBack;
        public override string ToString()
        {
            return $"{ TheRadio }" +
                   $"IsHatchBack : { IsHatchBack }\n";
        }
    }
    [Serializable]
    [XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool CanFly;
        [XmlAttribute]
        public bool CanSubmerge;

        // XmlSerializer требует стандартного конструктора!
        public JamesBondCar() { }
        public JamesBondCar(bool canFly, bool canSubmerge)
        {
            CanFly = canFly;
            CanSubmerge = canSubmerge;
        }
        public override string ToString()
        {
            return $"{ base.ToString() }" +
                   $"CanFly : { CanFly }\n" +
                   $"CanSubmerge : { CanSubmerge }\n";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Сериализация объектов с использованием BinaryFormatter, SoapFormatter, XmlSerializer");
            // Создать объект JamesBondCar и установить состояние.
            Radio radio = new Radio
            {
                HasTweeters = true,
                StationPresets = new double[] { 89.3, 105.1, 97.1 }
            };
            JamesBondCar jamesBondCar = new JamesBondCar
            {
                CanFly = true,
                CanSubmerge = false,
                TheRadio = radio
            };

            BinaryFormatterSerialize(jamesBondCar, "SerializedGraphObjects/BinaryCar.bin");
            Console.ReadKey();
            BinaryFormatterDeserialize("SerializedGraphObjects/BinaryCar.bin");
            Console.ReadKey();

            SoapFormatterSerialize(jamesBondCar, "SerializedGraphObjects/SoapCar.soap");
            Console.ReadKey();
            SoapFormatterDeserialize("SerializedGraphObjects/SoapCar.soap");
            Console.ReadKey();

            XmlSerialize(jamesBondCar, "SerializedGraphObjects/XmlCar.xml");
            Console.ReadKey();
            XmlDeserialize("SerializedGraphObjects/XmlCar.xml");
            Console.ReadKey();

            List<JamesBondCar> carsList = new List<JamesBondCar>
            {
                new JamesBondCar(true, true),
                new JamesBondCar(true, false),
                new JamesBondCar(false, true),
                new JamesBondCar(false, false)
            };
            XmlSerializeList(carsList, "SerializedGraphObjects/XmlCarsList.xml");
            Console.ReadKey();
            XmlDeserializeList("SerializedGraphObjects/XmlCarsList.xml");
            Console.ReadKey();
        }

        static void BinaryFormatterSerialize(object objGraph, string fileName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = File.Create(fileName))
                binaryFormatter.Serialize(fileStream, objGraph);
            Console.WriteLine("Сохранен граф объектов в файл BinaryCar.bin в двоичном формате.");
        }
        static void BinaryFormatterDeserialize(string fileName)
        {
            // Прочитать объект JamesBondCar из файла в двоичном формате.
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            JamesBondCar jamesBondCar = null;
            using (FileStream fileStream = File.OpenRead(fileName))
                jamesBondCar = (JamesBondCar)binaryFormatter.Deserialize(fileStream);
            Console.WriteLine($"BinaryCar.bin:\n{ jamesBondCar }");
        }

        static void SoapFormatterSerialize(object objGraph, string fileName)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fileStream = File.Create(fileName))
                soapFormatter.Serialize(fileStream, objGraph);
            Console.WriteLine("Сохранен граф объектов в файл SoapCar.soap в формате SOAP.");
        }
        static void SoapFormatterDeserialize(string fileName)
        {
            // Прочитать граф объектов JamesBondCar из файла в формате SOAP.
            SoapFormatter soapFormatter = new SoapFormatter();
            JamesBondCar jamesBondCar = null;
            using (FileStream fileStream = File.OpenRead(fileName))
                jamesBondCar = (JamesBondCar)soapFormatter.Deserialize(fileStream);
            Console.WriteLine($"SoapCar.soap:\n{ jamesBondCar }");
        }

        static void XmlSerialize(object objGraph, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(JamesBondCar));
            using (FileStream fileStream = File.Create(fileName))
                xmlSerializer.Serialize(fileStream, objGraph);
            Console.WriteLine("Сохранен граф объектов в файл XmlCar.xml в формате XML.");
        }
        static void XmlDeserialize(string fileName)
        {
            // Прочитать граф объектов JamesBondCar из файла в формате XML.
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(JamesBondCar));
            JamesBondCar jamesBondCar = null;
            using (FileStream fileStream = File.OpenRead(fileName))
                jamesBondCar = (JamesBondCar)xmlSerializer.Deserialize(fileStream);
            Console.WriteLine($"XmlCar.xml:\n{ jamesBondCar }");
        }

        static void XmlSerializeList(object objGraph, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<JamesBondCar>));
            using (FileStream fileStream = File.Create(fileName))
                xmlSerializer.Serialize(fileStream, objGraph);
            Console.WriteLine("Сохранен граф объектов в файл XmlCarsList.xml в формате XML.");
        }
        static void XmlDeserializeList(string fileName)
        {
            // Прочитать граф объектов List<JamesBondCar> из файла в формате XML.
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<JamesBondCar>));
            List<JamesBondCar> carsList = null;
            using (FileStream fileStream = File.OpenRead(fileName))
                carsList = (List<JamesBondCar>)xmlSerializer.Deserialize(fileStream);
            Console.WriteLine($"XmlCarsList.xml:");
            for (int i = 0; i < carsList.Count; i++)
                Console.WriteLine($"{ i + 1 })\n{carsList[i] }");
        }
    }
}
