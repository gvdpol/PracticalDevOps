# Lab - Continuous Integration

## Description

In the [Release Pipeline QuickStart](../Intro_Release_Pipeline/LabDescription.md) lab we have created the first Build and Release Pipeline for the Parts Unlimited Application. 
We now want to set up Azure DevOps to be able continuously integrate code into the master branch of code. 
This means that whenever code is committed and pushed to the master branch, we want to ensure that it integrates into our code correctly to get fast feedback. 
To do so, we are going to configure our Build Pipeline to support Continuous Integration that will allow us to compile and run unit tests on our code every time a commit is pushed to Azure DevOps.

## Task #1. Configure Continuous Integration

In this task, you will configure your existing Build Pipeline that will be triggered every time a commit is pushed to your repository in Azure DevOps.
A continuous integration build will give us the ability check whether the code we committed can compile and will successfully pass any automated tests that we have created against it.
We will also include a task to publish the test results to Azure DevOps.

### Step 1 - Change the build

Click the **Pipelines** hub on the left and select **Pipelines**;
Select the definition you have created the previous lab and click the **Edit** button.

![Edit Build Pipeline](<media/EditBuildDefinition.png>)

### Step 2 - Enable CI

Select the Triggers tab and change the status for **Continuous Integration** to enabled.
Select include for the branch filter and select the master branch (probably no action is required, as this is the default). With this change your definition is triggered by changes that are pushed.

Save the changes to the Build Pipeline **without** queueing it.

 ![Enable CI Trigger](<media/EnableCITrigger.png>)

## Task 2. Test the CI Trigger in Azure DevOps

We will now test the **Continuous Integration build (CI)** build we created, by changing code in the *Parts Unlimited* project with Azure DevOps.

### Step 1 - Code

Select the **Repos** hub.

### Step 2 - Edit the code

(1) Click **Files**, (2-5) navigate to **/src/PartsUnlimitedWebsite/Controllers** folder,  select the **HomeController.cs** file and then click on **Edit** in the toolbar.

![Edit HomeControler.cs](<media/CI15.png>)

### Step 3 - Commit the code

After clicking **Edit**, add an extra comment (i.e. *// This is a test of CI*) after the last *Using* statement.
Once complete, click **Commit** and optionally change the comment to explain the change.

![Click Save](<media/CI16.png>)

### Step 4 - Check build

Click **Pipelines** hub and select **Pipelines**. Check if a new build is started for your Build Pipeline.

![CI build is running](<media/CI17.png>)

### Step 5 - Build progress

Click on the **Build number**, and then on **Agent job 1** to see the build in progress.
Here you can also see the commands being logged to console and the current steps that the build is working on.

![See build progress](<media/CI17.1.png>)

### Step 6 - Build results

Click the back icon or the build number at the top to go to the **Summary**. 

![Back to summary](<media/BackToSummary.png>)

You should get a build summary similar to this, which includes test results. When you click the **Tests** tab or the **100% passed** link, a detailed overview of test results will be displayed.

![Build succeeded](<media/CI18.png>)

## Task 3. Explore the Build Pipeline

The Build Editor provides functionality to edit our Build Pipelines.
In this task we will explore some of the options available to us.

From the Build report, click the **...** button and choose **Edit pipeline**.

![Edit pipeline from Build summary](<media/EditPipelineFromBuildReport.png>)

### Step 1 Edit Build Task

You can rename your build steps to better describe the specific activity of the build.
Change the display name of the task

![Edit Name Of Build Step](<media/EditNameOfBuildStep.png>)

### Step 2 - Enabled property

Each task has a property called **Enabled**. It is available under the **Control Options** section, or you can right-click the task.

You can use this if not all of the details are specified.
By disabling the step, you can save your Build Pipeline and later on, return to complete the details and enable the step.

### Step 3 - Version selector

A build task can have multiple versions. With the version selector you can change the major version of the task. This will allow you to specify the version of the task that works for your Build Pipeline.
You can experiment with newer versions of the task to see if a newer version does break your build.

### Step 4 - Variables

You can use variables for the values of the step properties.
Look at the Test step, you notice that it makes use of **$(BuildConfiguration)**.
If you navigate to the variable section of the Build Pipeline you will see this variable listed.

![Build Pipeline Variables](<media/BuildDefinitionVariables.png>)

While you are here, take a look at the list of [pre-defined variables](https://go.microsoft.com/fwlink/?LinkId=550988).

### Step 5 - Variable -> how to work with secret values for variables

You mark each variable as a secret variable by enabling the lock in the row the variable is defined in.
This is very useful for passwords.

Secret variables are:

* Encrypted with at rest with a 2048-bit RSA key
* Not returned back to the client. They are automatically masked out of any log output from the build or release. 
* Not decrypted into environment variables. So scripts and programs run by your build steps are not given access by default.
* Decrypted for access by your build steps. So you can use them in password arguments (for example Build and Deploy your Java application to an Azure web app and also pass them explicitly into a script or a program from your build step (for example as $(password)).

Note: if a variable value already contains data and the "lock" is clicked, the data is **not** retained!

### Step 6 - Variables -> Allow at queue time

In the list you notice the **system.debug** variable with a default value of 'false'
The "Settable at queue time" checkbox for this variable is checked, that means you enter / change the value when queing a new build.
Queue a new build now and change the value of the **system.debug** variable to true and take a close look at the output when the build is running. This will not change the **system.debug** value of the Build Pipeline, only of the Build that you queued.

### Step 7

Take a look at the other sections of the Build Pipeline to get familiar with the options.

## Next steps

In this lab, you learned how to change our Build Pipeline into a Continuous Integration Build Pipeline that runs when new commits are pushed to the master branch.
This allows you to get feedback as to whether your changes made breaking syntax changes, or if they broke one or more automated tests, or if your changes are okay.

[Back to Labs overview](../../Readme.md).
