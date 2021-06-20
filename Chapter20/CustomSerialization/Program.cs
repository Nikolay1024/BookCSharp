using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace CustomSerialization
{
    [Serializable]
    class StringData : ISerializable
    {
        private string DataItemOne = "First data block";
        private string DataItemTwo = "More data";

        public StringData() { }
        // Конструктор неявно вызывается после десериализации данных потока в граф объектов.
        protected StringData(SerializationInfo si, StreamingContext ctx)
        {
            DataItemOne = si.GetString("DataItemOne").ToLower();
            DataItemTwo = si.GetString("DataItemTwo").ToLower();
        }

        // Метод неявно вызывается при сериализации графа объектов в поток данных.
        void ISerializable.GetObjectData(SerializationInfo si, StreamingContext ctx)
        {
            si.AddValue("DataItemOne", DataItemOne.ToUpper());
            si.AddValue("DataItemTwo", DataItemTwo.ToUpper());
        }
        public override string ToString()
        {
            return $"{ DataItemOne }\n{ DataItemTwo }\n";
        }
    }
    [Serializable]
    class MoreData
    {
        private string DataItemOne = "First data block";
        private string DataItemTwo = "More data";

        [OnSerializing]
        // Метод неявно вызывается при сериализации графа объектов в поток данных.
        private void OnSerializing(StreamingContext context)
        {
            DataItemOne = DataItemOne.ToUpper();
            DataItemTwo = DataItemTwo.ToUpper();
        }
        [OnDeserialized]
        // Метод неявно вызывается после десериализации данных потока в граф объектов.
        private void OnDeserialized(StreamingContext context)
        {
            DataItemOne = DataItemOne.ToLower();
            DataItemTwo = DataItemTwo.ToLower();
        }
        public override string ToString()
        {
            return $"{ DataItemOne }\n{ DataItemTwo }\n";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Настройка сериализации с использованием ISerializable");
            // Вспомните, что этот тип реализует интерфейс ISerializable.
            StringData stringData = new StringData();
            SoapFormatterSerialize(stringData, "MyData.soap");
            SoapFormatterDeserializeStringData("MyData.soap");
            Console.ReadKey();

            MoreData moreData = new MoreData();
            SoapFormatterSerialize(moreData, "MoreData.soap");
            SoapFormatterDeserializeMoreData("MoreData.soap");
            Console.ReadKey();
        }

        static void SoapFormatterSerialize(object objGrph, string fileName)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fileStream = File.Create(fileName))
                soapFormatter.Serialize(fileStream, objGrph);
            Console.WriteLine("Сохранен экземпляр в локальный файл в формате SOAP.");
        }
        static void SoapFormatterDeserializeStringData(string fileName)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            StringData stringData;
            using (FileStream fileStream = File.OpenRead(fileName))
                stringData = (StringData)soapFormatter.Deserialize(fileStream);
            Console.WriteLine($"{ fileName }:\n{ stringData }");
        }
        static void SoapFormatterDeserializeMoreData(string fileName)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            MoreData stringData;
            using (FileStream fileStream = File.OpenRead(fileName))
                stringData = (MoreData)soapFormatter.Deserialize(fileStream);
            Console.WriteLine($"{ fileName }:\n{ stringData }");
        }
    }
}