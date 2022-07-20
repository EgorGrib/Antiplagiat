namespace KysectAcademyTask;

public interface IReportStrategy
{
    public void Unload(string path, Dictionary<string, double> data);
}