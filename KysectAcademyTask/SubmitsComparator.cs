namespace KysectAcademyTask;

public class SubmitsComparator
{
    private readonly string _algoritm;
    private readonly List<string> _dirFilter;
    private readonly List<string> _extensionWhiteList;
    private readonly List<string> _whiteList;
    private readonly List<string> _blackList;

    public SubmitsComparator(string algoritm, List<string> dirFilter, List<string> extensionWhiteList, 
        List<string> whiteList, List<string> blackList)
    {
        _algoritm = algoritm;
        _dirFilter = dirFilter;
        _extensionWhiteList = extensionWhiteList;
        _whiteList = whiteList;
        _blackList = blackList;
    }

    public List<ComparisonResult> CompareSubmitsInFolder(string path)
    {
        string[] files = DirSearch(path).ToArray();
        if(files.Length == 0)
        {
            throw new Exception("There are no files in the folder");
        }

        var submitFilter = new SubmitsFilter(_dirFilter, _extensionWhiteList, _blackList);
        List<SubmitFile> submitFiles = submitFilter.Filter(files);

        IComparisonAlgorithm comparisonAlgorithm;
        if (_algoritm == "LevenshteinDistance")
        {
            comparisonAlgorithm = new LevenshteinDistance();
        }
        else
        {
            throw new Exception("Comparison algorithm not found");
        }
        
        var comparisonLogicContext = new ComparisonLogicContext(new BasicComparisonLogic(comparisonAlgorithm));

        return new ComparisonResultFilter(_whiteList)
            .Filter(comparisonLogicContext.CompareSubmits(submitFiles));
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