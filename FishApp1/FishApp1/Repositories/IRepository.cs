
using FishApp1.Entities;

namespace FishApp1.Repositories
{
    public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T>
        where T : class, IEntity
    {
        event EventHandler<T>? FishAdded;
        event EventHandler<T>? FishRemoved;

    }
}
