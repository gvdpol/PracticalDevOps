# Lab - Continuous Deployment with Release Management in Visual Studio Team Services

## Description

In previous labs, the application called PartsUnlimited, was committed to a Git repo in Visual Studio Team Services (VSTS), you have adopted the **Continuous Integration** practice and have created a build definition that builds the app and
runs unit tests whenever code is pushed to the master branch. Now we are going to modify your existing release pipeline to enable continuous deployment of the application to an Azure Web App.

## Pre-requisites

## Task 1. Modify the Release Pipeline for the Parts Unlimited Website

Initially the app will be deployed to a `dev` deployment slot.
The `staging` slot will require an approver before the app is deployed into it.
Once an approver approves the `staging` slot, the app will be deployed to the `production` site.

In this step, you will modify the Release Definition for the PartsUnlimited Website.
You'll use the CI build output as the input artifact for the Release and then define how the release moves through `environments` with approvals
in between.

### Step 1

In VSTS, edit the release definition created in a previous lab. The template has a single Environment.

> An **Environment** is simply a logical grouping of tasks - it may or may not correspond to a set of machines.
For this Release Definition, you will create 3 Environments: **dev**, **dtaging** and **production**.

The infrastructure required for all 3 environments is described in the ARM Template.
The ARM Template will be applied during deployment in the Dev Environment before deploying the website to Dev.

### Step 2

Click the name label "Environment 1" and change the name to "Dev".

> This screenshot shows the old release definition editor.
> The next steps will be based on the old editor, during the workshop we will explore using the new Editor for Release Definitions.

![Rename Environment 1](media/12.png)

> You can also use a separate environment, for example called **setup infrastructure**, to execute the ARM deployment task.
> If you setup your Release Definition in this way, you can next create dev environment and clone this environment to staging and production
It will not be necessary to run any infrastructure tasks during Staging or Production deployments in this case.

### Step 3

Click on the "+ Add tasks" button to add a task for this environment.
In the "Deploy" group, click the **Add** button next to "Azure Resource Group Deployment" to add the task.
Close the "Task catalogue" dialog.

**Ensure that the Azure Resource Group Deployment task happens before the Deploy Azure App Service task. Otherwise there is no infrastructure to deploy the App Service to!**

![](media/42.png)

### Step #4

Click on the "Azure Resource Group Deployment" task. Configure it as follows:

**First ensure that Version 1.* is selected for that task (pulldown menu at the right-hand top)**

> `Azure Subscription`: select the Azure subscription endpoint that you created earlier

> `Action`: select "Create or Update Resource Group"

> `Resource Group`: enter `$(ResourceGroupName)` into the box, you will create a variable named this shortly.

> `Location`: select an Azure location

> `Template location`: Linked artifact

> `Template`: click the "..." button and browse to the FullEnvironmentSetupMerged.json file in the ARMTemplates folder.

![](media/43.png)

> `Template Parameters`: click the "..." button and browse to the FullEnvironmentSetupMerged.param.json file in the ARMTemplates folder.

![](media/56.png)

> `Override Template Parameters`: Enter the following in a single line (shown split here for convenience):

		-WebsiteName $(WebsiteName)
		-PartsUnlimitedServerName $(ServerName)
		-PartsUnlimitedHostingPlanName $(HostingPlan)
		-CdnStorageAccountName $(StorageAccountName)
		-CdnStorageContainerName $(ContainerName)
		-CdnStorageAccountNameForDev $(StorageAccountName)-dev
		-CdnStorageContainerNameForDev $(ContainerName)-dev
		-CdnStorageAccountNameForStaging $(StorageAccountName)-stage
		-CdnStorageContainerNameForStaging $(ContainerName)-stage
		-PartsUnlimitedServerAdminLoginPassword (ConvertTo-SecureString -String '$(AdminPassword)' -AsPlainText -Force)
		-PartsUnlimitedServerAdminLoginPasswordForTest (ConvertTo-SecureString -String '$(AdminTestPassword)' -AsPlainText -Force)
		
You will shortly define the values for each parameter, like `$(ServerName)`, in the Environment variables.

> **Note**: If you open the FullEnvironmentSetupMerged.param.json file, you will see empty placeholders for these parameters. You could hard code values in the file instead of specifying them as "overrides". Either way is valid. If you do specify  values in the params file, remember that in order to change values, you would have to edit the file, commit and create a new build in order for the Release to have access the new values.

### Step #5

Click on the ellipsis (...) button next to the Environment and select "Configure variables..."

![](media/44.png)

### Step #6

Create the following variables, adding values too.

- **WebsiteName** - Name of the website in Azure
- **ServerName** - Prefix for the name of the database servers. Will have `-dev` or `-stage` added for dev/staging
- **HostingPlan** - Name of the hosting plan for the website
- **StorageAccountName** - Storage account name prefix. Will have `-dev` or `-stage` added for dev/staging
- **ContainerName** - Container name prefix. Will have `-dev` or `-stage` added for dev/staging
- **AdminPassword** - Admin password for production database server
- **AdminTestPassword** - Admin password for dev and staging database servers
- **ResourceGroupName** - Name of the Resource Group.

![](media/50.png)

> **Note**: Use unique values for your variables by adding something custom at the end like your initials. Example for WebsiteName : pudncorejstr 

> **Note**: You can hide passwords and other sensitive fields by clicking the padlock icon to the right of the value text box.

### Step #7

Save the definition.
Now that the infrastructure deployment is configured, we can modify the initial task.

### Step #8

Click on the Dev environment in the Release Definition and select the "AzureRM Web App Deployment" Task. Ensure that Version 1.* is selected at the right-hand top

### Step #9

For App Service Name, enter the `$(WebsiteName)` to use a variable. You defined this variable earlier when deploying
the ARM Template. You will shortly "promote" it to a Release variable so that it can be used in all Environments in the Release. Check the Deploy to Slot check box

### Step #10

Enter `$(ResourceGroupName)` into the Resource Group Box. Enter "dev" for the Slot. This will deploy the site to the "dev" deployment slot. This allows you to deploy the site to an Azure deployment slot without affecting the Production site.

### Step #11

Tick "Take App Offline" (in the "Additional Deployment Options" section). This stops the website for deployment period and takes it back online afterwards. 
This is required because sites receive requests all the time causing files to lock down (i.e. making them unmodifiable).

### Step #12

Click the ellipsis (...) button, next to the "Package" box, to set the Web Deploy Package location. 
Browse to the PartsUnlimitedWebsite.zip file and click OK.

![](media/10.png)

### Step #13

Clear the "Additional Arguments" parameter. 
The ARM template you deployed has already configured all the slot-specific app settings and connection strings. 
The Task should look like this:

![](media/11.png)

> **Note**: It is a good practice to run smoke tests to validate the website after deployment, or to run load tests. The code-base you are using
	does not have any such tests defined. You can also run quick cloud-performance tests to validate that the site is up and running. For more
	information on quick load tests, see [this video](https://channel9.msdn.com/Events/Visual-Studio/Connect-event-2015/Cloud-Loading-Testing-in-Visual-Studio-Team-Service)
	from around the 6 minute mark.

### Step #14

Promote the WebSite Environment variables to a Release Variables

Click on the "Dev" environment, click the ellipsis (...) button select "Configure Variables". 
Make a note of the `WebsiteName` and `ResourceGroupName` variables' values and delete them from this list. Click OK.
Click on "Variables" to open the Release variables. These are "global" variables that any Environment can use.
Enter "WebsiteName" for the name and enter the value for the Website in Azure.
Enter "ResourceGroupName" for the name and enter the value for the Resource group in Azure.

![](media/53.png)

Click Save to save the Release Definition.

### Step #15

**Test the Dev environment with ARM Template Deployment**
You will shortly clone the Dev Environment into both Staging and Prod environments. 
However, before you do that it's a good idea to test that the Dev Environment is correctly configured by creating a new Release.

Before moving on, it is a good idea to test the template so far.

### Step #16

Click on "+ Release" in the toolbar and select "Create Release" to start a new release.

![](media/45.png)

### Step #17

Select the latest build from the drop-down, and then select "Dev" as the target environment. Click "Create" to start the release.

![](media/46.png)

### Step #18

Click the "Release-x" link to open the release.

![](media/21.png)

### Step #19

Click on the Logs link to open and monitor the deployment logs.
You should see a successful release after a few minutes.

![](media/51.png)

#### Step #20

Click on the Logs link to open the deployment logs.

### Step #21

If you log into the Azure Portal, you will see the Resource Group has been created.
You can check that the site was in fact deployed successfully by navigating to the site url.

> Since you deployed to the dev slot, you will need to navigate to `http://{siteName}-dev.azurewebsites.net` where siteName is the name of your Web App in Azure.

![](media/52.png)

![](media/27.png)

> By default you will only receive email notifications on failed release. This can be changed in settings for each environment. Click the ellipsis (...) on the Dev Environment card and select "Assign approvers..". Navigate to "General tab" and set the desired behavior.


**Clone the Dev environment to Staging and Production**

Now that you have verified that the Dev Environment is configured correctly, you can clone it to Staging and Production.

### Step #22

Click on the PartsUnlimited link and then the Edit link to open the Release Definition.

> **Note:** It is possible to change the definition for a Release without changing the Release Definition (i.e. the Release is an instance of the Release Definition that you can edit). You want to make sure that you are editing the Release Definition, not a Release.

### Step #23

Click the ellipsis (...) on the Dev Environment card and select "Clone environment".

![](media/28.png)

### Step #24

In the Dev Environment, you did not define any approvers. For Staging, however, you should configure approvers. In "Pre-deployment approval" section choose people who will approve deployments to staging environment and click "Create".

![](media/13.png)

### Step #25

A new Environment is created. Enter "Staging" for the name.

### Step #26

Delete the "Azure Resource Group Deployment" task. This is not required in this Environment since the ARM template deployed the infrastructure for all 3 environments.

### Step #27

Click the ellipsis (...) on the Staging Environment card and select "Configure variables".

### Step #28

Delete all the variables. These are used by the "Azure Resource Group Deployment" task which you just deleted, so they are not necessary in this Environment.

### Step #29

On the Azure Web App Deployment task, set the Slot to `staging`.

![](media/29.png)

> **Note**: If you had environment-specific variables, you would be able to set Staging-specific values. It is not necessary in this case.

### Step #30

When we cloned dev to staging we set one person for staging's pre-approvals. We can adjust it even further by clicking ellipsis (...) on the Staging Environment card and select "Assign approvers...". For this HOL, you can be both incoming and the outgoing approver.

![](media/14.png)

### Step #31

In this case, you want to pause the deployment coming in. This ensures that if someone is testing in the Staging environment,
they don't suddenly get a new build unexpectedly.

### Step #32

Configure approvers for the Staging environment

![](media/33.png)

> **Pre-deployment approvers** must approve a deployment coming _into_ the environment. The deployment will stop and wait before executing any tasks in the environment until approval is granted.<br/> **Post-deployment approvers** approve deployments so that the _next_ Environment can begin. They act as sign-off for the current environment.<br/> **Approvers** can be individuals or groups.

### Step #33

Clone the Staging environment to Production.
- Untick "Deploy to Slot" (i.e. the site will be deployed to the production slot).
- Update the approvers - again, you can be both approvers.

### Step #34

Save the Release Definition.

**Configure Continuous Deployment for this Release Definition**

### Step #35

Click on the Triggers link of the Release Definition.

### Step #36

For "Release trigger" pick "Continuous Deployment" and set trigger to the build definition created before.
> Selecting the build as the trigger means that any time the artifact build
completes, a new release will automatically start using the latest build.

### Step #37

Set "Environment triggers" to the following settings:
- Deployment to "Dev" environment should be triggered after release is created.
- Deployment to "Staging" can be triggered on successful deployment to "Dev".
- Deployment to "Production" can be triggered on successful deployment to "Staging".

![](media/35.png)

> **Note:** Since the incoming build for this release is a CI build, you probably don't want to deploy the build all the way to Production. Setting the Release to stop at Dev means that you will need to create a new Release with Production as the target environment if you want to deploy to Production. This is of course configurable according to your own preference.

## Task 2. Trigger a Release.

Now that you have configured the Release Pipeline, you are ready to trigger a complete release.

With an Azure Service Endpoint to deploy to, and a package to deploy (from your CI build), we need to modify the Release Definition. 
The Release Definition defines how your application moves through the various Environments, including Tasks to update infrastructure, deploy your application, run scripts and run tests. 
You can also configure incoming or outgoing approvals for each Environment.

### Step #1

Click on "+ Release" to create a new Release.

### Step #2

Select the latest build, click Create.

![](media/36.png)
> **Note**: You can adjust whether to deploy this release to a particular environment.

### Step #3

Once the Dev stage has completed deployment, you will see a notification that
an approval is pending (you will also have received an email notification if you ticked "Send an email notification to the approver whom the approval is pending on" option in settings for this environment).
Check the dev slot of the PartsUnlimited site in Azure to ensure that the Dev
environment is good, and then click Approve.

![](media/37.png)

### Step #4

You can also see pending approvals in the overview pane:

![](media/32.png)

### Step #5

Optionally enter a comment and click the Approve button.

### Step #6

This will trigger the release into the Staging environment.
> **Note**: You can reassign the approval if required.

### Step #7

Once the Staging deployment has completed, you will need to approve that staging is OK.

### Step #8

This will then trigger the pre-approval for Production. 
Once you've approved that, deployment into the Production environment will begin.

### Step #9

To see all your releases and where they are in their respective pipelines, click on All Releases and then click the Overview link.

![](media/39.png)

## Congratulations!

You've completed this lab!

>**Note:** Deployment of schemas and data is beyond the scope of this lab. 
>It is recommended that you investigate <a href="https://msdn.microsoft.com/en-us/library/hh272686(v=vs.103).aspx"> SQL Server Data Tools (SSDT)</a> for managing database schema deployments.

## Further Reading

1. [Release Management for Visual Studio Team Services](https://msdn.microsoft.com/Library/vs/alm/release/overview-rmpreview)
2. [Cloud Load Testing in Visual Studio Team Services](https://channel9.msdn.com/Events/Visual-Studio/Connect-event-2015/Cloud-Loading-Testing-in-Visual-Studio-Team-Service)

## Next Step
[Back to Labs overview](../../Readme.md).
