# Lab - Release Pipeline QuickStart

## Task: Continuous Deployment with Release Management

### Description

In this lab we will set up **Continuous Deployment** (CD) with Visual Studio Team Services (VSTS).

## Continuous Deployment with Release Management

### Step 1

Navigate to the "Build & Release" tab and click on "Builds".

* The **Mine** page will list the build definition you created in the previous task.
* Select the succesfull build from the previous lab.

![Select succesfull build](<media/SelectSuccesfullBuild.png>)

* Navigate to the summary page of the build.

![Build summary page](<media/BuildSummaryPage.png>)

* Locate the section **Deployments** and click on the link **Create Release**.

> Note the text on your screen may be different from the screenshot presented in this lab.

The Release Definition Editor opens.

![Create release definition select template](<media/CreateReleaseDefinitionSelectTemplate.png>)

* Select the **Azure App Service Deployment** template and click **Apply**.

### Step 2

The release definition that is created contains one Environment. 
This Envrionment contains one task at the moment, the **Deploy Azure App Service** task.
The editor highlights the environment needs our attention, this means the configuration for the environment or task are either **incomplete** or **incorrect**.

![New Release Definition With Errors](<media/NewReleaseDefinitionWithErrors.png>)

VSTS helps you by highlighting the fields you need to complete or fix.
Click on the "1 phase, 1 task" link in the environment.

![Fix errors in Task 1](<media/NewReleaseDefinitionErrors.png>)

First you need to specify the Azure subscription. For this you need to create a Service Endpoint.

> Service endpoints are a way for Visual Studio Team Services to connect to external systems or services, in this case your Azure Subscription. They are a bundle of properties securely stored by VSTS which includes but is not limited to:
>* Service Name
>* Description
>* Server URL
>* Certificates or Tokens
>* User names and passwords
>
> VSTS Release Management is able to leverage the service endpoint to acquire the stored details to perform the necessary operations on that service.

Since this is a new Team Project and you have no extising endpoints, click **Manage**;
Next select **New Service Endpoint** and select **Azure Resource Manager** in the list.

![New Service Endpoint](<media/NewServiceEndpoint.png>)

Complete the details, provide a name for the **connection**, the details of your subscription should already been retrieved.
When clicking OK, it might prompt you for your credentials, it also might be that you don't get the prompt, so two advices:

* Keep an eye on your popup blocker, it might block the relevant popup that prompts for credentials
* If it doesn't work, start an InPrivate/Incognito browser session to create the endpoint

![Add ARM Service Endpoint](<media/AddARMServiceEndpoint.png>)

Next return to your release definition, refresh the Azure subscription list, and select the connection you just created.
Also you need to specify the App Service Name, select the name of the web site we have created in the Azure Portal during the previous lab.

### Step 3

Save the release definition by clicking on **Save**, you can specify a comment (this is optional), next click **OK**.
Congratulations, you have create the first version of your release definition.

### Step 4

To test the Release Definition, we are going to queue a new release, click on **Release** in the toolbar, and select **Create Release**.
Complete the new release dialog, specify a release description, select a build from the dropdown in the artifacts section. 
Click **Create** to queue the release.

You should see a message (just below the toolbar), stating that your release has been created.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).
