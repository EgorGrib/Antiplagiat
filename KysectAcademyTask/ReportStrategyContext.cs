namespace KysectAcademyTask;

public class ReportStrategyContext
{
    private IReportStrategy _reportStrategy;

    public ReportStrategyContext(IReportStrategy reportStrategy)
    {
        _reportStrategy = reportStrategy;
    }

    public void Write(string path, Dictionary<string, double> data)
    {
        _reportStrategy.Unload(path, data);
    }
}