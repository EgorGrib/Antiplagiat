namespace KysectAcademyTask;

public class SubmitsFilter
{
    private readonly List<string> _dirFilter;
    private readonly List<string> _extensionWhiteList;
    private readonly List<string> _blackList;

    public SubmitsFilter(List<string> dirFilter, List<string> extensionWhiteList, List<string> blackList)
    {
        _dirFilter = dirFilter;
        _extensionWhiteList = extensionWhiteList;
        _blackList = blackList;
    }

    public List<SubmitFile> Filter(IReadOnlyCollection<string> input)
    {
        var submits = new List<SubmitFile>();
        if (_dirFilter is not null)
        {
            for (int i = 0; i < _dirFilter.Count; i++)
            {
                _dirFilter[i] = "\\" + _dirFilter[i] + "\\";
            }
        }

        if (_extensionWhiteList is not null)
        {
            foreach (string file in input)
            {
                if (_extensionWhiteList.Any(s => file.EndsWith(s)) && _dirFilter is null)
                {
                    submits.Add(new SubmitFile(file));
                }
                else
                {
                    if (_dirFilter is not null && _dirFilter.Any(s => file.Contains(s)))
                        continue;
                    if (_extensionWhiteList.Any(s => file.EndsWith(s)))
                    {
                        submits.Add(new SubmitFile(file));
                    }
                }

            }
        }
        else
        {
            foreach (string file in input)
            {
                if (_dirFilter is null)
                {
                    submits.Add(new SubmitFile(file));
                }
                else if (!_dirFilter.Any(s => file.Contains(s)))
                {
                    submits.Add(new SubmitFile(file));
                }
            }
        }
        
        return _blackList is null ? submits : submits.Where(t => !_blackList.Contains(t.StudentName)).ToList();
    }
}