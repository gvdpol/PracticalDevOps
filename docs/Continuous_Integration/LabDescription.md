Lab - Continuous Integration
====================================================================

In the [Release Pipeline QuickStart](../Intro_Release_Pipeline/LabDescription.md) lab we have created the first Build and Release pipeline for the Parts Unlimited Application. 
We now want to set up Visual Studio Team Services to be able continuously integrate code into the master branch of code. 
This means that whenever code is committed and pushed to the master branch, we want to ensure that it integrates into our code correctly to get fast feedback. 
To do so, we are going to be configure our Build Definition to support Continuous Integration that will allow us to compile and run unit tests on our code every time a commit is pushed to Visual Studio Team Services.

## Tasks Overview: ###

#### Task #1. Configure Continuous Integration
In this task, you will configure our existing build definition that will be triggered every time a commit is pushed to your repository in Visual Studio Team Services.
We will also include a task to publish the test results to VSTS.

#### Task #2. Test the CI Trigger in Visual Studio Team Services:
In this task, test the Continuous Integration build (CI) build we created by changing code in the Parts Unlimited project with Visual Studio Team Services.

#### Task #3. Explore the Build Definition:
In this task, we will explore the options available in the Build Definition.


## Task #1. Configure Continuous Integration

In this task, you will configure our existing build definition that will be triggered every time a commit is pushed to your repository in Visual Studio Team Services.
A continuous integration build will give us the ability check whether the code we checked in can compile and will successfully pass any automated tests that we have created against it.
We will also include a task to publish the test results to VSTS. 

### Step 1.

Click on the **Build and Release** hub at the top of the page, select **Builds** from the pull down menu; 
Select and open the definition you have created the previous lab, next click on the **Edit** link.

### Step 2.

Select the Triggers tab and change the status for **Continuous Integration** to enabled. 
Select include for the branch filter and select the master branch. With this change your definition is triggered by changes that are pushed.

 ![](<media/EnableCITrigger.png>)


### Step 3.

The build is executing test cases, but the results are not yet presented on our summary page. 
Go back to the **Tasks** tab of the build definition. 
Click **Add Task**, in the dialog that opens, select the **Test** page and add a **Publish Test Results** task.
The step is added to the end of the list, drag the task to right after the Test step. 

 ![](<media/CI7.png>)

### Step 4.

On the **Publish Test Results** task, change the **Test Result Format** to **VSTest** and the **Test Results File** to **\*\*/testresults.trx**.

### Step 5.

Select the Test step and add the following **--no-build --logger "trx;LogFileName=testresults.trx"** to the arguments property.
The extra parameter **no-build** prevents the code being build again

### Step 6.

Click **Save** to save your changes.

## Task 2. Test the CI Trigger in Visual Studio Team Services

We will now test the **Continuous Integration build (CI)** build we created by changing code in the Parts Unlimited project with Visual Studio Team Services.

### Step 1.

Select the **Code** hub.

### Step 2.

(1) Click on Code, (2-5) navigate to **/src/PartsUnlimitedWebsite/Controllers** folder,  select the **HomeController.cs** file and then click on **Edit** in the toolbar.

![](<media/CI15.png>)

### Step 3.
After clicking **Edit**, add an extra comment (i.e. *// This is a test of CI*) after the last *Using* statement. 
Once complete, click **Save**.

![](<media/CI16.png>)

### Step 4.

Click **Build and Release** hub, and check if a new build is started for your build definition. 

![](<media/CI17.png>)

### Step 5.

Click on the **Build**, to see the build in progress. 
Here you can also see the commands being logged to console and the current steps that the build is on.

![](<media/CI17.1.png>)

### Step 6.
Click on the **Build Number** on the top left and you should get a build summary similar to this, which includes test results.

![](<media/CI18.png>)

## Task 3. Explore the Build Definition

The Build Editor provides functionality the edit our Build Definitions. 
In this task we will explore some of the options available to us.

### Step 1 Edit Build Task

You can rename your build steps to better describe the specifiy activity of the build.
Change the display name of the task

![](<media/EditNameOfBuildStep.png>)

### Step 2 - Enabled property

Each task has a property called **Enabled**.
You can use this if not all of the details are specified.
By disabling the step, you can save your build definition and later return to complete the details and enable the step.

### Step 3 - Version selector

A build task can have multiple versions. With the version selector you can This will allow you to specify the version of the task that works for your build definition.
You can experiment with newer versions of the task to see if a newer version does break your build.

### Step 4 - Variables

You can use variables for the values of the step properties. 
Look at the Test step, you notice that it makes use of **$(BuildConfiguration)**.
If you navigate to the variable section of the Build Definition you will see this variable listed.

![](<media/BuildDefinitionVariables.png>)

While you are here, take a look at the list of [pre-defined variables](https://go.microsoft.com/fwlink/?LinkId=550988).

### Step 5 - Variable -> how to work with secret values for variables

You mark each variable as a secret variable by enabling the lock in the row the variable is defined in.
This is very useful for passwords.

Secret variables are:
- Encrypted with at rest with a 2048-bit RSA key.
- Not returned back to the client. They are automatically masked out of any log output from the build or release. 
- Not decrypted into environment variables. So scripts and programs run by your build steps are not given access by default.
- Decrypted for access by your build steps. So you can use them in password arguments (for example Build and Deploy your Java application to an Azure web app and also pass them explicitly into a script or a program from your build step (for example as $(password)).

### Step 6 - Variables -> Allow at queue time

In the list you notice the **system.debug** variable variable with a default value of 'false'
The "Allow at Queue Time checkbox for this variable is checked, that means you enter / change the value when queing a new build.
Queue a new build now and change the value of the **system.debug** variable to true and take a close look at the output when the build is running.

### Step 7

Take a look at the other sections of the build definition to get familiar with the options.

Next steps
----------

In this lab, you learned how to change our build definition into a Continuous Integration build that runs when new commits are pushed to the master branch.
This allows you to get feedback as to whether your changes made breaking syntax changes, or if they broke one or more automated tests, or if your changes are okay.

[Back to Labs overview](../../Readme.md).
