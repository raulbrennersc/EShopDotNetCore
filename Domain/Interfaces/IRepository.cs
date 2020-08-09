using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Save(T obj);

        void Update(T obj);

        void Delete(int id);

        T Get(int id);

        IQueryable<T> GetAll();
    }
}
