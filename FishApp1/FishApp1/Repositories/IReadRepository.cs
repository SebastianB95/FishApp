using FishApp1.Entities;

namespace FishApp1.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}
