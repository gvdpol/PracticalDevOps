# Lab - Release Pipeline QuickStart

## Description

In this lab we will setup **Continuous Integration** (**CI**) and **Continuous Deployment** (**CD**) with Visual Studio Team Services (VSTS).
Continuous Integration (CI) is the practice used by development teams to automate the merging and testing of code.
Implementing CI helps to catch bugs early in the development cycle, which makes them less expensive to fix.
Automated tests execute as part of the CI process to ensure quality.
Artifacts are produced from CI systems and fed to release pipelines to drive frequent deployments.
The Build service in VSTS (and TFS) helps you set up and manage CI for your applications.
After the CI step succeeds it will trigger a deployment.

>**Note:** For the documentation with more in-depth information on Continuous integration, please visit the following link(s):

* [Continuous Integration](https://www.visualstudio.com/en-us/docs/build/overview)

## Pre-requisites (only if you want to open the code in Visual Studio)

* Visual Studio 2017 Community edition​
  * ASP.NET and web development​
  * Azure development​
* .NET Core 2.0 SDK​
* NodeJS​
* Grunt 1.0.0 (via NPM)​

## Tasks Overview

### [1. View the Source Code of the application](./EXPLORE-SOURCE-CODE.md)

> In this task you will explore the Parts Unlimited source code, located in the Git repo of your VSTS Account. The source code is already made available in the repo of your Team Project.

### [2. Continuous Integration](./CONTINUOUS-INTEGRATION.md)

> In this task you will create a Build definition and configure it to use your code repository.

### [3. Create the Azure App Service (Web Site)](./AZURE-APPSERVICE.md)

> In this task you will create the Azure App Service to deploy our application to. 
> In a later lab we will create this automatically, using infrastructure as code, as part of the release pipeline.

### [4. Continuous Deployment with Release Management](./RELEASE-MANAGEMENT.md)

> In this task you will create a Release definition. The output of your build definition will be the source for your first release pipeline.

### [5. Verify deployment to Azure](./VERIFY-DEPLOYMENT.md)

> In this task you will confirm the status of your deployment in VSTS and Azure.

## Next steps

In this lab, you have learned to create a Continuous Integration build that runs when new commits are pushed to the master branch and create a Continuous Deployment that deploys an application to environments automatically.
This allows you to receive feedback as to whether your changes contain syntactical errors or break existing tests, as well as saving time by automating the deployment process.

[Back to Labs overview](../../Readme.md).
