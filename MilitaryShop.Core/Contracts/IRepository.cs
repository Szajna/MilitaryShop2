using MilitaryShop.Core.Models;
using System.Linq;

namespace MilitaryShop.Core.Contracts

{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Upsate(T t);
    }
}