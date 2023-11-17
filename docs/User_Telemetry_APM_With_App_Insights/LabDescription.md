Lab - User Telemetry and Performance Monitoring with Application Insights
==================================================================================

The marketing team has expressed interest in the **behavior of users** across the PartsUnlimited website for how to 
best market the products, especially how popular the web application is and **where the users live**. 
The development team would like to know **which browsers and operating systems** that most users browse to the site 
from to target better user experiences. The development team has also noticed that the **recommendations page is 
slow to load** and shows performance spikes in Application Insights telemetry. 

By viewing the details of performance monitoring through Application Insights, we will be able to drill down to the 
code that has affected the slow performance of the web application and fix the code.
Using the out-of-box telemetry for Application Insights, the teams will be able to find out how people use the 
application and gain insights into the goals that they will need to achieve.

In this lab, you will learn about setting up Application Insights to gain further insight into how users 
are behaving towards your web application, and drill down into performance monitoring data through Application 
Insights in the new Azure Portal.

# Task 1: View real-time results for user telemetry in the Azure portal

In this task you will be shown where to find all of the information collected by Application Insights.
Now that we've given Application Insights time to refresh, we can take a look at the usage data in the new Azure Portal. 
The Portal will show a variety of metrics out of the box, including number of sessions, users, and browser sessions.

> **Note:** Before you proceed, you need to generate data for the Application Insights instance by browsing the website for a few minutes.

**Step 1.** 

In an Internet browser, navigate to <http://portal.azure.com> and sign in with your credentials.

**Step 2.** 

Click on the “All services” tile on the left column, and search/select “Application Insights”.

 ![](<media/prereq-step1.1.png>)

**Step 3.** 

Click on the name of the telemetry that was created when you deployed the resource group using the Deployment template in the PartsUnlimited solution.

![](<media/prereq-step2.png>)

**Step 4.** 

In the overview panel of the Application Insights instance, overall application health will be shown in Failed requests, Server response time, Server requests and Availability. (Actual times may vary)

![](<media/task2step3.png>)

**Step 5.** 

In the Application Insights instance blade, scroll down to the "Usage" section. By clicking on one of the subjects, we can gauge how popular our web application is based on the number of distinct users, active sessions, and number of calls to trackPageView() (usually called once). Click on "Users" to view more information about the users.

> Note: if you want more traffic, ask one or more of your fellow workshop members to browse your website as well for a few minutes.

![](<media/task2step4.png>)

**Step 6.** 

In the Users timeline (click **View more insights**), note the number of users, new users, and page views. Additionally, the unique count of users by country is recorded.  

**Step 7.** 

Click on the **Performance** page under the **Investigate** section. It will show how your application performs, how long it takes for the client to retrieve and display the page requested by the user.

![](<media/task2step7.png>)

**Step 8.** 

Note the toggle at the right-hand top side, where you can switch between Server and Browser (client) metrics. If you scroll down, you can see the actual duration it took from request until page load completed at the client-side.

![](<media/task2step8.png>)

**Step 10.** 

Go to the **Usage** section and click **... More**. This will take you to a gallery of reports that are ready for use. Click the **Analysis of Page Views** report to open it.

![](<media/task2step10.png>)

**Step 11.** 

The Page Views report will break down the Usage, Time spent on page, Time to first interaction and Page exit rates. Also take a look at the other reports, they contain valuable information. It is possible to create one or more custom reports using the quick start templates.

![](<media/task2step11.png>)


# Task 2: Using Application Performance Monitoring to resolve performance issues

In this step you will investigate and resolve a performance issue with the help of Application Insights.

**Step 1.** 

In an Internet browser, navigate to the PartsUnlimited website that you previously deployed and go to the Recommendations page. If you can't find a link to the page, go to (your base url)/home/recommendations. It will take a little while to load. Load it multiple times.

![](<media/task3-step6.png>) 

**Step 2.** 

In the Application Insights instance blade, scroll down and select the “Performance” tile to view performance monitoring information.

![](<media/task3-step1.png>)

**Step 3.** 

In the Performance panel, note the timeline. The timeline data may not show up immediately, so you will want to wait for a few minutes for the telemetry to collect performance data.

**Step 4.** 

Once data shows in the timeline, view the operations section under the timeline. 
Click on the top operation in the list referring to the recommendations page to view details of that operation.

![Page load issue](<media/RecommendationsIssue.png>)

**Step 5.** 
Drill down into the method that is affecting the slow performance. We now know where the slow performance is being caused in our code.

**Step 6.** 

Navigate to Repos hub in Azure DevOps and open `HomeController.cs` and find the Recommendations method that is causing slow performance. 
At the top of the HomeController class, notice that the public int roco_count is set to 1000. 
Change that value to be 1.

![](<media/task3-step3.png>)

**Step 7.**  

Save your changes.

>**Note** This will kick off a build automatically since we have enable CI in a previous lab.

**Step 8.** 

Now that our changes have deployed to the website, open up a new incognito browser window (to prevent caching) and return to the recommendations page (http://partsunlimited.azurewebsites.net/home/recommendations).

![](<media/task3-step6.png>) 

**Step 9.** 

Return to the Application Insights performance monitoring view in the Azure Preview Portal and refresh the page. Note that after some time, you see better performance of the page.

In this lab, you learned how to set up Application Insights telemetry to gain further insight into how users are behaving towards your web application, and drill down into performance monitoring data through Application Insights in the new Azure Portal.

## Further Reading

[Usage analysis for web applications with Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/usage-overview)

## Next 

[Back to Labs overview](../../Readme.md).
