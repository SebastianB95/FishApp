namespace FishApp1.Entities
{
    public class Anglers :Fish 
    {
        public string firstName { get; set; }

        public override string ToString() => $"ID:{Id} Firstname:{firstName} (Anglers)";

    }
}
