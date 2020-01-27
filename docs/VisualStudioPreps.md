# Visual Studio Preparations

In order for the PartsUnlimited solution to work inside Visual Studio we recommend to take the following actions:

* Ensure you have the latest version of Visual Studio 2019 Community Edition installed (https://docs.microsoft.com/en-us/visualstudio/install/update-visual-studio?view=vs-2019)
* Install NodeJS, both the "LTS" as well as the "Current" version (https://nodejs.org)
	* During the installation of NodeJS ensure you check the following checkbox "Automatically install the necessary tools. Note that this will also install Chocolatey. The script will pop-up in a new window after the installation completes."
* Open a command prompt, change the directory to the one where your project/repo is located (generally c:\users\\[your user name]\source\repos\PracticalDevOps) and run the following commands:
```
npm install -g grunt
npm install -g sass
choco install python2
```
* Navigate to the subfolder src\PartsUnlimited.Website and run the following command:
```
npm rebuild node-sass
```
## Next Step

[Back to Labs overview](../Readme.md).