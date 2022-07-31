using System.Text;

namespace KysectAcademyTask;

public class TxtWriter : IReportStrategy
{
    private readonly string _path;
    public TxtWriter(string path)
    {
        _path = path;
    }
    
    public void Unload(List<ComparisonResult> data)
    {
        var stringBuilder = new StringBuilder();
        foreach (ComparisonResult d in data)
        {
            stringBuilder.Append($"{d.FirstPath} {d.SecondPath} {d.Similarity:P2}\n");
        }
        File.WriteAllText(_path + "\\report.txt", stringBuilder.ToString());
    }
}