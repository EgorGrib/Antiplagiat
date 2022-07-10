namespace KysectAcademyTask;

public class Comparator
{
    public Dictionary<string, double> CompareFilesInFolder(string path)
    {
        string[] files = Directory.GetFiles(path);
        var paths = files.ToList();
        var difference = new Dictionary<string, double>();
        if(files.Length == 0)
        {
            throw new Exception("There are no files in the folder");
        }
        for (int i = 0; i < paths.Count; i++)
        {
            for (int j = i; j < paths.Count; j++)
            {
                if (i != j)
                {
                    difference.Add($"{files[i]} {files[j]}",
                        new LevenshteinDistance().CalculateSimilarity(File.ReadAllText(files[i]),
                            File.ReadAllText(files[j])));
                }
            }
        }
        return difference;
    }
}