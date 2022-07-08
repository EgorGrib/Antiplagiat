using System.Text;
using KysectAcademyTask;
using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json").Build();

IConfigurationSection inputfile = config.GetSection("folder");
IConfigurationSection outFile = config.GetSection("out");

string? folderPath = inputfile.Get<string>();
string? outPath = outFile.Get<string>();

try
{
    string[] files = Directory.GetFiles(folderPath!);
    var paths = files.ToList();
    if(files.Length == 0)
    {
        Console.WriteLine("There are no files in the folder");
    }
    else
    {
        var difference = new Dictionary<string, double>();
        for (int i = 0; i < paths.Count; i++)
        {
            for (int j = i; j < paths.Count; j++)
            {
                if (i != j) 
                {
                    difference.Add($"{files[i]} {files[j]}", 
                        LevenshteinDistance.CalculateSimilarity(File.ReadAllText(files[i]), 
                            File.ReadAllText(files[j])));
                }
            }
        }
        var stringBuilder = new StringBuilder();
        foreach (KeyValuePair<string, double> dif in difference)
        {
            //Console.WriteLine(dif.Key + $" {dif.Value:P2}");
            stringBuilder.Append(dif.Key + $" {dif.Value:P2}\n");
        }
        File.WriteAllText(outPath!, stringBuilder.ToString());
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}