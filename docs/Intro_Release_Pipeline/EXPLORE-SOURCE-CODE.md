# Lab - Release Pipeline QuickStart

## Task: Explore the Source Code

## Description

In this lab we will explore the source code of the sample application.
Earlier you have imported the repo with source code into your team project.
In this workshop we will use Git for version control.

## Option #1: Browse the source code in Azure DevOps

**1**. In Azure DevOps, open your Team project and navigate to the Azure Repos hub.

![Code hub](<media/VSTS-Code-Hub.png>)

## Option #2: Browse the source code using Visual Studio

1. In Azure DevOps, open your Team project. Navigate to the Azure Repos hub and click on the Clone button in the top right of the window. 
1. Click the pulldown menu and select Visual Studio
![Clone in Visual Studio](<media/clone_visualstudio.png>)
1. Confirm any browser (security) questions
1. If desired, change the local repository path
1. Click the **Clone/Connect** button

## Open the Parts Unlimited Visual Studio Solution

### Step 1

On the Home page of the Team Explorer window, open the solution by double-clicking PartsUnlimited.sln listed under the Solutions section.
If you do not see it listed under the Solutions section, click the Open... link and navigate the local repository folder to open PartsUnlimited.sln

![Team Explorer](<media/TeamExplorer.png>)

### Step 2

After opening the solution, wait for the Output window Package Manager pane to show "Restore complete" and "Total time" messages.

### Step 3

Go to Build -> Build Solution.

### Step 4

Go to Debug -> Start Debugging to launch the web application and attach the debugger.

Congratulations, you have cloned the repo and you can work with the solution in Visual Studio.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).