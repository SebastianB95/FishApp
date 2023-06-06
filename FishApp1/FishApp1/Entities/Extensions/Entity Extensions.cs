using System.Text.Json;

namespace FishApp1.Entities.Extensions;


public static class Entity_Extensions
{

    public static T? Copy<T>(this T itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemToCopy);

        return JsonSerializer.Deserialize<T>(json);


    }
}

