namespace KysectAcademyTask;

internal class ReportStrategyContext
{
    private readonly IReportStrategy _reportStrategy;

    public ReportStrategyContext(IReportStrategy reportStrategy)
    {
        _reportStrategy = reportStrategy;
    }

    public void Write(Dictionary<string, double> data)
    {
        _reportStrategy.Unload(data);
    }
}