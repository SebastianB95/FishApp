using FishApp1.Components.CsvReader.Models;
using FishApp1.Data;
using FishApp1.Data.Entities;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using FishApp1.Components.CsvReader;
using System.Xml.Linq;

namespace FishApp1.Repositories;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<SeaFishs> _repository;
    private readonly FishApp1DbContex _fishAppDbContext;
    public event Action<SeaFishs>? FishAdded;
    public event Action<SeaFishs>? FishRemoved;
    private readonly ICvReader _cvReader;



    const string filename = "audity.txt";
    private const string nameAndPantJsonFile = "fishs.json";
    public UserCommunication(IRepository<SeaFishs> repository, FishApp1DbContex fishApp1Db, ICvReader cvReader)
    {
        _repository = repository;
        _repository.FishAdded += FishA;
        _repository.FishRemoved += FishR;
        _cvReader = cvReader;
        _fishAppDbContext = fishApp1Db;
        _fishAppDbContext.Database.EnsureCreated();
    }

    private void FishR(object? sender, SeaFishs e)
    {
        Console.WriteLine($"[{DateTime.UtcNow}----{e.Id} {e.Year} {e.TankType} {e.Species} {e.Field}----usunieto element ");

        using (var writer = File.AppendText(filename))

        {
            writer.WriteLine($"[{DateTime.UtcNow}----{e.Id} {e.Year} {e.TankType} {e.Species} {e.Field}----usunieto element ");
        }
    }

    private void FishA(object? sender, SeaFishs e)
    {
        Console.WriteLine($"{DateTime.UtcNow}----{e.Id} {e.Year} {e.TankType} {e.Species} {e.Field}----Dodano Element ");
        using (var writer = File.AppendText(filename))
        {
            writer.WriteLine($"[{DateTime.UtcNow}----{e.Id}  {e.Year} {e.TankType} {e.Species} {e.Field}----Dodano Element ");

        }
    }

    public string Menu()
    {
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("|-----Witam w aplikacji dla wedkarzy-----|");
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|      Wybierz 1 dodac pozycje           |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|      Wybierz 2  usunac pozycje         |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|      Wybierz 3  Wyswietlic Dane        |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|      Wybierz 4 Edytowac                |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|      Wybierz 5 Statystyki polowow      |");
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("|      Wybierz 6 dane z kazdego roku     |");
        Console.WriteLine("|________________________________________|");
        Console.WriteLine("|    Wybierze X aby zakonczyć program    |");
        Console.WriteLine("|________________________________________|");

        return string.Empty;
    }

    public void AddDate()
    {
        Console.WriteLine("Podaj Rok:");
        var year = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj Typ Zbiornika:");
        var tanktype = Console.ReadLine();
        Console.WriteLine("Podaj Gatunek Ryb:");
        var speciess = Console.ReadLine();
        Console.WriteLine("Podaj Liczbe polowow");
        var field = double.Parse(Console.ReadLine());

        _fishAppDbContext.Add(new SeaFishs
        {
            Year = year,
            TankType = tanktype,
            Species = speciess,
            Field = field,
        });
        _fishAppDbContext.SaveChanges();
    }

    public void RemoveDate()
    {
        var fishFromDb = _fishAppDbContext.SeaFishs.ToList();

        foreach (var fish in fishFromDb)
        {
            Console.WriteLine($"ID:{fish.Id} Rok: {fish.Year} Zbiornik: {fish.TankType} Gatunek:{fish.Species} Polowy: {fish.Field}");
        }
        Console.WriteLine("Podaj ID Elementu ktory chcesz usunac");

        var delete = int.Parse(Console.ReadLine());
        var years = this.ReadID(delete);

        _fishAppDbContext.Remove(years);
        _fishAppDbContext.SaveChanges();
    }

    private SeaFishs? ReadID(int ID)
    {
        {
            return _fishAppDbContext.SeaFishs.FirstOrDefault(x => x.Id == ID);
        }
    }

    public void UpdateDate()
    {
        Console.WriteLine("Jezeli chcesz edytowac rok wybierz y");
        Console.WriteLine("Jezeli chcesz edytowac typ zbiornika wybierz t");
        Console.WriteLine("Jezeli chcesz edytowac gatunek  wybierz s");
        Console.WriteLine("Jezeli chcesz edytowac polowy wybierz f");



        var input = Console.ReadLine();

        switch (input)
        {

            case "y":

                Console.WriteLine("Podaj rok ktory chcesz zmienic");
                var years = int.Parse(Console.ReadLine());
                var year = this.ReadYear(years);
                Console.WriteLine("Podaj Nowy rok");
                var y = int.Parse(Console.ReadLine());
                year.Year = y;
                _fishAppDbContext.SaveChanges();
                Console.WriteLine("Zmienione Pomyslnie");
                break;

            case "t":

                Console.WriteLine("Podaj typ zbiornik ktory chcesz zmienic");
                var tanks = Console.ReadLine();
                var tank = this.ReadTankType(tanks);
                Console.WriteLine("Podaj nowy typ zbiornika");
                var t = Console.ReadLine();
                tank.TankType = t;
                _fishAppDbContext.SaveChanges();
                Console.WriteLine("Zmienione Pomyslnie");
                break;

            case "s":
                Console.WriteLine("Podaj gatunek ktory chcesz zmienic");
                var speciess = Console.ReadLine();
                var species = this.ReadSpecies(speciess);
                Console.WriteLine("Podaj nowy gatunek");
                var s = Console.ReadLine();
                species.TankType = s;
                _fishAppDbContext.SaveChanges();
                Console.WriteLine("Zmienione Pomyslnie");
                break;


            case "f":
                Console.WriteLine("Podaj liczbe polowow ktore chcesz zmienic");
                var fields = double.Parse(Console.ReadLine());
                var field = this.ReadField(fields);
                Console.WriteLine("Podaj nowa liczbe polowow");
                var f = double.Parse(Console.ReadLine());
                field.Field = f;
                _fishAppDbContext.SaveChanges();
                Console.WriteLine("Zmienione Pomyslnie");
                break;

        }
    }

    private SeaFishs? ReadYear(int year)
    {

        return _fishAppDbContext.SeaFishs.FirstOrDefault(x => x.Year == year);

    }
    private SeaFishs? ReadTankType(string tanktype)
    {
        return _fishAppDbContext.SeaFishs.FirstOrDefault(x => x.TankType == tanktype);
    }
    private SeaFishs? ReadSpecies(string species)
    {
        return _fishAppDbContext.SeaFishs.FirstOrDefault(x => x.Species == species);
    }

    private SeaFishs? ReadField(double field)
    {
        return _fishAppDbContext.SeaFishs.FirstOrDefault(x => x.Field == field);
    }

    public void WriteAllToConsole()
    {
        var fishFromDb = _fishAppDbContext.SeaFishs.ToList();

        foreach (var fish in fishFromDb)
        {

            Console.WriteLine($"Rok: {fish.Year} Zbiornik: {fish.TankType} Gatunek:{fish.Species} Polowy: {fish.Field}");

        }
    }


    public void StatisticSeaFishs()
    {
        var groups = _fishAppDbContext
        .SeaFishs
        .GroupBy(x => x.TankType)
        .Select(g => new
        {
            Name = g.Key,
            Max = g.Max(f => f.Field),
            Min = g.Min(f => f.Field),
            Average = g.Average(f => f.Field)

        })
      .OrderBy(x => x.Average);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}");
            Console.WriteLine($"\t Srednia polowow: {group.Average:N1}");
            Console.WriteLine($"\t Maksymalny polow: {group.Max}");
            Console.WriteLine($"\t Minimalny polow: {group.Min}");
        }


    }



    public void GroupFish()
    {
        var groups = _fishAppDbContext
            .SeaFishs
            .GroupBy(x => x.Year)
            .Select(x => new
            { Name =x.Key,
            Fishs = x.ToList()


            }).ToList();


        foreach (var group in groups)
        {
            Console.WriteLine(group.Name);
            Console.WriteLine("------------");
            foreach(var fish in group.Fishs)
            {
                Console.WriteLine($"\t Typ Zbiornika:{fish.TankType}  Gatunek:{fish.Species}  Liczba Polowow:{fish.Field}");

                Console.WriteLine();
                    
            }



        }



    }





}











