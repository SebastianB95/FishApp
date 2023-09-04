using FishApp1.Components.CsvReader.Models;

namespace FishApp1.Repositories.Extensions;

public static class FIshExtension
{

    public static IEnumerable<SeaFishs> ToFish(this IEnumerable<string> source)
    {

        foreach (var line in source)
        {
            var columns = line.Split(';');


            yield return new SeaFishs
            {
                Year = int.Parse(columns[0]),

                TankType = columns[1],

                Species = columns[2],

                Field = double.Parse(columns[3]),
            };
        }
    }
}