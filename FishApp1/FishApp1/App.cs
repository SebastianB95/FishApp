using FishApp1.Data;
using FishApp1.Entities;
using FishApp1.Repositories;
using Newtonsoft.Json;

namespace FishApp1;

public class App : IApp
{
    private readonly IRepository<Fish> _fishrepository;
    private readonly IUserCommunication _userCommunication;
    private readonly IFishDataProvider _fishDataProvider;

    public App(IRepository<Fish> fishrepository, IUserCommunication userCommunication, IFishDataProvider fishDataProvider)

    {
        _fishrepository = fishrepository;
        _userCommunication = userCommunication;
        _fishDataProvider = fishDataProvider;

    }

    public void Run()
    {
        Console.Write(_userCommunication.Menu());

        while (true)
        {

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _userCommunication.AddFishs();
                    break;
                case "2":
                    _userCommunication.RemoveData();
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
                default:
                    Console.WriteLine("Wybierze 1,2,3,4,5,6,7,8 lub 9 zeby zamknac aplikacje");
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

            Console.WriteLine(item);
        }
    }

    void ShowUniqueAnglers()
    {
        Console.WriteLine("Unikalne imiona Wedkarzy to :");
        foreach (var item in _fishDataProvider.GetUniqueAngler())
        {
            Console.WriteLine(item);
        }
    }

}





