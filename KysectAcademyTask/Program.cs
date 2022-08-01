using KysectAcademyTask;
using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json").Build();

string algorithm = config.GetSection("ComparationAlgorithm").Value;
string inputDirectory = config.GetSection("InputDirectoryPath").Value;
string outDirectory = config.GetSection("Report")["Path"];
string outType = config.GetSection("Report")["Type"];
List<string> extensionWhiteList = config.GetSection("FileFilters")
    .GetSection("ExtensionWhiteList").Get<List<string>>();
List<string> directoryBlackList = config.GetSection("FileFilters")
    .GetSection("DirectoryBlackList").Get<List<string>>();
List<string> whiteList = config.GetSection("AuthorFilters")
    .GetSection("WhiteList").Get<List<string>>();
List<string> blackList = config.GetSection("AuthorFilters")
    .GetSection("BlackList").Get<List<string>>();

try
{
    if (inputDirectory is null)
    {
        throw new ArgumentNullException("inputDirectory");
    }
    if (algorithm is null)
    {
        throw new ArgumentNullException("algorithm");
    }

    if (outDirectory is null && outType != "console")
    {
        throw new ArgumentNullException("outDirectory");
    }

    List<ComparisonResult> difference = new SubmitsComparator(algorithm, directoryBlackList, extensionWhiteList, 
        whiteList, blackList).CompareSubmitsInFolder(inputDirectory);
    
    IReportStrategy report = outType switch
    {
        "txt" => new TxtWriter(outDirectory),
        "json" => new JsonWriter(outDirectory),
        "console" => new ConsoleWriter(),
        _ => throw new InvalidOperationException()
    };
    
    report.Unload(difference);
    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}