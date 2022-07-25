using System.Text;

namespace KysectAcademyTask;

internal class TxtWriter : IReportStrategy
{
    private readonly string _path;
    public TxtWriter(string path)
    {
        _path = path;
    }
    
    public void Unload(Dictionary<string, double> data)
    {
        var stringBuilder = new StringBuilder();
        foreach (KeyValuePair<string, double> d in data)
        {
            stringBuilder.Append(d.Key + $" {d.Value:P2}\n");
        }
        File.WriteAllText(_path + "\\report.txt", stringBuilder.ToString());
    }
}