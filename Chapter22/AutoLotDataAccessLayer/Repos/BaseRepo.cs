using AutoLotDataAccessLayer.EntityFramework;
using AutoLotDataAccessLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoLotDataAccessLayer.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        private readonly DbSet<T> Table;
        private readonly AutoLotEntities Db;
        protected AutoLotEntities Context => Db;

        public BaseRepo()
        {
            Db = new AutoLotEntities();
            Table = Db.Set<T>();
        }

        // Реализация интерфейса IDisposable
        public void Dispose()
        {
            Db?.Dispose();
        }

        // Реализация интерфейса IRepo<T>
        public T GetOne(int? id) => Table.Find(id);
        public virtual List<T> GetAll() => Table.ToList();
        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }
        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }
        public int Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public int Delete(int id, byte[] timestamp)
        {
            Db.Entry(new T() { Id = id, Timestamp = timestamp }).State = EntityState.Deleted;
            return SaveChanges();
        }
        public int Save(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public List<T> ExecuteQuery(string sql) => Table.SqlQuery(sql).ToList();
        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => Table.SqlQuery(sql, sqlParametersObjects).ToList();

        internal int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Генерируется, когда возникает ошибка, связанная с параллелизмом.
                // Пока что просто повторно сгенерировать исключение.
                throw;
            }
            catch (DbUpdateException ex)
            {
                // Генерируется, когда обновление базы данных терпит неудачу.
                // Проверить внутреннее исключение (исключения), чтобы получить
                // дополнительные сведения и выяснить, на какие объекты это повлияло.
                // Пока что просто повторно сгенерировать исключение.
                throw;
            }
            catch (CommitFailedException ex)
            {
                // Обработать здесь отказы транзакции.
                // Пока что просто повторно сгенерировать исключение.
                throw;
            }
            catch (Exception ex)
            {
                // Произошло какое-то другое исключение, которое должно быть обработано.
                throw;
            }
        }
    }
}
