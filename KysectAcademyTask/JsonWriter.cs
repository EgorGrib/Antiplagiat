using System.Text.Json;

namespace KysectAcademyTask;

public class JsonWriter : IReportStrategy
{
    public void Unload(string path, Dictionary<string, double> data)
    {
        var output = new Dictionary<string, string>();
        foreach (KeyValuePair<string, double> d in data)
        {
            output[d.Key] = $"{d.Value:P2}";
        }
        string json = JsonSerializer.Serialize(output);
        File.WriteAllText(path + "\\report.json", json);
    }
}