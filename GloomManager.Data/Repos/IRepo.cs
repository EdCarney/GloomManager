using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Data.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int AddRange(IEnumerable<T> entities);
        int Save(T entity);
        int Delete(int id, byte[] timeStamp);
        int Delete(T entity);
        T GetOne(int id);
        IEnumerable<T> GetAll();
    }
}
