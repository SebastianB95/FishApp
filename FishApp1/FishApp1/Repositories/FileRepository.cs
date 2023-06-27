﻿
using FishApp1.Data;
using FishApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml.XPath;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.IO;
using System;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Linq;

namespace FishApp1.Repositories
{
    public class FileRepository<T> : IRepository<T> where T : class, IEntity, new()
    {

        public event EventHandler<T>? FishAdded;
        protected List<T> _fishs = new();
        public event EventHandler<T>? FishRemoved;

        private int lastFish = 1;

        private const string nameAndPantJsonFile = "fishs.json";



        public void Add(T item)
        {

            if (_fishs.Count == 0)
            {
                item.Id = lastFish;
                lastFish++;

            }
            else if (_fishs.Count > 0)
            {
                lastFish = _fishs[_fishs.Count - 1].Id;
                item.Id = ++lastFish;


            }

            _fishs.Add(item);
            FishAdded?.Invoke(this, item);



        }

        public IEnumerable<T> GetAll()
        {
            string JsonString = File.ReadAllText(nameAndPantJsonFile);
            List<T> fishs = JsonConvert.DeserializeObject<List<T>>(JsonString);


            foreach (var fish in fishs)
            {
                _fishs.Add(fish);  
            }

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
            File.Delete(nameAndPantJsonFile);
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

