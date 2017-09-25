Lab - Release Pipeline QuickStart
====================================================================================

## Task: Verify deployment to Azure

## Description
In this lab we will verify the deployment of our Application to Azure

## Confirming successful deployment to Azure

### Step 1.

In the Azure portal, click on App Services in the left menu and select your application from the list.

![](<media/ListAppServiceInAzurePortal.png>)

Make sure the overview menu is selected, next click the **Browse** button in the toolbar (see screenshot) to open your application in the browser. 

![](<media/OpenYourAppIntheBrowser.png>)


Congratulations, by creating a build definition and release definition we were able to deploy the application to Azure.
In a next lab we will enhance both the build and release definiton and configure them so that they support **Continuous Integration** and **Continuous Deployment**
The build definition will be triggered when new commits are pushed to the master branch and in turn triggers a release that automatically deploys the application to Azure
This allows you to receive feedback as to whether your changes contain syntactical errors or break existing tests, as well as saving time by automating the deployment process.

Summary
-------

In this lab, you have learned how to create a VSTS build and release definition.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).
