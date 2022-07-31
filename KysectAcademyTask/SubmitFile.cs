namespace KysectAcademyTask;

public class SubmitFile
{
    public string Path { get; }
    public string StudentName { get; }
    public string LaboratoryWorkName { get; }
    public string Extension { get; }

    public SubmitFile(string path)
    {
        Path = path.Replace("\\", "/");
        string s = Path.Remove(0, Path.IndexOf("RootDirectoryTest"));
        string[] splitted = s.Split("/");
        StudentName = splitted[2];
        LaboratoryWorkName = splitted[3];
        string[] ext = splitted[^1].Split(".");
        Extension = ext.Length == 1 ? "" : splitted[^1].Split(".")[1];
    }
}