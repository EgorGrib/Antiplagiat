namespace KysectAcademyTask;

public class BasicComparisonLogic : IComparisonLogic
{
    public Dictionary<string, double> CompareSubmits(List<SubmitFile> submits, 
        ComparisonAlgorithmContext comparisonAlgorithmContext, List<string> whiteList, List<string> blackList)
    {
        var difference = new Dictionary<string, double>();
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
                        if (whiteList is null)
                        {
                            if (blackList is null)
                            {
                                difference.Add($"{submits[i].Path} {submits[j].Path}",
                                    comparisonAlgorithmContext.Calculate(File.ReadAllText(submits[i].Path),
                                        File.ReadAllText(submits[j].Path)));
                                continue;
                            }
                            if (!blackList.Contains(submits[i].StudentName) 
                                && !blackList.Contains(submits[j].StudentName))
                            {
                                difference.Add($"{submits[i].Path} {submits[j].Path}",
                                    comparisonAlgorithmContext.Calculate(File.ReadAllText(submits[i].Path),
                                        File.ReadAllText(submits[j].Path)));
                            }
                            continue;
                        }
                        if (whiteList.Contains(submits[i].StudentName) || whiteList.Contains(submits[j].StudentName))
                        {
                            if (blackList is null)
                            {
                                difference.Add($"{submits[i].Path} {submits[j].Path}",
                                    comparisonAlgorithmContext.Calculate(File.ReadAllText(submits[i].Path),
                                        File.ReadAllText(submits[j].Path)));
                                continue;
                            }
                            if (!blackList.Contains(submits[i].StudentName) 
                                && !blackList.Contains(submits[j].StudentName))
                            {
                                difference.Add($"{submits[i].Path} {submits[j].Path}",
                                    comparisonAlgorithmContext.Calculate(File.ReadAllText(submits[i].Path),
                                        File.ReadAllText(submits[j].Path)));
                            }
                        }
                    }
                }
                Console.Write($"{(double)i / submits.Count:P1}\n");
            }
        }

        return difference;
    }
}