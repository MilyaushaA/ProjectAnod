using EloksalPro.EfStructures;
using EloksalPro.Models;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EloksalPro.Repositories.Base
{
    public abstract class BaseRepo<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table { get; }
        public ApplicationDbContext Context = new ApplicationDbContext();
        //private bool disposed = false;

        ////public void Dispose()
        ////{
        ////    // освобождаем неуправляемые ресурсы
        ////    Dispose(true);
        ////    // подавляем финализацию
        ////    GC.SuppressFinalize(this);
        ////}
        ////protected virtual void Dispose(bool disposing)
        ////{
        ////    if (disposed) return;
        ////    if (disposing)
        ////    {
        ////        // Освобождаем управляемые ресурсы
        ////    }
        ////    // освобождаем неуправляемые объекты
        ////    disposed = true;
        ////}

        ////// Деструктор
        ////~BaseRepo()
        ////{
        ////    Dispose(false);
        ////}

        protected BaseRepo()
        {
            Table = Context.Set<T>();
        }
        public virtual void Add(T entity)
        {

            //try
            //{
            Table.Add(entity);
            Context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Произошла ошибка при добавление данных", ex);
            //}

        }


        public IEnumerable<T> GetByAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetByAllEntity()
        {
            List<T> list = new List<T>();
            list = Table.ToList();
            return list;
        }

        public T GetByEntity(int id)
        {
            T list = new T();
            list = Table.FirstOrDefault(x => x.Id == id);
            return list;
        }

        public int GetById()
        {
            List<T> list = new List<T>();
            list = Table.ToList();
            if (list.Count() > 0)
            {
                var maxCount = list.Max(x => x.Id);
                return maxCount;
            }
            else
            {
                return 0;
            }
        }
        public void Remove(int id)
        {
            T list = new T();
            list = Table.FirstOrDefault(x => x.Id == id);
            if (list != null)
            {
                Table.Remove(list);
                Context.SaveChanges();
            }
        }
        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public bool CheckValue(int id)
        {
            bool checkValue = Table.Any(p => p.Id == id);
            return checkValue;
        }
    }
}