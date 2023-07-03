using FishApp1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FishApp1.Data
{
    public class FishApp1DbContex : DbContext
    {
        public DbSet<Fish> fishs => Set<Fish>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }

    }
}
