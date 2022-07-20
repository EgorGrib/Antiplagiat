namespace KysectAcademyTask;

public class SubmitFile
{
    public string Path { get; }
    public string StudentName { get; }
    public string LaboratoryWorkName { get; }
    public string Extension { get; }

    public SubmitFile(string path)
    {
        Path = path;
        string replaced = path.Replace("\\", "/");
        string[] splitted = replaced.Split("/");
        StudentName = splitted[4];
        LaboratoryWorkName = splitted[5];
        string[] ext = splitted[^1].Split(".");
        Extension = ext.Length == 1 ? "" : splitted[^1].Split(".")[1];
    }
}