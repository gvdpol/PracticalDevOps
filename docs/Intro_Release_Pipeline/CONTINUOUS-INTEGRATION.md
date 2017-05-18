Lab #3 - Release Pipeline QuickStart - Continuous Integration
====================================================================================

## Description
In this lab we will setup Continuous Integration (CI) with Visual Studio Team Services (VSTS). 
Continuous Integration builds the app and runs unit tests whenever code is pushed to the master branch. 
After the CI step succeeds it will trigger a deployment, we will configure this in a next lab. 

## Pre-requisites:
- First complete Lab #1 to #2

## Set up our first Continuous Integration Build Definition

**Step 1.** Navigate to the "Build & Release" hub and click on "Builds". 

![](<media/VSTS-BuildAndRelease-Hub.png>)

-----------------------------------------------------------------
**Step 2.** Click on the **+ New** button, select the "ASP.NET Core Build (PREVIEW)" template and click "Apply".

![](<media/4.png>)

>**Note:** The steps in this build definition are mapped to the dotnet core commands, it includes the following steps.

![](<media/4b.png>)

-----------------------------------------------------------------
**Step 3.** In the steps "Restore", "Build", change the property "Project(s)" to \*\*/project.json. In the step "Test", change the property "Project(s)" to \*\*/\*Tests/project.json

![](<media/4d.png>)

-----------------------------------------------------------------
**Step 4.** Click on "Save", On the next dialog, enter a name for the build definition, then Click "OK".

![](<media/4c.png>)

-----------------------------------------------------------------
**Step 4.**  At this stage it's a good idea to check that the build definition successfully builds your project. Trigger the new build with default settings by clicking on the "Queue new build..." button and then clicking on "OK".

> **Note:** The build process may take a while, while the build executes, take the time to explore the other sections of the build definition.

Congratulations, you have successfully created a build definition and execute your first build. We will explorer Continuous Integration in more detail in a later lab.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).
