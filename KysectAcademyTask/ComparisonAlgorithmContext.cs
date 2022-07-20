namespace KysectAcademyTask;

public class ComparisonAlgorithmContext
{
    private IComparisonAlgorithm _comparisonAlgorithm;

    public ComparisonAlgorithmContext(IComparisonAlgorithm comparisonAlgorithm)
    {
        _comparisonAlgorithm = comparisonAlgorithm;
    }

    public double Calculate(string source, string target)
    {
        return _comparisonAlgorithm.CalculateSimilarity(source, target);
    }
}