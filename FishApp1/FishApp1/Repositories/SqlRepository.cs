using FishApp1.Components.CsvReader.Models;
using FishApp1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static FishApp1.Data.Entities.EntityBase;

namespace FishApp1.Repositories
{


    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        private readonly IRepository<SeaFishs> _repository; 

        public event EventHandler<T>? FishAdded;
        public event EventHandler<T>? FishRemoved;

        public SqlRepository(DbContext dbContext,IRepository<SeaFishs> repository)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _repository = repository; 
           
        }



        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }


        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            FishAdded?.Invoke(this, item);

        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            FishRemoved?.Invoke(this, item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

     

    }
}

