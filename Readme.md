# Practical DevOps Workshop

[![Build status](https://dev.azure.com/delta-n/Delta-N%20Team%20DevOps/_apis/build/status/PracticalDevOps/PracticalDevOps.CI)](https://dev.azure.com/delta-n/Delta-N%20Team%20DevOps/_build/latest?definitionId=-1)

## Welcome to the Practical DevOps workshop

Software engineering practices have changed drastically in the last few years. Agile practices, DevOps, Cloud Computing, Open Source and similar developments have proven their effectiveness. Microsoft’s platforms for software development and cloud computing have also embraced these concepts and are at the leading edge in their domain.

In this two-day workshop you will learn how software development works with Microsoft’s tools and languages. Based on a consistent sample, you will learn how to

* setup a team development environment with Azure DevOps
* use the cross-platform build- and test-automation tools to automate your build- and quality assurance processes
* setup a multi-stage (dev/test/prod) environment in Azure
* create highly available and secure environments for your web APIs and web applications in Microsoft Azure with Azure Resource Manager (ARM)
* automate deployment to Microsoft Azure with Visual Studio Release Management
* use Application Telemetry with Application Insights
* manage your Technical Debt
* discuss the advantages of the upcoming container technology Docker
* highlight and learn to benefit from the latest developments in the Visual Studio IDE

## Workshop structure

The workshop consists of a series of DevOps hands-on labs. Attendees should have basic knowledge about Visual Studio, .NET, C#, HTML and JavaScript. Detailed knowledge about the latest versions of these tools, frameworks and languages is not required.
During the workshop we will use the [Parts Unlimited sample application](docs/PartsUnlimited/LabDescription.md)

## Tips

* Ensure you start by reading how to prepare Visual Studio [here](docs/VisualStudioPreps.md)
* Read carefully, missing a step can be the difference between success and failure
* The GUI of Azure DevOps changes constantly, some screenshots may be outdated, think logically and you will find a solution
* Keep this lab open in a separate browser window
* Navigate only using the links in these documents, don't use the file list at the left-hand side of this screen

## Overview of the DevOps Workshop Labs

1. Getting Azure Credits
	1. [Activation of Azure Pass - (Optional)](docs/Setup/AzurePass.md)
	2. [Activation of Azure for Students - (Optional)](docs/Setup/AzureForStudents.md)
	3. If the above fails: ask your mentor
2. Introduction
    1. [DevOps introduction](docs/DevOps/LabDescription.md)
    2. [Parts Unlimited - The sample Application](docs/PartsUnlimited/LabDescription.md)
    3. [Azure DevOps](docs/VSTS/LabDescription.md)
3. [Backlog Management and Agile Planning](docs/BacklogManagement/LabDescription.md)
4. [Release Pipeline Quickstart](docs/Intro_Release_Pipeline/LabDescription.md)
	1. [View the Source Code of the application](docs/Intro_Release_Pipeline/EXPLORE-SOURCE-CODE.md)
	2. [Continuous Integration](docs/Intro_Release_Pipeline/CONTINUOUS-INTEGRATION.md)
	3. [Create the Azure App Service (Web Site)](docs/Intro_Release_Pipeline/AZURE-APPSERVICE.md)
	4. [Continuous Deployment with Release Management](docs/Intro_Release_Pipeline/RELEASE-MANAGEMENT.md)
	5. [Verify deployment to Azure](docs/Intro_Release_Pipeline/VERIFY-DEPLOYMENT.md)
5. [Continuous Integration](docs/Continuous_Integration/LabDescription.md)
6. [Infrastructure As Code](docs/Infrastructure_as_code/LabDescription.md)
7. [Continuous Deployment with Release Management](docs/Continuous_Deployment/LabDescription.md)
8. [Telemetry and Application Insights](docs/User_Telemetry_APM_With_App_Insights/LabDescription.md)