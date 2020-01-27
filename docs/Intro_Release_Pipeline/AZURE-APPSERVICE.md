# Lab - Release Pipeline QuickStart

## Task: Create an Azure App Service with site

## Description

In this lab we will create an Azure App Service website, our first release pipeline will deploy to this website.

## Create an Azure App Service web site

Navigate to the [Azure Portal](http://portal.azure.com) (if you are not logged in yet, log in to the portal). Located at the left of the screen you see the menu button, click it. Note, your menu may show a different list of menu items, we will show how to customize the menu later on.

![Azure Portal Menu](<media/AzurePortalMenu.png>)

Click on **All services**, choose the category **Web** and enter App Services in the search field to filter the items in the list.

![Find App Services](<media/FindAppServices.png>)

Select App Services, the App Services overview opens.

![New App Service](<media/AppServicesNew.png>)

Click on **+ Add** to create a new App Service; a new blade opens with more information on Web Apps.

![New App Service form](<media/NewWebAppForm.png>)

You need to provide a few details to create the App.

**Subscription**: Keep the default value.

**Resource Group**: Select **Create new** and enter the name of the Resource Group.

**Name**: Enter the name of the application.
Since this needs to be a globally unique name, an option is to include the name of the team or your initials as part of the name.

**Publish**: Choose **Code**. The application is not provisioned for Docker deployments.

**Runtime stack**: .NET Core 2.0 (the app is built for .NET Core 2.0)

**Operating System**: Currently for .NET Core 2.0 only Linux can be chosen. Later .NET Core Frameworks can also be run on Windows Instances.

**Region**: West Europe delivers lowest network latency (as the datacenter is located in Amsterdam)

**Linux Plan (West Europe)**: Leave the name of the plan like it is.

**Sku and size**: This is where you choose the size of the VM that runs your application. The default is good enough for this lab (Premium V2 P1v2). We need a production-type VM because later, we are going to stage the application using deployment slots, which are not available in cheaper pricing tiers.

Click **Review + create** and then **Create** to create the Web App Service. In a few minutes, you'll get notified that the deployment is complete.

Go back to the **Release Pipeline QuickStart** lab overview and select the next task.

[Back to Release Pipeline QuickStart](./LabDescription.md)

[Back to Labs overview](../../Readme.md)