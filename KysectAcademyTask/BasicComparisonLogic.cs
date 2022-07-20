namespace KysectAcademyTask;

public class BasicComparisonLogic : IComparisonLogic
{
    public Dictionary<string, double> CompareSubmits(List<SubmitFile> submits, 
        ComparisonAlgorithmContext comparisonAlgorithmContext, List<string>? whiteList, List<string>? blackList)
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
                        if (whiteList is not null)
                        {
                            if (whiteList.Contains(submits[i].StudentName) 
                                || whiteList.Contains(submits[j].StudentName))
                            {
                                if (blackList is not null)
                                {
                                    if (blackList.Contains(submits[i].StudentName) 
                                        || blackList.Contains(submits[j].StudentName))
                                    {
                                        continue;
                                    }
                                    difference.Add($"{submits[i].Path} {submits[j].Path}",
                                        comparisonAlgorithmContext.Calculate(File.ReadAllText(submits[i].Path),
                                            File.ReadAllText(submits[j].Path)));
                                }
                                else
                                {
                                    difference.Add($"{submits[i].Path} {submits[j].Path}",
                                        comparisonAlgorithmContext.Calculate(File.ReadAllText(submits[i].Path),
                                            File.ReadAllText(submits[j].Path)));
                                }
                            }
                        }
                        else
                        {
                            if (blackList is not null)
                            {
                                if (blackList.Contains(submits[i].StudentName) 
                                    || blackList.Contains(submits[j].StudentName))
                                {
                                    continue;
                                }
                                difference.Add($"{submits[i].Path} {submits[j].Path}",
                                    comparisonAlgorithmContext.Calculate(File.ReadAllText(submits[i].Path),
                                        File.ReadAllText(submits[j].Path)));
                            }
                            else
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