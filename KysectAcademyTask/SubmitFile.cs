namespace KysectAcademyTask;

public class SubmitFile
{
    public string Path { get; }
    public string StudentName { get; }
    public string LaboratoryWorkName { get; }
    public string Extension { get; }

    public SubmitFile(string path, string rootDirectoryName)
    {
        Path = path;
        string s = path.Remove(0, path.IndexOf(rootDirectoryName));
        string[] splitted = s.Split("\\");
        StudentName = splitted[2];
        LaboratoryWorkName = splitted[3];
        string[] ext = splitted[^1].Split(".");
        Extension = ext.Length == 1 ? "" : splitted[^1].Split(".")[1];
    }
}