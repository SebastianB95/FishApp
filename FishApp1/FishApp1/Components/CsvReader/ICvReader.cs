﻿
using FishApp1.Components.CsvReader.Models;

namespace FishApp1.Components.CsvReader;
public interface ICvReader
{

    List<Fishs> ProcessFish(string filePath);


}
