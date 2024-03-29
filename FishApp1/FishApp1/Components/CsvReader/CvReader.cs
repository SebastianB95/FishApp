﻿
using FishApp1.Components.CsvReader.Models;
using FishApp1.Repositories.Extensions;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace FishApp1.Components.CsvReader;

public class CvReader : ICvReader
{
    public List<SeaFishs> ProcessFish(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<SeaFishs>();
        }

        var cars = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToFish();


        return cars.ToList();    
    }
}
