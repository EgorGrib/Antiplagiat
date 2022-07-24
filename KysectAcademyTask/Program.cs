using System.Text;
using KysectAcademyTask;
using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json").Build();

IConfigurationSection inputfile = config.GetSection("folder");
IConfigurationSection outFile = config.GetSection("out");

string folderSection = inputfile.Get<string>();
string outSection = outFile.Get<string>();

try
{
    if (folderSection is null)
    {
        throw new Exception("Folder path section not found in appsettings.json");
    }
    Dictionary<string, double> difference = new Comparator().CompareFilesInFolder(folderSection);
    var stringBuilder = new StringBuilder();
    foreach (KeyValuePair<string, double> dif in difference)
    {
        //Console.WriteLine(dif.Key + $" {dif.Value:P2}");
        stringBuilder.Append(dif.Key + $" {dif.Value:P2}\n");
    }
    if (outSection is null)
    {
        throw new Exception("Output file path section not found in appsettings.json");
    }
    File.WriteAllText(outSection, stringBuilder.ToString());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}