namespace KysectAcademyTask;

public interface IComparisonLogic
{
    List<ComparisonResult> CompareSubmits(List<SubmitFile> submits);
}