using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Save(T obj);

        T Update(T obj);

        void Delete(int id);

        T Get(int id);

        IQueryable<T> GetAll();
    }
}
