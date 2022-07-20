using System.Text;

namespace KysectAcademyTask;

public class TxtWriter : IReportStrategy
{
    public void Unload(string path, Dictionary<string, double> data)
    {
        var stringBuilder = new StringBuilder();
        foreach (KeyValuePair<string, double> d in data)
        {
            stringBuilder.Append(d.Key + $" {d.Value:P2}\n");
        }
        File.WriteAllText(path + "\\report.txt", stringBuilder.ToString());
    }
}