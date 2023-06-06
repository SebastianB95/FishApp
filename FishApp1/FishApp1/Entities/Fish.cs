
namespace FishApp1.Entities
{
    public class Fish : EntityBase
    {
        public string? Name { get; set; }

        public string? Weight { get; set; }

        public string? Angler { get; set; }

        public override string ToString() => $"Nr:{Id} Nazwa:{Name} Waga:{Weight} Imie wedkarza: {Angler}";

       
    }
}
