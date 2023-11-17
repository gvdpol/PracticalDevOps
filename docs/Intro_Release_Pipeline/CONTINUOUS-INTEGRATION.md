# Lab - Release Pipeline QuickStart

## Task: Setup Continuous Integration

## Description

Continuous Integration (CI) is the practice used by development teams to automate the merging and testing of code.
Implementing CI helps to catch bugs early in the development cycle, which makes them less expensive to fix.
Automated tests execute as part of the CI process to ensure quality.
Artifacts are produced from CI systems and fed to release pipelines to drive frequent deployments.

Build and Release are two of the services in Azure DevOps that help you manage continuous integration and delivery of your applications.
The Build service in Azure Pipelines helps you set up and manage CI for your applications.

In this lab we will setup CI with Azure DevOps.
Continuous Integration builds the app and runs unit tests whenever code is pushed to the master branch.
After the CI step succeeds it will trigger a deployment, we will configure this in a next lab.

## Pre-requisites

- Have the repo imported into your Team project

## Create our first Build Definition

### Step 1. Navigate to the "Pipelines" hub and click on "Pipelines"

![Build And Release Hub](<media/VSTS-BuildAndRelease-Hub.png>)

-----------------------------------------------------------------

### Step 2. Create a new Build Definition

Click on the **Create pipeline** button, click the link **Use the classic editor** and select the **Azure Repos Git** option if not selected. The team project, Repository and master branch are probably selected. If not, do so and click **Continue**.

![Build select repository](<media/4k.png>)

Select the **"ASP.NET Core"** template from the list (it might be displayed under "Other" instead of "Featured") and click **"Apply"**. The Build Definition Editor opens with the tasks selected for this specific template.

![Build template ASP.Net Core](<media/4.png>)

### Step 3. Complete the build definition

The **Pipelines Editor** opens with the build definition just created.
The Editor highlights that a setting requires your attention.

-----------------------------------------------------------------
Select **Pipeline** from the list, and make sure the "Azure Pipelines" Agent pool is selected and **"Agent Specification"** is set to "windows-2019".

![Select agent](<media/4f.png>)

> Note: To build your code or deploy your software you need at least one agent. As you add more code and people, you'll eventually need more.
When your build or deployment runs, the system begins one or more jobs. An agent is installable software that runs one build or deployment job at a time.

-----------------------------------------------------------------
Let's look at the other items in the Build Definition. Below Pipeline you will find the **Get Sources** task, this is a build-in task you will find in every build definition.
Next you will see a list of tasks more specific to the application that will be built.
The first 4 out of this list are tasks that are mapped to the dotnet core commands: **restore**, **build**, **test** and **publish**. The icon in front of the task highlights this.
The last task, that has been added as part of this template is the **publish artifact** task.

-----------------------------------------------------------------

![Build tasks](<media/4b.png>)

## Info: What is a Task

1. > A **task** is the building block for defining automation in a build definition (tasks are also used within an environment of a release definition. A task is simply a packaged script or procedure that has been abstracted with a set of inputs. Azure DevOps provides some built-in tasks to enable fundamental build and deployment scenarios. In addition, the Visual Studio Marketplace offers a number of extensions; each of which, when installed to your account or collection, extends the **task catalog** with one or more tasks. Furthermore, you can write your own custom extensions to add tasks to your account in Azure DevOps.

2. > When you add a task to your build or release definition, it may also add a set of **demands** to the definition. The **demands** define the prerequisites that must be installed on the agent for the task to run. When you run the build or deployment, an agent that meets these demands will be chosen.

3. > When you queue a build or a deployment, all the tasks are run in sequence, one after the other, on an agent. To run the same set of tasks in parallel on multiple agents, or to run some tasks without using an agent, see phases.

-----------------------------------------------------------------

## Info: Task Versions

1. > Each task has a Version selector that enables you to specify the major version of the task used in your build or deployment. This can help to prevent issues when new versions of a task are released. Tasks are typically backwards compatible, but in some scenarios you may encounter unpredictable errors when a task is automatically updated.

2. > When a new minor version is released (for example, 1.2 to 1.3), your build or release will automatically use the new version. However, if a new major version is released (for example 2.0), your build or release will continue to use the major version you specified until you edit the definition and manually change to the new major version. The build or release log will include an alert that a new major version is available.
    - > If you select a preview version (such as 1.* Preview), be aware that this version is still under development and might have known issues.

    - > If you change the version and have problems with your builds, you can revert the definition change from the History tab. The ability to restore to an older version of a release definition is not currently available. You must manually revert the changes to the release definition, then save the definition.

    - > Consider cloning the definition and testing the cloned definition with the new major task version.

-----------------------------------------------------------------

### Step 4. Save your Build Definition

Click on "Save & queue" and choose "Save" > click "Save" (don't change the folder setting).

-----------------------------------------------------------------

### Step 5. Queue a build (test your build definition)

At this stage it's a good idea to check that the build definition successfully builds your project. Trigger the new build with default settings by clicking on the "Queue" button.
A dialog opens with the settings selected for your build, click **Run**.

![Run pipeline](<media/4h.png>)

> **Note:**
> Your build will be queued. The build process may take a while, while the build executes, take the time to explore the other sections of the build definition.

![Build has been queued](<media/4i.png>)

> You can see your build has been assigned a build number, you can monitor the execution of the build by clicking **Agent job 1**.

![Build progress](<media/4j.png>)

After your build has finished, look at the results.
If you have an issue, locate the task with the issue, identify the problem. Fix your issue(s) and queue an new build.
Repeat this until you have a succesfull build.

Congratulations, you have successfully created and queued a build definition. It is actually not yet a Continuous Integration build but we will fix this in a later lab when we will explore **Continuous Integration** in more detail.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).
