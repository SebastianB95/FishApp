
namespace FishApp1.Entities
{
    public class Fish : EntityBase
    {
        public string? Name { get; set; }

        public string? weight { get; set; }

        public override string ToString() => $"ID:{Id} Name:{Name} Weight:{weight}";

    }
}
