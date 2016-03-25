#Resx Resource Translator
Tool for non-developers to quickly translate resource files (resx) in .NET projects to multiple languages in parallel. Shows a tree view of all resources and all translation strings in parallel, one column per language. Compatible with VS2008-VS2015.

#Download
[Check the Releases](https://github.com/HakanL/resxtranslator/releases) or compile the source code in any modern version of Visual Studio.

#Screenshots
![capture](https://cloud.githubusercontent.com/assets/14913904/14054215/c82f9c82-f2d7-11e5-9e7b-9de37814408a.PNG)
![capture1](https://cloud.githubusercontent.com/assets/14913904/14054214/c82ecece-f2d7-11e5-9a90-866dee7bc0be.PNG)

##Usage guidelines
Launch the Resx Resource Translator, go to the File/Open menu option and browse to the root of your Visual Studio project (basically where your SLN file is located). The tool will now iterate thru all sub folders and look for resx files. _(Note that it's not using the SLN or project files, it's just looking for files with file extension resx)._

The left panel will now show a tree view of all found resources. You open a resource by double clicking the tree node. You will then see all resource strings in that file in the right part of the screen.

The top part will show the translated languages identified for this resx file. The Resx Resource Translator bases the presentation on a generic resx file without any translation as the default (called No Language Value in this application). This can be machine-translated or semi-translated. Then it identifies all other languages for that file and displays a list on top with a column for each language. You can hide a language from the grid with the check boxes.
You can navigate between the different resources without saving and without losing your work. Everything is kept in memory until you select File/Save.

##Columns
* Key - this is the internal key that is used in your application. It can't be modified in the ResxTranslator.
* No Language Value - the string value from the main resx file (without a language identifier)
* en, etc - the translated value
* Comments - comments that is never visible in the application, but can help translators understand what is meant. I use it to list what parameters I use in _string.Format_.

The rows that are red means one or more languages are missing values. I have a special case in here where {"[]"} around a value means it's not translated. For example if I haven't done the translation for the _ErrorHeader_ value then I just enter {"[ErrorHeader]"} under that language. That way I will still see something when I develop using that value, but the ResxTranslator will show it red since it's not translated because of the brackets.

##Credit
A big thanks to my friend _Peter Wallin_ who encouraged this development and helped with testing.
Another huge thanks for JorgenLindell for further development of this project!
Enormous thanks to Marcin Szeniak to updating this to version 2.0 with a lot of new functionality!

##Issues and information
* Error handling is more or less non-existent.
* I checked in the binaries so non-developers with TortoiseSVN can easily get the latest version. It helped me while I was developing. I know it's not best practice.
