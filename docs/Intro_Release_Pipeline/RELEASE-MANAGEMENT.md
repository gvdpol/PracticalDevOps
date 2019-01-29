# Lab - Release Pipeline QuickStart

## Task: Continuous Deployment with Release Management

### Description

In this lab we will set up **Continuous Deployment** (CD) with Azure DevOps.

## Continuous Deployment with Release Management

### Step 1

Navigate to the "Pipelines" tab and click on "Builds".

* Two views are available; **Recent** and **Folders**, the build previously created is available in both views now
* Notice the build number (second column)
* Select the succesful build from the previous lab.

![Select succesful build](<media/SelectSuccesfullBuild.png>)

* Navigate to the summary page of the build.
* Notice no deployments took place.

![Build summary page](<media/BuildSummaryPage.png>)

* Click on the button **Release**.

> Note the text on your screen may be different from the screenshot presented in this lab.

The Release Definition Editor opens.

![Create release definition select template](<media/CreateReleaseDefinitionSelectTemplate.png>)

* Select the **Azure App Service Deployment** template and click **Apply**.

### Step 2

The release definition that is created contains one Environment. 
This Envrionment contains one task at the moment, the **Deploy Azure App Service** task.
The editor highlights the environment needs our attention, this means the configuration for the environment or task are either **incomplete** or **incorrect**.

![New Release Definition With Errors](<media/NewReleaseDefinitionWithErrors.png>)

Azure DevOps helps you by highlighting the fields you need to complete or fix.
Click on the "1 job, 1 task" link in the environment.

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

After selecting the subscription, click **Authorize**. This might prompt you for credentials. 

* Keep an eye on your popup blocker, it might block the relevant popup that prompts for credentials
* If it doesn't work, start an InPrivate/Incognito browser session to create the endpoint

Also you need to specify the App Service Name, select the name of the web site we have created in the Azure Portal during the previous lab. The name should be available from the pulldown menu.

### Step 3

Save the release definition by clicking on **Save**, you can specify a comment (this is optional), next click **OK**.
Congratulations, you have create the first version of your release definition.

### Step 4

To test the Release Definition, we are going to queue a new release, click on **+ Release** in the toolbar, and select **Create Release**.
Optionally specify a release description, select a build from the dropdown in the artifacts section. 
Click **Create** to queue the release.

You should see a message (just below the toolbar), stating that your release has been created.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).
