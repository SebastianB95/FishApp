using System.Text.Json;
using FishApp1.Data.Entities;

namespace FishApp1.Data.Entities.Extensions;


public static class Entity_Extensions
{

    public static T? Copy<T>(this T itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize(itemToCopy);

        return JsonSerializer.Deserialize<T>(json);


    }
}

