using System.Text.Json;

namespace SerializationApp.Helpers;

public static class JsonHelper
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public static string Serialize<T>(T data)
    {
        return JsonSerializer.Serialize(data, Options);
    }

    public static T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, Options);
    }

    public static void SaveToFile<T>(string path, T data)
    {
        string json = Serialize(data);
        File.WriteAllText(path, json);
    }

    public static T? LoadFromFile<T>(string path)
    {
        string json = File.ReadAllText(path);
        return Deserialize<T>(json);
    }

   public static async Task SaveToFileAsync<T>(string path,T data)
    {
        await using FileStream stream = File.Create(path);

        await JsonSerializer.SerializeAsync(stream,data,Options);
    }

   public static async Task<T?> LoadFromFileAsync<T>(
        string path)
    {
        await using FileStream stream = File.OpenRead(path);

        return await JsonSerializer.DeserializeAsync<T>(
            stream,
            Options);
    }
}