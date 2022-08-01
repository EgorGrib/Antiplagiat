namespace KysectAcademyTask;

public class ConsoleWriter : IReportStrategy
{
    public void Unload(List<ComparisonResult> data)
    {
        foreach (ComparisonResult d in data)
        {
            Console.WriteLine($"{d.FirstPath} {d.SecondPath} {d.Similarity:P2}");
        }
    }
}