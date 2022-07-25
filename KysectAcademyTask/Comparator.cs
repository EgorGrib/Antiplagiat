namespace KysectAcademyTask;

public class Comparator
{
    public Dictionary<string, double> CompareFilesInFolder(string algoritm, string path, List<string> dirFilter, 
        List<string> extensionWhiteList, List<string> whiteList, List<string> blackList)
    {
        string[] files = DirSearch(path).ToArray();
        var submitsContainer = new SubmitsContainer(path);
        
        if(files.Length == 0)
        {
            throw new Exception("There are no files in the folder");
        }

        new SubmitsFilter().AddSubmitsWithFilters(submitsContainer, files, dirFilter, extensionWhiteList);

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
        return comparisonLogicContext.CompareSubmits(submitsContainer.Submits, 
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