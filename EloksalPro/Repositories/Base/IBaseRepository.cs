using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IDisposable
    {
        void Add(T entity);
        void Edit(T entity);
        void Remove(int id);
        int GetById();
        //List<string> GetByEntity();
        T GetByEntity(int id);
        List<T> GetByAllEntity();
        IEnumerable<T> GetByAll();
        bool CheckValue(int id);

    }
}
