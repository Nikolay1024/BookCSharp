using System.Collections.Generic;
using System.Data;

namespace AutoLotDataAccessLayer.BulkImport
{
    interface IMyDataReader<T> : IDataReader
    {
        List<T> Records { get; set; }
    }
}
