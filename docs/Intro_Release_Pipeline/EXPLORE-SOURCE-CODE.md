Lab - Release Pipeline QuickStart
====================================================================================

## Task: Explore the Source Code

## Description
In this lab we will explore the source code of the sample application. 
Earlier you have imported the repo with source code into your team project. 
In this workshop we will use Git for version control. 


## Option #1: Browse the source code in VSTS
**1**. In Visual Studio Team Services, open your Team project and navigate to the Code hub.

![](<media/VSTS-Code-Hub.png>)


## Option #2: Browse the source code using Visual Studio
**1**. In Visual Studio Team Services, open your Team project. Navigate to the Code hub and click on the Clone button in the top right of the window. Copy the command line to your clipboard.

**2**. Open Visual Studio (Since the appplication is build with ASP.NET Core 2.0, you will need Visual Studio 2017 for this lab) 

**3**. Go to View -> Team Explorer (**Tip: use Quick Access Ctrl-Q, type Team Explorer**)

**4**. On the Connect page of the Team Explorer window, click the Clone dropdown located under the Local Git Repositories section

**5**. Paste the URL you have copied to your clipboard in step #1

**6**. If desired, change the local repository path

**7**. Click the Clone button

## Open the Parts Unlimited Visual Studio Solution

### Step 1 
On the Home page of the Team Explorer window, open the solution by double-clicking PartsUnlimited.sln listed under the Solutions section.
If you do not see it listed under the Solutions section, click the Open... link and navigate the local repository folder to open PartsUnlimited.sln

![](<media/TeamExplorer.png>)

### Step 2.
After opening the solution, wait for the Output window Package Manager pane to show "Restore complete" and "Total time" messages.

### Step 3.
Go to Build -> Build Solution.

### Step 4
Go to Debug -> Start Debugging to launch the web application and attach the debugger.

Congratulations, you have cloned the repo and you can work with the solution in Visual Studio.



[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).