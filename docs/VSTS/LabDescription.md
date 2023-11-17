# Lab - Create VSTS account

In this lab we will create a Visual Studio Team Services (VSTS) account.
If you already have an hosted VSTS account for your Microsoft account, create a new project and continue with Import Git repository on this page.

## Go to VSTS

Open a browser (it is strongly recommended to use **InPrivate, InCognito, Private** or similar mode to prevent automatic login) and navigate to [https://azure.microsoft.com/en-us/services/devops/](https://azure.microsoft.com/en-us/services/devops/)

![Get started for free](<media/VSTS-getstartedforfree.png>)

- Click on **Start free**

## Sign in with your account

If you don't have a Microsoft account, you can create one by clicking the **Create one!** link.

![Login](<media/VSTS-login.png>)

## Select your account

If your account is both a Personal Account and Work or School Account, use the Personal Account, otherwise the Azure DevOps Organization is created in the Azure Active Directory of your company or school and you'll not have enough permissions to create EndPoints to Azure.

![Select account](<media/VSTS-selectaccount.png>)

## Enter your account details

![Enter account login info](<media/VSTS-signindialog.png>)

- Enter your account login information and select Sign In.

## Choose a name for your Azure DevOps Organization

- Enter a name for the Azure DevOps Organization
- Leave the hosting location as it is (West Europe)
- Click **Continue**

![Enter VSTS name](<media/VSTS-createinstance.png>)

Create a demo project, we will not use this project as it is created with the "Basic" template.

![Enter project info](<media/VSTS-changedetails.png>)

## Create project for PracticalDevOps Lab

- Click on the "Azure DevOps" logo to go to the welcome page

![Navigate to welcome page](<media/VSTS-home.png>)

- Click **New project** in the right-hand top corner

![New project](<media/VSTS-newproject.png>)

- Fill in the name, click **Advanced** and select **Scrum** as process and click **Create**

![New project properties](<media/VSTS-newprojectproperties.png>)

## New project overview

When the Team Project is created, you will be redirected to the New Project overview.

![PracticalDevOps project](<media/VSTS-teamproject.png>)

- Navigate to **Repos**
- Click on **Import** under **Import a repository**
- Fill in the repository URL: https://github.com/delta-n/PracticalDevOps.git 

## Import Git repository

![Import git repository](<media/VSTS-importgithub.png>)

Congratulations! You can now start with the next lab.

![Import done](<media/VSTS-done.png>)

[Back to Labs overview](../../Readme.md).
