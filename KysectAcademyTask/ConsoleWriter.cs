namespace KysectAcademyTask;

public class ConsoleWriter : IReportStrategy
{
    public void Unload(string path, Dictionary<string, double> data)
    {
        foreach (KeyValuePair<string, double> d in data)
        {
            Console.WriteLine(d.Key + $" {d.Value:P2}");
        }
    }
}