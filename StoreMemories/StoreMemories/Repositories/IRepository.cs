using StoreMemories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMemories.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(int id);
        List<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
