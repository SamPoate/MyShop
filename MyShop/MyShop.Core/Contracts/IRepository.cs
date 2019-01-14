using System.Linq;
using MyShop.Core.Models;

namespace MyShop.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Commit();
        void Insert(T t);
        void Update(T t);
        T Find(string id);
        IQueryable<T> Collection();
        void Delete(string id);
    }
}