using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebAlbums.Models.Repositories
{
    public class Repository<T> where T :class
    {
        private MusicStoreDataContext context  = new MusicStoreDataContext();
        protected DbSet<T> DataSet{ get; set; }
        public Repository()
        {
            DataSet = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return DataSet.ToList();
        }
        public T Get(int id)
        {
            return DataSet.Find(id);
        }
        public void Add(T entity)
        {
            DataSet.Add(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}