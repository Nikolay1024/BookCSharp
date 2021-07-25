using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace AutoLotDataAccessLayer.BulkImport
{
    class MyDataReader<T> : IMyDataReader<T>
    {
        private int RecordIndex = -1;
        public int FieldCount => PropertyInfos.Length;
        private readonly PropertyInfo[] PropertyInfos;
        private readonly Dictionary<string, int> NameDictionary;
        public List<T> Records { get; set; }

        public MyDataReader()
        {
            PropertyInfos = typeof(T).GetProperties();
            NameDictionary = PropertyInfos
                .Select((prop, propIndex) => new { prop.Name, Index = propIndex })
                .ToDictionary(prop => prop.Name, prop => prop.Index);
        }
        public MyDataReader(List<T> records) : this()
        {
            Records = records;
        }

        public bool Read()
        {
            if (RecordIndex + 1 >= Records.Count())
                return false;
            RecordIndex++;
            return true;
        }
        public void Dispose() { }
        public string GetName(int i)
            => (i >= 0 && i < FieldCount) ? PropertyInfos[i].Name : string.Empty;
        public int GetOrdinal(string name)
            => NameDictionary.ContainsKey(name) ? NameDictionary[name] : -1;
        public object GetValue(int i)
            => PropertyInfos[i].GetValue(Records[RecordIndex]);

        #region Не реализованные члены
        public int Depth => throw new NotImplementedException();
        public bool IsClosed => throw new NotImplementedException();
        public int RecordsAffected => throw new NotImplementedException();
        public object this[string name] => throw new NotImplementedException();
        public object this[int i] => throw new NotImplementedException();
        public void Close()
        {
            throw new NotImplementedException();
        }
        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }
        public bool NextResult()
        {
            throw new NotImplementedException();
        }
        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }
        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }
        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }
        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }
        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }
        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }
        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }
        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }
        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }
        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }
        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }
        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }
        public string GetString(int i)
        {
            throw new NotImplementedException();
        }
        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }
        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }
        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }
        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
