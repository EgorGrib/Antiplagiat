namespace KysectAcademyTask;

public class ComparisonResultFilter
{
    private readonly List<string> _whiteList;

    public ComparisonResultFilter(List<string> whiteList)
    {
        _whiteList = whiteList;
    }

    public List<ComparisonResult> Filter(List<ComparisonResult> submits)
    {
        if (_whiteList is null)
        {
            return submits;
        }

        foreach (ComparisonResult submit in 
                 from s in _whiteList.ToList() 
                 from submit in submits.ToList() 
                 where !submit.FirstPath.Contains(s) && !submit.SecondPath.Contains(s) 
                 select submit)
        {
            submits.Remove(submit);
        }

        return submits;
    }
}