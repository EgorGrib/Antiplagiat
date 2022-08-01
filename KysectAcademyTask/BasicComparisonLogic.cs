namespace KysectAcademyTask;

public class BasicComparisonLogic : IComparisonLogic
{
    private readonly IComparisonAlgorithm _comparisonAlgorithm;
    public BasicComparisonLogic(IComparisonAlgorithm comparisonAlgorithm)
    {
        _comparisonAlgorithm = comparisonAlgorithm;
    }

    public List<ComparisonResult> CompareSubmits(List<SubmitFile> submits)
    {
        var difference = new List<ComparisonResult>();
        for (int i = 0; i < submits.Count; i++)
        {
            for (int j = i; j < submits.Count; j++)
            {
                if (i != j)
                {
                    if (submits[i].LaboratoryWorkName == submits[j].LaboratoryWorkName 
                        && submits[i].StudentName != submits[j].StudentName 
                        && submits[i].Extension == submits[j].Extension)
                    {
                        difference.Add(new ComparisonResult(submits[i].Path, submits[j].Path, 
                            _comparisonAlgorithm.CalculateSimilarity(File.ReadAllText(submits[i].Path), 
                                File.ReadAllText(submits[j].Path))));
                    }
                }
                Console.Write($"{(double)i / submits.Count:P1}\n");
            }
        }

        return difference;
    }
}