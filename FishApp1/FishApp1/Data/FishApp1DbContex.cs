using FishApp1.Components.CsvReader.Models;
using Microsoft.EntityFrameworkCore;

namespace FishApp1.Data;

public class FishApp1DbContex : DbContext
{

    public FishApp1DbContex(DbContextOptions<FishApp1DbContex> options) 
        : base(options)
    {

    }
    public DbSet<SeaFishs> SeaFishs { get; set; }
    public Action<object?, SeaFishs> FishAdded { get; internal set; }
    public Action<object?, SeaFishs> FishRemoved { get; internal set; }
}
