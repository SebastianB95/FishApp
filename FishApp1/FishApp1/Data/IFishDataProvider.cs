using FishApp1.Entities;

namespace FishApp1.Data;

public interface IFishDataProvider
{
    List<string> GetUniqueFish();

    int? FilterWeight();

    List<string> GetUniqueAngler();

    int? FilterMaxWeight();




}
