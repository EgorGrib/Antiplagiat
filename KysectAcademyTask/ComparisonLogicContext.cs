namespace KysectAcademyTask;

public class ComparisonLogicContext
{
    private readonly IComparisonLogic _comparisonLogic;
    
    public ComparisonLogicContext(IComparisonLogic comparisonLogic)
    {
        _comparisonLogic = comparisonLogic;
    }

    public List<ComparisonResult> CompareSubmits(List<SubmitFile> submits)
    {
        return _comparisonLogic.CompareSubmits(submits);
    }
}