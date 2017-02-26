Lab #3 - DevOps Introduction - Continuous Deployment with Release Management
====================================================================================

## Description
In this lab we will set up Continuous Deployment (CD) with Visual Studio Team Services (VSTS). 


## Continuous Deployment with Release Management

**Step 1.** 

Navigate to the "Build & Release" tab and click on "Builds".

 
* The **Mine** page will list the build definition you created in the previous lab. 

* Select the succesfull build from the previous lab.

![](<media/SelectSuccesfullBuild.png>)

* Navigate to the summary page of the build. 

![](<media/BuildSummaryPage.png>)

* Locate the section **Deployments** and click on the link **Create Release**. 
* A dialog tells you that you do not yet have a Release Definition associated with this build, Click **Yes** to continue.

![](<media/CreateReleaseDefinition.png>)

* Select the **Azure App Service Deployment** template and click **Next**. 
* On the next page, use the deafult settings and click **Create**. This will create our release definition. 
* Click on **Save** and **OK**.  

![](<media/CreateReleaseDefinitionOptions.png>)


**Step 2.** 

The release definition that is created contains one Environment. 
This Envrionment contains one task at the moment, the **Deploy Azure App Service** task.
It is highlighted in red, this means the details for this task are either incomplete or incorrect. 

![](<media/NewReleaseDefinitionWithErrors.png>)

VSTS helps you by highlighting the fields you need to fix.
First you need to specify the Azure subscription.

You need a Service Endpoint. 
Service endpoints are a way for Visual Studio Team Services to connect to external systems or services, in this case your Azure Subscription. 
They are a bundle of properties securely stored by VSTS which includes but is not limited to:
- Service Name
- Description
- Server URL
- Certificates or Tokens
- User names and passwords

VSTS Release Management is able to leverage the service endpoint to acquire the stored details to perform the necessary operations on that service. 

Since this is a new Team Project and you have no extising endpoints, click **Manage**;
Next select **New Service Endpoint** and select **Azure Resource Manager** in the list. 

![](<media/NewServiceEndpoint.png>)

Complete the details, provide a name for the **connection**, the details of your subscription should already been retrieved.

![](<media/AddARMServiceEndpoint.png>)

Then return to your release definition, refresh the AzureRM Subscription list, and select the connection you just created.
Also you need to specify the App Service Name, select the name of the web site we have created in the Azure Portal during the previous lab. 

**Step 3**. 

Save the release definition by clicking on **Save** and **OK**.

Congratulations, you have create the first version of your release pipeline. 

To test the Release Definition, now **Queue a new release**, click on **Release** in the toolbar, and select **Create Release**. 
Complete the new release dialog, specify a release description, select a build from the dropdown in the artifacts section. 
Click **Create** to queue the release.

You should see a message (just below the toolbar), stating that your release has been created.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).