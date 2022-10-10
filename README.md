# The system for checking the honesty of students' assignments. 
Using the Levenshtein distance algorithm, the percentage of similarity of each file in the specified folder is calculated in pairs. The appsettings.json file specifies the application configuration, you must specify the folder in which the students' work is located, the type and path of the report with the result of the comparison (txt/json/console). It is also possible to set filters: a white list of file extensions, a blacklist of directories (files in which you do not need to compare) and a blacklist/whitelist of students (authors of works). 

The directory with students' work has the following structure
```
RootDirectory/
-GroupName1 (for exampl - "M3234")
	-AuthorName1 (for exampl - "Andrew Gray")
		-HomeworkName1 (for exampl - "4. INI файл")
			-SubmitDate1 (for example - "20191118202349")
				-*files with code*
			-SubmitionDate2
				-...
		-HomeworkName2
			-...
	-AuthorName2
		-...
-GroupName2
	-...
```

Сonfig file example (appsettings.json)
```
{
	ComparationAlgorithms: "LevenshteinDistance",
	InputDirectoryPath: "P:/ath/To/Input",
	Report:
	{
		Path: "P:/ath/to/Outpout",
		Type: "JSON"
	},
	FileFilters:
	{
		ExtensionWhiteList: [ "cs", "py", "java" ],
		DirectoryBlackList: [ ".git", ".vs", "bin" ]
	},
	AuthorFilters:
	{
		WhiteList: [ "Username1", "Username2" ],
		BlackList: [ "Username3", "Username4" ]
	}
}
