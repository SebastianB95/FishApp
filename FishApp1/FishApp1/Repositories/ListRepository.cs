
using FishApp1.Data.Entities;
namespace FishApp1.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {

        protected readonly List<T> _items = new();

        public event EventHandler<T>? FishAdded;
        public event EventHandler<T>? FishRemoved;

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public void Add(T item)
        {
            FishAdded?.Invoke(this, item);
            item.Id = _items.Count + 1;
            _items.Add(item);
           

        }
        public void Save()
        {


        }
        public void Remove(T item)
        {
            FishRemoved?.Invoke(this, item);
            _items.Remove(item);
           
        }

        public T GetById(int id)

        {

            return _items.Single(item => item.Id == id);
        }
    }
}
