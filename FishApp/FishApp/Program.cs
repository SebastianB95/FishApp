using FishApp;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
FishInFile fishInFile = new(name, weight, time);
FishInMemory fishInMemory = new(name, weight, time);
fishInFile.GradeAdded += FishGradeAdded;
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
            fishInFile.AddGrade(input);
            fishInMemory.AddGrade(input);
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

                AddToFile();

                break;
            case "B":
            case "b":

                AddToMemory();

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

    void AddToFile()
    {
        var statistic = fishInFile.GetStatistics();
        fishInFile.GetAndWriteStatistics();
    }

    void AddToMemory()
    {
        var statistic = fishInMemory.GetStatistics();
        fishInMemory.GetAndWriteStatistics();
    }
    Console.WriteLine($"Nazwa to: {name} Waga:{weight}Kg Czas zlowienia:{time}");
}

void FishGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("------------------------------------------");
    Console.WriteLine($"Dodano Ocene");
    Console.WriteLine("------------------------------------------");
}
