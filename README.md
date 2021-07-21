# CustomizationBuildScript
This is a sample project that demonstrates Acumatica's customization project build tool. This project requires Acumatica 2017R2 update 6 or higher to work.

Folder structure:  
|  
|-- Site - folder that should contain Acumatica site  
|-- Builds - Output folder for customization projects(will be created automatically)  
|-- CustomizationBuildScript - root folder of this repository  


PX.CommandLine.exe
Located in Bin folder of Acumatica installation. 
Starting with 2017R2 update 6 new method is available:
PX.CommandLine.exe /method BuildProject
/in "path\to\source\folder" 
/out "path\to\output\file.zip" 
[/website "path\to\site\root\"]
[/include "path\to\additional\files.ext“ “site\relative\path\to\file.ext"]... 
[/includeDirectory “path\to\directory” “site\relative\path”]...
[/description "Package description"] 
[/level "customization level"]

/method – Required. Action that will be executed.
/in – Required. Path to folder that will be used as a base for new customization package, it could contain either an customization project that will be modified, or just files that will be included into new customization project.
/out – Required. Path to resulting customization package. Output will be a zip archive.
/website – Optional. Path to web site folder, can be omitted if tool executable is inside site's \bin folder.
/include – Optional. Has two parameters - an absolute path to file that should be added to package and a relative path inside site folder where this file will be copied after customization is published, both paths should contain filename with extension. This argument can be repeated more than one time.
/includeDirectory – Optional. Has two parameters - an absolute path to folder that contains files that should be added to package and a relative path inside site folder where these files will be copied after customization is published. This argument can be repeated more than one time.
/description - Optional. Description of customization package.
/level - Optional. Level of customization package, should be an integer.




