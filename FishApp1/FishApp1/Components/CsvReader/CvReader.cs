

using FishApp1.Components.CsvReader.Models;
using FishApp1.Repositories.Extensions;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.IO.Enumeration;
using System.Linq;

namespace FishApp1.Components.CsvReader;

public class CvReader : ICvReader
{
    public List<Fishs> ProcessFish(string filePath)
    {


        if (!File.Exists(filePath))
        {
            return new List<Fishs>();
        }


        var cars = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToFish();


        return cars.ToList(); 
        
    }

   
}
