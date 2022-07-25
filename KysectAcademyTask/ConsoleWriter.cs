namespace KysectAcademyTask;

internal class ConsoleWriter : IReportStrategy
{
    public void Unload(Dictionary<string, double> data)
    {
        foreach (KeyValuePair<string, double> d in data)
        {
            Console.WriteLine(d.Key + $" {d.Value:P2}");
        }
    }
}