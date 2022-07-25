using System.Text.Json;

namespace KysectAcademyTask;

internal class JsonWriter : IReportStrategy
{
    private readonly string _path;
    public JsonWriter(string path)
    {
        _path = path;
    }
    public void Unload(Dictionary<string, double> data)
    {
        var output = new Dictionary<string, string>();
        foreach (KeyValuePair<string, double> d in data)
        {
            output[d.Key] = $"{d.Value:P2}";
        }
        string json = JsonSerializer.Serialize(output);
        File.WriteAllText(_path + "\\report.json", json);
    }
}