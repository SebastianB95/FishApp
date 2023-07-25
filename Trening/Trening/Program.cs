Console.WriteLine("Zgadywanie libcz ");
Random random = new Random();
int i = random.Next(0, 100);
var count = 0; 


while (true)
{
    Console.WriteLine("Podaj liczbe");
    int shot = int.Parse(Console.ReadLine());
    count++; 
    
    

    if (shot == i)
    {
        Console.WriteLine("Udalo sie");
        Console.WriteLine($"Zgadles liczbe:{i}");
        Console.WriteLine($"Liczba prob:{count}");   
    }
    else if (shot < i)
    {
        Console.WriteLine("Za Mala liczba");
    }
    else if (shot > i)
    {
        Console.WriteLine("Liczba Za duża");
    }
    if (shot == i)
    {
        break;
    }
}