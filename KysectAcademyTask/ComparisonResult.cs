namespace KysectAcademyTask;

public class ComparisonResult
{
    public string FirstPath { get; }
    public string SecondPath { get; }
    public double Similarity { get; }

    public ComparisonResult(string firstPath, string secondPath, double similarity)
    {
        FirstPath = firstPath;
        SecondPath = secondPath;
        Similarity = similarity;
    }
}