# Lab - Release Pipeline QuickStart

## Task: Continuous Deployment with Release Management

### Description

In this lab we will set up **Continuous Deployment** (CD) with Azure DevOps.

## Continuous Deployment with Release Management

### Step 1

Navigate to the "Pipelines" tab and click on "Pipelines".

* Three views are available; **Recent**, **All** and **Runs**, the build previously created is available all views now. Select the **Recent** view
* Notice the build number (second column)
* Select the succesful build from the previous lab by clicking on the build number.

![Select succesful build](<media/SelectSuccesfullBuild.png>)

* Notice no deployments took place (nothing is mentioned on deployments).
* Click **Pipelines** > **Releases** from the left menu bar and click the **New pipeline** button in the middle of the screen.
> The Release Definition Editor opens.
* Select the **Azure App Service Deployment** template and click **Apply**.
![Create release definition select template](<media/CreateReleaseDefinitionSelectTemplate.png>)



### Step 2

Change the name of the Release Pipeline by clicking it and changing it in something like PracticalDevOps.CD:

![Change release pipeline name](<media/ReleasePipelineChangeName.png>)

First we need to link the Build **Pipeline** we created to this Release **Pipeline**. This will take care that the output of the Build can be used to deploy to Azure. On the left-hand side we see a section called **Artifacts**. Click **+ Add**. 

![Add Build Artifact](<media/AddBuildArtifact.png>)

As a project, select the name of your Team Project, probably "PracticalDevOps", if it is not selected yet. Then select your Build Pipeline from the dropdown list. Leave **Default version** set to **Latest**. Change the name of the **Source alias** to "BuildArtifact, this is referred to in several places of the Release Pipeline and will remain the same even though you rename the Build Pipeline.

Click **Add** to apply the changes.

![Add Build Artifact to Release](<media/AddBuildArtifactToRelease.png>)

The release definition that is created contains one Stage. 
This Stage contains one task at the moment, the **Deploy Azure App Service** task.
The editor highlights the stage needs our attention, this means the configuration for the stage or task are either **incomplete** or **incorrect**.

![New Release Definition With Errors](<media/NewReleaseDefinitionWithErrors.png>)

Azure DevOps helps you by highlighting the fields you need to complete or fix.
Click on the "1 job, 1 task" link in the stage.

![Fix errors in Task 1](<media/NewReleaseDefinitionErrors.png>)

First you need to specify the Azure subscription. This will automatically add a **Service endpoint** to your Team Project. You can find the **Service endpoint** in **Project settings**.

> Service endpoints are a way for Visual Studio Team Services to connect to external systems or services, in this case your Azure Subscription. They are a bundle of properties securely stored by Azure DevOps which includes but is not limited to:
>* Service Name
>* Description
>* Server URL
>* Certificates or Tokens
>* User names and passwords
>
> Azure DevOps Release Management is able to leverage the service endpoint to acquire the stored details to perform the necessary operations on that service.

Depending on the Azure subscription you are using (Azure Pass, Visual Studio Professional/Ultimate with MSDN, Azure For Students, etc), you will find an entry of which the name will match the Azure offer you are using.

After selecting the subscription, click **Authorize**. This might prompt you for credentials. Also it can take a little while, so be patient.

* Keep an eye on your popup blocker, it might block the relevant popup that prompts for credentials
* If it doesn't work, start an InPrivate/Incognito browser session to create the endpoint

Then specify the App Type, it should be **Web App on Linux**.

Also you need to specify the **App Service Name**, select the name of the web site we have created in the Azure Portal during the previous lab. The name should be available from the pulldown menu. If it isn't, click the "Refresh" icon at the right and try again.

Leave the **Startup command** empty. It is only applicable for containers.

### Step 3

Save the release definition by clicking on **Save**, you can specify a comment (this is optional), next click **OK**.
Congratulations, you have create the first version of your release definition.

### Step 4

To test the Release Definition, we are going to queue a new release, click on  **Create Release**.
Optionally specify a release description, select a build from the dropdown in the artifacts section. 
Click **Create** to queue the release.

You should see a message (just below the toolbar), stating that your release has been created. Click it to see progress.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).
