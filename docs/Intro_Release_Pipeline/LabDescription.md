Lab #3 - Release Pipeline QuickStart
====================================================================================

## Description
In this lab we will set Continuous Integration (CI) and Continuous Deployment (CD) with Visual Studio Team Services (VSTS). 
Continuous Integration builds the app and runs unit tests whenever code is pushed to the master branch. 
After CI step succeeds it will trigger a deployment. 


>**Note:** For the documentation with more in-depth information on Continuous integration, please visit the following link(s):
* [Continuous Integration](https://www.visualstudio.com/en-us/docs/build/overview)

## Pre-requisites:
- Finished Lab #1 to #2

## Tasks Overview:
* [1. View the Source Code of the application](./EXPLORE-SOURCE-CODE.md).

> In this task you will explore the Parts Unlimited source code, located in the Git repo of your VSTS Account. The source code is already made available in the repo of your Team Project.

* [2. Continuous Integration](./CONTINUOUS-INTEGRATION.md).

> In this task you will create a Build definition and configure it for your repository.

* [3. Create the Azure App Service (Web Site)](./AZURE-APPSERVICE.md).

> In this task you will create the Azure App Service to deploy our application to. 
> In a later lab we will create this automatically (using configuration as code) as part of the release pipeline.

* [4. Continuous Deployment with Release Management](./RELEASE-MANAGEMENT.md).

> In this task you will create a Release definition. The output of your build definition will be the source for your first release pipeline.

* [5. Verify deployment to Azure](./VERIFY-DEPLOYMENT.md).

> In this task you will confirm the status of your deployment in VSTS and Azure.


Next steps
----------
In this lab, you have learned to create a Continuous Integration build that runs when new commits are pushed to the master branch and create a Continuous Deployment that deploys an application to environments automatically.
This allows you to receive feedback as to whether your changes contain syntactical errors or break existing tests, as well as saving time by automating the deployment process.



[Back to Labs overview](../../Readme.md).