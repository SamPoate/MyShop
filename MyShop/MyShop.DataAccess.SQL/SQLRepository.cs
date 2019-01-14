using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MyShop.Core.Contracts;
using MyShop.Core.Models;

namespace MyShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T: BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }

        public T Find(string id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Delete(string id)
        {
            var t = Find(id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }

            dbSet.Remove(t);
        }
    }
}
