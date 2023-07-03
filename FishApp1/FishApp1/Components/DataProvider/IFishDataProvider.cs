
namespace FishApp1.Components.DataProvider;

public interface IFishDataProvider
{
    List<string> GetUniqueFish();

    int? FilterWeight();

    List<string> GetUniqueAngler();

    int? FilterMaxWeight();
}
