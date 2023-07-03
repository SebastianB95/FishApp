using FishApp1.Data.Entities;
using Newtonsoft.Json;

namespace FishApp1.Repositories;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<Fish> _repository;
    
    const string filename = "audity.txt";
    private const string nameAndPantJsonFile = "fishs.json";
    public UserCommunication(IRepository<Fish> repository)
    {
        _repository = repository;
        _repository.FishAdded += FishA;
        _repository.FishRemoved += FishR;
        
    }

    private void FishR(object? sender, Fish e)
    {
        Console.WriteLine($"[{DateTime.UtcNow}----{e.Id} {e.Name} {e.Weight} {e.species} {e.Angler}----Usunieto element ");

        using (var writer = File.AppendText(filename))

        {
            writer.WriteLine($"[{DateTime.UtcNow}----{e.Id} {e.Name} {e.Weight} {e.species} {e.Angler}----Usunieto element ");
        }
    }

    private void FishA(object? sender, Fish e)
    {
        Console.WriteLine($"{DateTime.UtcNow}----{e.Id} {e.Name} {e.Weight} {e.species} {e.Angler}----Dodano Element ");
        using (var writer = File.AppendText(filename))
        {
            writer.WriteLine($"[{DateTime.UtcNow}----{e.Id}  {e.Name} {e.Weight} {e.species} {e.Angler}----Dodano Element ");

        }
    }

    public string Menu()
    {
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("|-----Witam w aplikacji dla wedkarzy-----|");
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|     Wybierz 1 aby dodac informaacje    |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|     Wybierz 2 aby usunac pozycje       |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|     Wybierz 3 aby Wyswietlic Dane      |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|     Wybierz 4 aby zapisac dane         |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|  Wybierz 5 aby pokazac unikalne imiona |");
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("|  Wybierz 6 aby pokazac unikalne ryby   |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|  Wybierz 7 aby pokazac najnizsza wage  |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|  Wybierze 8 aby pokazac najwyzsza wage |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|    Wybierz 9 aby zobaczyć statystyki   |");
        Console.WriteLine("|         polowow ryb morskich           |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|   Wybierze 10 aby zakonczyć program    |");
        Console.WriteLine("|________________________________________|");

        return string.Empty;
    }



    public void AddFishs()
    {
        string fishName = GetInfo("Podaj Nazwe ryby").ToUpper();
        int? fishWeight = GetInfoo("Podaj Wage Ryby");
        string speciess = GetInfo("Podaj Gatunek Ryby").ToUpper();
        string anglerName = GetInfo("Podaj Imie wedkarza").ToUpper();


        if (!string.IsNullOrEmpty(fishName) && !string.IsNullOrEmpty(speciess) && !string.IsNullOrEmpty(anglerName))
        {
            var fishs = new Fish
            {

                Name = fishName,
                Weight = fishWeight,
                species = speciess,
                Angler = anglerName

            };
            _repository.Add(fishs);

        }
        string? GetInfo(string info)
        {
            Console.WriteLine(info);
            string fishInfo = Console.ReadLine();


            return fishInfo;
        }

        int? GetInfoo(string infoo)
        {
            Console.WriteLine(infoo);
            int fishInfoo = int.Parse(Console.ReadLine());

            return fishInfoo;

        }
    }

    public void RemoveFish()
    {
        Console.Write("Prosze Podać Id elementu ktory chcesz usunac:");
        var removed = Console.ReadLine();
        if (int.TryParse(removed, out var result))
        {
            var itemToRemove = _repository.GetById(result);
            if (itemToRemove != null)
            {
                _repository.Remove(itemToRemove);
            }
            else
            {
                Console.WriteLine("Nie odnaleziono elementu");
            }
        }

    }

    public void Saveinfo()
    {

        while (true)
        {
            var input = GetInfo("Aby Zapisac Dane Wcisnij  1 ");
            if (input == "1")
            {
                _repository.Save();
                Console.WriteLine("Dane Zapisane");

                return; 
            }
        }

        string? GetInfo(string info)
        {
            Console.WriteLine(info);
            string fishInfo = Console.ReadLine();


            return fishInfo;
        }


    }

            public void WriteAllToConsole()
    {
        var jsonDeseralized = File.ReadAllText(nameAndPantJsonFile);
        List<Fish> fishs = JsonConvert.DeserializeObject<List<Fish>>(jsonDeseralized);


        foreach (Fish fish in fishs)
        {

            Console.WriteLine("NR:" + fish.Id + "Nazwa Ryby: " + fish.Name + " Gatunek:" + fish.species + ", Waga: " + fish.Weight + " KG" + ",Wedkarz:" + fish.Angler);
            Console.WriteLine("----------------------------------------------------------------------------|");

        }
    }





    

}

