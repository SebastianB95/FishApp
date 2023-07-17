using FishApp1.Components.CsvReader;
using FishApp1.Components.CsvReader.Models;
using FishApp1.Data;
using FishApp1.Data.Entities;
using FishApp1.Repositories;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace FishApp1;

public class App : IApp
{
    private readonly IRepository<SeaFishs> _fishrepository;
    private readonly IUserCommunication _userCommunication;
    private readonly ICvReader _cvReader;
    private readonly FishApp1DbContex _fishAppDbContext;

    public App(IRepository<SeaFishs> fishrepository, IUserCommunication userCommunication, ICvReader cvReader, FishApp1DbContex fishApp1DbContex)

    {
        _fishrepository = fishrepository;
        _userCommunication = userCommunication;
        _cvReader = cvReader;
        _fishAppDbContext = fishApp1DbContex;
        _fishAppDbContext.Database.EnsureCreated();
    }

    public void Run()
    {

        Console.Write(_userCommunication.Menu());
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "X" ||input=="x")
            {
                break;
            }
            switch (input)
            {
                case "1":
                    _userCommunication.AddDate();
                    break;
                case "2":
                    _userCommunication.RemoveDate();
                    break;
                case "3":
                    _userCommunication.WriteAllToConsole();
                    break;
                case "4":
                    _userCommunication.UpdateDate();
                    break;
                case "5":
                    _userCommunication.StatisticSeaFishs();
                    
                    break;
                case "6":
                    _userCommunication.GroupFish();
                    break;
                case "7":
                    
                    break;
              
                    
                case "a":
                case "A":
                    XmlFile();
                    break;
                case "b":
                case "B":
                    LoadXml();
                    break;
                case "c":
                case "C":
                    InsertDate();
                    break;
                
       
                default:
                    Console.WriteLine("Prosze wybrac: 1,2,4,5,6,7,8,9 lub X aby zamknac program");
                    continue;
            }
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
            .Where(x => x.Attribute("Year")?.Value == "2011")
            .Select(x => x.Attribute("Species")?.Value);

        foreach (var fish in fishs)
        {
            Console.WriteLine(fish);
        }
    }

    void InsertDate()
    {
        var fishs = _cvReader.ProcessFish("C:\\Users\\Sebastiann\\Desktop\\Projekty\\FishApp\\FishApp1\\FishApp1\\Resources\\Files\\ryby.csv");


        foreach (var fish in fishs)
        {

            _fishAppDbContext.Add(new SeaFishs()
            {
                Year = fish.Year,
                TankType = fish.TankType,
                Species = fish.Species,
                Field = fish.Field

            });

        }
        _fishAppDbContext.SaveChanges();

    }








   
}