using FishApp1.Data.Entities;
using FishApp1.Repositories;
using Newtonsoft.Json;

namespace FishApp1.Components.DataProvider;

public class FishDataProvider : IFishDataProvider
{
    public readonly IRepository<Fish> _fishrepository;
    private const string nameAndPantJsonFile = "fishs.json";

    public FishDataProvider(IRepository<Fish> repository)
    {
        _fishrepository = repository;
    }

    public int? FilterWeight()
    {
        var fish = _fishrepository.GetAll();

        return fish.Select(x => x.Weight).Min();
    }

    public List<string> GetUniqueAngler()
    {
        var fish = _fishrepository.GetAll();
        var anglers = fish.Select(x => x.Angler).Distinct().ToList();

        return anglers;
    }

    public List<string> GetUniqueFish()
    {
        var fish = _fishrepository.GetAll();
        var fishs = fish.Select(x => x.Name).Distinct().ToList();

        return fishs;
    }

    public int? FilterMaxWeight()
    {
        var fish = _fishrepository.GetAll();

        return fish.Select(x => x.Weight).Max();
    }


}
