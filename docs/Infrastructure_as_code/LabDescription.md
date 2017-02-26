Lab #6 - Infrastructure as Code
===============================
In previous labs, you have created a Continuous Integration build definition that builds the PartsUnlimited application, and
runs unit tests whenever code is pushed to the master branch. You have also set up a Release Pipeline using Release Management (a feature of Visual Studio Team Services)
to be able to continuously deploy the application to an Azure Web App. In a later lab the app will be deployed using deployment slots, initially to a `dev` deployment slot. 
The `staging` slot will require and approver before the app is deployed into it. 
Once an approver approves the `staging` slot, the app will be deployed to the production site.

## Pre-requisites:
**Complete the [Continuous Integration Lab](../Continuous_Integration/LabDescription.md).**
This lab will setup the Continuous Integration (CI) build.

## Task Overview:

### Task 1: Modify the CI Build to include the ARM Templates
### Task 2: Modify the ARM Templates to include the environment variables

## Tasks:

### Task 1: Modify the CI Build to include the ARM Templates

In order to deploy to Azure, you're going to specify the infrastructure that the PartsUnlimited Website requires. 
For example, the site requires an Azure SQL Database and an Azure Web App. 
Rather than create these by hand, you are going to use the Azure Resource Manager (ARM) templates that describe this infrastructure in a json file. 
This is good DevOps practice, since you're describing **infrastructure as code**.

The source code already defines the infrastructure required by the application in code (Infrastructure as Code). 
The code is a json file based on the Azure Resource Manager (ARM) template schema. 
You will use the template to deploy or update the infrastructure as part of the release.

The task that will deploy the **ARM template** will create the resource group if it does not exist. 
If the resource group does exist, then the template is used to update the existing resources.


> **Note:** 
> 
> The infrastructure described in the ARM templates for this lab will create resources that are not free. 
> It creates an Azure Web App with 3 deployment slots. 
> Deployment slots are only available with Standard or Premium App Service Plans. 
> They are **not** available on Free or Basic plans. 
> Once you've completed this lab, you probably want to delete the resource group in order to minimize charges to your Azure account.


**Step 1.** 

In your VSTS Team project click on the **Build&Release** hub, and select Explorer.

**Step 2.** 

Click the Build definition that you configured in the Continuous Integration Lab, and click "Edit".   

**Step 3.** 

Click "+ Add build step..." and add a new "Publish Build Artifacts". 
Configure it as follows:

![](media/49.png)

	* For `Path to Publish`, click the "..." button and browse to the env/Templates folder
	* For `Artifact Name`, enter "ARMTemplates"
	* For `Artifact Type`, select "Server"

**Step 4.** 

Save the updated build definition and queue a new build by clicking the "Queue new build" button. Accept the defaults and click OK.

> **Note:** The build process may take a while, but there is no need to await its completion before proceeding. Come back and do the last step after task 3.

**Step 5.** 

When the build has completed, verify that there are 2 folders: drop and ARMTemplates.

![](media/55.png)

- The drop folder should contain a single file: PartsUnlimitedWebsite.zip (click "Explore" to view the contents)
- The ARMTemplates folder should contain a number of environment template and parameters JSON files.

### Task 2: Modify the ARM Templates to include the environment variables

In this task we modify the ARM template to include the ASP.NET environment setting as an environment variable.

**Step 1**

Navigate to the code hub and open the file env\templates\fullEnvironmentSetupMerged.json

**Step 2**

Find the following string in the file: **APPINSIGHTS_INSTRUMENTATIONKEY**
Use Ctrl-F to search for the string, use F3 for Find Next.

This string is present 4 times in the file.

The first location shows the following:

            "appSettingNames": [
              "APPINSIGHTS_INSTRUMENTATIONKEY",
              "Keys:ApplicationInsights:InstrumentationKey"
            ]

Change this to:

            "appSettingNames": [
              "ASPNETCORE_ENVIRONMENT",
              "APPINSIGHTS_INSTRUMENTATIONKEY",
              "Keys:ApplicationInsights:InstrumentationKey"
            ]

Find the next location of **APPINSIGHTS_INSTRUMENTATIONKEY**

This will show the following:

              "properties": {
                "APPINSIGHTS_INSTRUMENTATIONKEY": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-DevInsights')).InstrumentationKey]",
                "Keys:ApplicationInsights:InstrumentationKey": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-DevInsights')).InstrumentationKey]"
              }

Change this to:

              "properties": {
                "ASPNETCORE_ENVIRONMENT": "Development",
                "APPINSIGHTS_INSTRUMENTATIONKEY": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-DevInsights')).InstrumentationKey]",
                "Keys:ApplicationInsights:InstrumentationKey": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-DevInsights')).InstrumentationKey]"
              }


Find the lation location of **APPINSIGHTS_INSTRUMENTATIONKEY**

This will show the following:

              "properties": {
                "APPINSIGHTS_INSTRUMENTATIONKEY": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-StagingInsights')).InstrumentationKey]",
                "Keys:ApplicationInsights:InstrumentationKey": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-StagingInsights')).InstrumentationKey]"
              }

Change this to:

              "properties": {
                "ASPNETCORE_ENVIRONMENT": "Staging",
                "APPINSIGHTS_INSTRUMENTATIONKEY": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-StagingInsights')).InstrumentationKey]",
                "Keys:ApplicationInsights:InstrumentationKey": "[reference(concat('Microsoft.Insights/components/', parameters('WebsiteName'), '-StagingInsights')).InstrumentationKey]"
              }


Now run the build and release pipeline again and open the various environments of the application from the Azure Portal.





## Congratulations!

You've completed this lab!

[Back to Labs overview](../../Readme.md).
