using FishApp1.Data;
using FishApp1.Entities;
using FishApp1.Repositories;
using FishApp1.Repositories.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("-----Witam w aplikacji dla wedkarzy-----");
Console.WriteLine("----------------------------------------");
Console.WriteLine("Wybierz 1 aby dodac informaacje ");
Console.WriteLine("---------------------------------------");
Console.WriteLine("Wybierz 2 aby usunac pozycje ");
Console.WriteLine("----------------------------------");
Console.WriteLine("Wybierz 3 aby Wyswietlic Dane");
Console.WriteLine("---------------------------------------");
Console.WriteLine("Wybierze X zeby zakonczyc program");
Console.WriteLine("----------------------------------");
var fishRepository = new FishInFile<Fish>();
fishRepository.FishAdded += FishAddedInRepository;
fishRepository.FishRemoved += FishRemoveInRepository;
bool exit = false;

while (!exit)
{

    var inputfish = Console.ReadLine();


    switch (inputfish)

    {
        case "1":

            AddFishs(fishRepository);

            break;

        case "2":
            RemoveInfo(); 
            break;
        case "3":
            var fishChoiceWhatToShow = GetInfo("").ToUpper();
            if (fishChoiceWhatToShow == "3")
            {
                WriteAllToConsole(fishRepository);
                break;
            }
            break;
        case "x":
        case "X":
            exit = SaveInfo(fishRepository);
            break;
        default:
            Console.WriteLine("You have to type 1,2,3 or X");
            continue;


    }

}
void RemoveInfo()
{
}

static void WriteAllToConsole<T>(IReadRepository<T> repository)
    where T : class, IEntity, new()
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

void AddFishs(IRepository<Fish> fishRepository)
{
    string fishName = GetInfo("Podaj Nazwe ryby").ToUpper();
    string fishWeight = GetInfo("Podaj Wage Ryby").ToUpper();
    string anglerName = GetInfo("Podaj Imie wedkarza").ToUpper();

    if (!string.IsNullOrEmpty(fishName) && !string.IsNullOrEmpty(fishWeight) && !string.IsNullOrEmpty(anglerName))
    {
        var newFish = new Fish { Name = fishName, Weight = fishWeight, Angler = anglerName };
        fishRepository.Add(newFish);
    }

}

bool SaveInfo(FishInFile<Fish> fishrepository)
{
    while (true)
    {
        var input = GetInfo("Aby Zapisac Dane Wcisnij  Z ");
        if (input == "Z"||input == "z")
        {
            fishrepository.Save();
            Console.WriteLine("Dane Zapisane");
            return true;
        }
     
    }
}


string? GetInfo(string info)
{
    Console.WriteLine(info);
    string fishInfo = Console.ReadLine();
    return fishInfo;

}




void FishRemoveInRepository(object? sender, Fish e)
{
    Console.WriteLine($"[{DateTime.UtcNow}----{e.Name} {e.Weight} {e.Angler} Usunieto element ");
}

void FishAddedInRepository(object? sender, Fish e)
{
    Console.WriteLine($"{DateTime.UtcNow}----{e.Name} {e.Weight} {e.Angler} Dodano Element ");
}































