namespace KysectAcademyTask;

public interface IComparisonLogic
{
    Dictionary<string, double> CompareSubmits(List<SubmitFile> submits, 
        ComparisonAlgorithmContext comparisonAlgorithmContext, List<string> whiteList, List<string> blackList);
}