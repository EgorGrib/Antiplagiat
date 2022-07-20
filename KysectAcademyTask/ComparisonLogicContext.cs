namespace KysectAcademyTask;

public class ComparisonLogicContext
{
    private IComparisonLogic _comparisonLogic;
    
    public ComparisonLogicContext(IComparisonLogic comparisonLogic)
    {
        _comparisonLogic = comparisonLogic;
    }

    public Dictionary<string, double> CompareSubmits(List<SubmitFile> submits, 
        ComparisonAlgorithmContext comparisonAlgorithmContext, List<string>? whiteList, List<string>? blackList)
    {
        return _comparisonLogic.CompareSubmits(submits, comparisonAlgorithmContext, whiteList, blackList);
    }
}