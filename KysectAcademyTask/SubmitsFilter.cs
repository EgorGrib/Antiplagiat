namespace KysectAcademyTask;

public class SubmitsFilter
{
    public void AddSubmitsWithFilters(SubmitsContainer submitsContainer, string[] files, 
        List<string> dirFilter, List<string> extensionWhiteList)
    {
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
                    submitsContainer.Add(file);
                }
                else 
                {
                    if (dirFilter is not null && dirFilter.Any(s=>file.Contains(s)))
                        continue;
                    if (extensionWhiteList.Any(s=>file.EndsWith(s)))
                    {
                        submitsContainer.Add(file);
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
                    submitsContainer.Add(file);
                }
                else if (!dirFilter.Any(s=>file.Contains(s)))
                {
                    submitsContainer.Add(file);
                }
            }
        }
    }
}