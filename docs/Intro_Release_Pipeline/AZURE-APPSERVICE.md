Lab #3 - DevOps Introduction - Set up a Service Endpoint
====================================================================================

## Description
In this lab we will create an Azure App Service website, our first release pipeline will deploy to this website.

## Create an Azure App Service web site
Navigate to the [Azure Portal](http://portal.azure.com) (if you are not logged in yet, log in to the portal). 
Located at the left of the screen you see the menu. Note, your menu may show a different list of menu items, we will later show how to customize the menu.


![](<media/AzurePortalMenu.png>)


Click on **more services** and enter App Services to filter the items in the list. 

![](<media/FindAppServices.png>)


Select App Services, the App Servives overview opens. 

![](<media/AppServicesNew.png>)

Click on **+** to create a new App Service.

![](<media/AppServiceNewWebApp.png>)

Select Web App from the available options, a new blade opens with more information on Web Apps.
Click **Create**.

![](<media/NewWebAppForm.png>)

You need to provide a few details to create the App.

**App Name** - Enter the name of the application. 
Since this needs to be an unique name, an option is to include the name of the team or your initials as part of the name. 

**Subscription**
Keep the default value. 

**Resource Group**

Select **Create new** for the Resource Group and enter the name of the Resource Group. 

**AppService Plan / Location**
Also create a new App Service plan, enter the name of the plan, the location (select West Europe) and select Standard Pricing Tier. 
The standard pricing tier is required later, when we are going to stage the application using deployment slots.
Go back to the **Release Pipeline QuickStart** lab overview and select the next task.

[Back to Release Pipeline QuickStart](./LabDescription.md).

[Back to Labs overview](../../Readme.md).