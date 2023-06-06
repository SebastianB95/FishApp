
using FishApp1.Data;
using FishApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FishApp1.Repositories
{
    public class FishInFile<T> : IRepository<T> where T : class, IEntity, new()
    {

        public event EventHandler<T>? FishAdded, FishRemoved;
        protected List<T> _fishs = new();

        private const string nameAndPantJsonFile = "fishInfo";



        public void Add(T item)
        {
            item.Id = _fishs.Count + 1;
            _fishs.Add(item);
            FishAdded?.Invoke(this, item);

        }

        public IEnumerable<T> GetAll()
        {
            var pilikJson = @"C:\Users\Sebastiann\Desktop\Projekty\FishApp\FishApp1\FishApp1\bin\Debug\net6.0\fishInfo";
            var jsonContent = File.ReadAllText(pilikJson);
            var fish = JsonConvert.DeserializeObject<Fish>(jsonContent);

            

                return _fishs.ToList();
        }


        public T? GetById(int id)
        {
            return _fishs.Single(item => item.Id == id);
        }

        public void Remove(T item)
        {
            _fishs.Remove(item);
            FishRemoved?.Invoke(this, item);

        }

        public void Save()
        {

            string fishSerialized = JsonConvert.SerializeObject(_fishs);
            var fileJson = File.AppendText(nameAndPantJsonFile);

            using (fileJson)
            {
                fileJson.Write(fishSerialized);
                fileJson.Dispose();
            }

        }

    }
    
}
