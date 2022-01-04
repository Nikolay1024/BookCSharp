using System.Collections.Generic;

namespace AutoLotDataAccessLayer.Repos
{
    public interface IRepo<T>
    {
        T GetOne(int? id);
        List<T> GetAll();
        int Add(T entity);
        int AddRange(IList<T> entities);
        int Delete(T entity);
        int Delete(int id, byte[] timestamp);
        int Save(T entity);

        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
    }
}
