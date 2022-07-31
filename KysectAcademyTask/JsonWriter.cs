using System.Text.Json;

namespace KysectAcademyTask;

public class JsonWriter : IReportStrategy
{
    private readonly string _path;
    public JsonWriter(string path)
    {
        _path = path;
    }

    public void Unload(List<ComparisonResult> data)
    {
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(_path + "\\report.json", json);
    }
}