using System.Collections.Generic;
using System.Linq;
using StoreMemories.Models;
using Microsoft.EntityFrameworkCore;
using StoreMemories.Data;
using StoreMemories.Repositories;

namespace StoreMemories.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
