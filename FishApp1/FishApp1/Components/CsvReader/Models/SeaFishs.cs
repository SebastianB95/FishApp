

using FishApp1.Data.Entities;
using System.Transactions;

namespace FishApp1.Components.CsvReader.Models;

public  class SeaFishs :EntityBase
{
    public int Year { get; set; }

    public string TankType { get; set; }

    public double Field { get; set; }

    public string Species { get; set; }

   

  

}
