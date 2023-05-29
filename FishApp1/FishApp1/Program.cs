using FishApp1.Data;
using FishApp1.Entities;
using FishApp1.Repositories;
using System.ComponentModel;

var fishRepository = new SqlRepository<Fish>(new FishApp1DbContex());

AddFish(fishRepository);
AddAnglers(fishRepository);
WriteAllToConsole(fishRepository); 

static void AddFish(IRepository<Fish> fishRepository)
{
    fishRepository.Add(new Fish { Name = "Jesiotr",weight= "15kg" });
    fishRepository.Add(new Fish { Name = "Karp", weight = "14,5kg"});
    fishRepository.Add(new Fish { Name = "Amur",weight = "7,8kg" });
    fishRepository.Add(new Fish { Name = "Sum",weight = "10kg" });
    fishRepository.Save();
}

static void AddAnglers(IWriteRepository<Anglers> anglersRepository)
{
    anglersRepository.Add(new Anglers { firstName = "Mariusz" });
    anglersRepository.Add(new Anglers { firstName = "Janusz" });
    anglersRepository.Add(new Anglers { firstName = "Krzysztof" });
    anglersRepository.Add(new Anglers { firstName = "Marek" });
    anglersRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll(); 

    foreach(var item in items)
    {
        Console.WriteLine(item);
    }
}













