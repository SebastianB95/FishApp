using FishApp;

Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("Witam wedkarzu w aplikacji do oceny twoich zlowionych ryb");
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("Przyznaj ocene swojej rybie od 1-10");
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("Po zakonczeniu dodawania ocen wcisnij C");
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("Podaj nazwe ryby");
var name = Console.ReadLine();
Console.WriteLine("Podaj wage ryby");
var weight = Console.ReadLine();
Console.WriteLine("Podaj czas zlowienia ryby");
var time = Console.ReadLine();
FishInFile fish = new(name, weight, time);
FishInMemory fish1 = new(name, weight, time);
fish.GradeAdded += FishGradeAdded;
void FishGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("------------------------------------------");
    Console.WriteLine($"Dodano Ocene");
    Console.WriteLine("------------------------------------------");
}
{
    while (true)
    {
        Console.WriteLine("Podaj Ocene");
        var input = Console.ReadLine();
        if (input == "c" || input == "C")
        {
            break;
        }
        try
        {
            fish.AddGrade(input);
            fish1.AddGrade(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd : {ex.Message}");
        }
    }
}
{
    while (true)
    {
        Console.WriteLine("Wybierz gdzie chcesz zapisac oceny:");
        Console.WriteLine("A do pliku");
        Console.WriteLine("-------------");
        Console.WriteLine("B do pamieci");
        var fishInput = Console.ReadLine();
        switch (fishInput)
        {
            case "A":
            case "a":
                var statistic = fish.GetStatistics();
                Console.WriteLine($"Nazwa to :{name}  Waga Ryby:  {weight}KG  Czas Zlowienia Ryby:{time}");
                Console.WriteLine($"Minimalna Ocena Ryby:   {statistic.Min}");
                Console.WriteLine($"Maksymalna Ocena Ryby:   {statistic.Max}");
                Console.WriteLine($"Srednia Ocen Ryby:   {statistic.Average:N2}");
                Console.WriteLine($"Suma Wszystkich Ocen:   {statistic.Sum}/50");

                break;
            case "B":
            case "b":
                var statistic1 = fish1.GetStatistics();
                Console.WriteLine($"Nazwa to :{name}  Waga Ryby:  {weight}KG  Czas Zlowienia Ryby:{time}");
                Console.WriteLine($"Minimalna Ocena Ryby: {statistic1.Min}");
                Console.WriteLine($"Maksymalna Ocena Ryby: {statistic1.Max}");
                Console.WriteLine($"Srednia Ocen Ryby: {statistic1.Average:N2}");
                Console.WriteLine($"Suma Wszystkich Ocen: {statistic1.Sum}/50");
                break;
            default:
                Console.WriteLine("Niepoprawna litera");
                continue;
        }
        if (fishInput == "A" || fishInput == "a" || fishInput == "b" || fishInput == "B")
        {
            break;
        }
    }
}