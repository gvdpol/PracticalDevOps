# Lab - Release Pipeline QuickStart

## Task: Verify deployment to Azure

### Description

In this lab we will verify the deployment of our Application to Azure

## Confirming successful deployment to Azure

### Step 1

In the Azure portal, click on App Services in the left menu and select your application from the list.

![List App Service In Azure Portal](<media/ListAppServiceInAzurePortal.png>)

Make sure the overview menu is selected, next click the **Browse** button in the toolbar (see screenshot) to open your application in the browser.

![Open Your App in the Browser](<media/OpenYourAppIntheBrowser.png>)


Congratulations, by creating a Build Pipeline and Release Pipeline we were able to deploy the application to Azure.
In a next lab we will enhance both the Build and Release Pipeline and configure them so that they support **Continuous Integration** and **Continuous Deployment**
The Build Pipeline will be triggered when new commits are pushed to the master branch and in turn triggers a release that automatically deploys the application to Azure
This allows you to receive feedback as to whether your changes contain syntactical errors or break existing tests, as well as saving time by automating the deployment process.

## Summary

In this lab, you have learned how to create Azure Pipelines for Build and Deployment.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).
