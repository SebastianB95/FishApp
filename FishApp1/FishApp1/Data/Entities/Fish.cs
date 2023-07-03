namespace FishApp1.Data.Entities
{
    public class Fish : EntityBase
    {
        public string? Name { get; set; }

        public int? Weight { get; set; }

        public string? Angler { get; set; }

        public string? species { get; set; }

        public override string ToString() => $"Nr:{Id} Nazwa:{Name} Waga:{Weight}KG Gatunek :{species} Imie wedkarza: {Angler}";

    }
}
