namespace KysectAcademyTask;

public class Comparator
{
    public Dictionary<string, double> CompareFilesInFolder(string algoritm, string path, List<string>? dirFilter, 
        List<string>? extensionWhiteList, List<string>? whiteList, List<string>? blackList)
    {
        string[] files = DirSearch(path).ToArray();
        var submits = new List<SubmitFile>();
        
        if(files.Length == 0)
        {
            throw new Exception("There are no files in the folder");
        }

        if (dirFilter is not null)
        {
            for (int i = 0; i < dirFilter.Count; i++)
            {
                dirFilter[i] = "\\" + dirFilter[i] + "\\";
            }
        }
        
        if (extensionWhiteList is not null)
        {
            foreach (string file in files)
            {
                if (extensionWhiteList.Any(s=>file.EndsWith(s)) && dirFilter is null)
                {
                    submits.Add(new SubmitFile(file));
                }
                else 
                {
                    if (dirFilter is not null && dirFilter.Any(s=>file.Contains(s)))
                        continue;
                    if (extensionWhiteList.Any(s=>file.EndsWith(s)))
                    {
                        submits.Add(new SubmitFile(file));
                    }
                }
                
            }
        }
        else
        {
            foreach (string file in files)
            {
                if (dirFilter is null)
                {
                    submits.Add(new SubmitFile(file));
                }
                else if (!dirFilter.Any(s=>file.Contains(s)))
                {
                    submits.Add(new SubmitFile(file));
                }
            }
        }

        ComparisonAlgorithmContext comparisonAlgorithmContext;
        if (algoritm == "LevenshteinDistance")
        {
            comparisonAlgorithmContext = new ComparisonAlgorithmContext(new LevenshteinDistance());
        }
        else
        {
            throw new Exception("Comparison algorithm not found");
        }
        
        var comparisonLogicContext = new ComparisonLogicContext(new BasicComparisonLogic());
        return comparisonLogicContext.CompareSubmits(submits, 
            comparisonAlgorithmContext, whiteList, blackList);
    }
    
    private List<string> DirSearch(string sDir)
    {
        var files = new List<string>();
        try
        {
            files.AddRange(Directory.GetFiles(sDir));
            foreach (string d in Directory.GetDirectories(sDir))
            {
                files.AddRange(DirSearch(d));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return files;
    }
}