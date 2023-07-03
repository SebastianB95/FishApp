using FishApp1.Components.CsvReader;
using FishApp1.Components.CsvReader.Models;
using FishApp1.Components.DataProvider;
using FishApp1.Data.Entities;
using FishApp1.Repositories;
using Newtonsoft.Json;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace FishApp1;

public class App : IApp
{
    private readonly IRepository<Fish> _fishrepository;
    private readonly IUserCommunication _userCommunication;
    private readonly IFishDataProvider _fishDataProvider;
    private readonly ICvReader _cvReader;

    public App(IRepository<Fish> fishrepository, IUserCommunication userCommunication, IFishDataProvider fishDataProvider, ICvReader cvReader)

    {
        _fishrepository = fishrepository;
        _userCommunication = userCommunication;
        _fishDataProvider = fishDataProvider;
        _cvReader = cvReader;
    }

    public void Run()
    {
        Console.Write(_userCommunication.Menu());
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "10")
            {
                break;
            }
            switch (input)
            {
                case "1":
                    _userCommunication.AddFishs();
                    break;
                case "2":
                    _userCommunication.RemoveFish();
                    break;
                case "3":
                    _userCommunication.WriteAllToConsole();
                    break;
                case "4":
                    _userCommunication.Saveinfo();
                    break;
                case "5":
                    ShowUniqueAnglers();
                    break;
                case "6":
                    ShowUniqueFish();
                    break;
                case "7":
                    Filerweight();
                    break;
                case "8":
                    MaxWeight();
                    break;
                case "9":
                    SeaFish();
                    break;
                case "a":
                case "A":
                    XmlFile();
                    break;
                case "b":
                case "B":
                    LoadXml();
                    break;
                default:
                    Console.WriteLine("Prosze wybrac: 1,2,4,5,6,7,8,9 lub 10 aby zamknac program");
                    continue;
            }
        }
    }

    void MaxWeight()
    {
        Console.WriteLine("Najnizsza waga Ryby to: ");
        Console.WriteLine($"{_fishDataProvider.FilterMaxWeight()}KG");
    }

    void Filerweight()
    {
        Console.WriteLine("Najnizsza waga Ryby to: ");
        Console.WriteLine($"{_fishDataProvider.FilterWeight()}KG");
    }

    void ShowUniqueFish()
    {
        Console.WriteLine("Unikalne nazwy ryb to:");
        foreach (var item in _fishDataProvider.GetUniqueFish())
        {

            Console.WriteLine($"Nazwa:{item}");
        }
    }

    void ShowUniqueAnglers()
    {
        Console.WriteLine("Unikalne imiona Wedkarzy to :");


        foreach (var item in _fishDataProvider.GetUniqueAngler())
        {


            Console.WriteLine($"Wedkarz:{item}");
        }
    }

    void SeaFish()
    {
        var fish = _cvReader.ProcessFish("C:\\Users\\Sebastiann\\Desktop\\Projekty\\FishApp\\FishApp1\\FishApp1\\Resources\\Files\\ryby.csv");


        var groups = fish
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



    void XmlFile()
    {
        var fish = _cvReader.ProcessFish("C:\\Users\\Sebastiann\\Desktop\\Projekty\\FishApp\\FishApp1\\FishApp1\\Resources\\Files\\ryby.csv");


        var document = new XDocument();

        var fishs = new XElement("SeaFishs", fish
            .Select(x => new XElement("Fishing",

            new XAttribute("Year", x.Year),
            new XAttribute("TankType", x.TankType),
            new XAttribute("Species", x.Species),
            new XAttribute("Field", x.Field))));


        document.Add(fishs);
        document.Save("seaFishs.xml");

    }
    
    void LoadXml()
    {
        var document = XDocument.Load("seaFishs.xml");

        var fishs = document
            .Element("SeaFishs")?
            .Elements("Fishing")
            .Where(x=>x.Attribute("Year")?.Value=="2011")
            .Select(x => x.Attribute("Species")?.Value);

        foreach (var fish in fishs)
        {
            Console.WriteLine(fish);
        }


    }


}
















