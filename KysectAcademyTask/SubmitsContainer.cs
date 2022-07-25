namespace KysectAcademyTask;

public class SubmitsContainer
{
    public List<SubmitFile> Submits { get; set; }
    private readonly string _inputDirectoryName;

    public SubmitsContainer(string path)
    {
        Submits = new List<SubmitFile>();
        _inputDirectoryName = path.Split("/")[^1];
    }

    public void Add(string submitFile)
    {
        Submits.Add(new SubmitFile(submitFile, _inputDirectoryName));
    }
}