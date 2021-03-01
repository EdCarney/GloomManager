using GloomManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Data.Services
{
    public class BaseRepo<T> : IRepo<T>
    {
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
