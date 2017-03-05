# Excella Code Challege 2017 -- .NET Starter Kit
A starter kit by Sean Killeen for submitting answers to the Excella coding challenge 2017

## What Does This Project Contain?
* The default Home Page at `/Home` or the default URL. I haven't modified this from the out of the box demo page.
* A working .NET WebAPI 2 Endpoint that solves the `HelloWorld` (round 0) question
 * This can be found at `/api/HelloWorld`
* Unit tests for the HelloWorld controller in a separate project to get you started.
 * These tests are written using [xUnit](https://xunit.github.io/) and [FluentAssertions](http://www.fluentassertions.com/).
* A Swagger API Documentation Controller at `/swagger`. This will show all of the controllers and their options, and will enable a live "playground" where you can test the results.

## Cloning This Repository
If you'd like to use this as a starting point, you'll need to clone the repository.

* Open the repository on the Github Web site
* Click the `Clone or Download` button and choose the option you prefer.

Optionally, follow the steps to clone the git repository in your client of choice.

## Building the application locally
This should be pretty straightforward. The apps should build using the standard `CTRL + SHIFT + B` or `F5` that you're used to.

The tests should run in any standard test runner. My preferred runner is [NCrunch](http://ncrunch.com).

## Deploying the app to Microsoft Azure -- The Easy Way
For the purposes of the challenge, you may want to deploy the app to a public web site. Luckily, with Microoft Azure, you can host this web app completely for free!

### Step 1: Sign up for Microsoft Azure (or log in)
If you haven't already, head to <http://portal.azure.com> and create an account.

### Step 2: Clone the Repository if you haven't already
Directions are above.

### Step 3: Use the "Deploy to Azure" button
Make sure you're on your own repo's site on Github, and then click this button:

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

It will ask you to sign into Azure, and then will let you select the options to deploy this site. Make sure you use the `Free` SKU.

After that, this site will be up and running, and should deploy whenever you make changes to the `master` branch!

## Deploy the app to Azure -- the Manual Way

### Sign up & Clone
Just as in "the easy way", sign up for an Azure account and clone this repository.

### Create a Free Web Site to Hold the App
In the Azure portal:

* Click "+" to add a new resource
* Select Web Site as the resource
* Create a new resource group for the web site
* Make sure that Free pricing is selected for the web site.

If you need help on the specifics, [get in touch](http://twitter.com/sjkilleen).

### Set Up Deployment Pipeline From Github to the App
Once the web site has been created:

* Go to the web site within the [azure portal](http://portal.azure.com)
* Click "Deployments"
* Click "Configure Deployments"
* Follow the wizard steps, which will connect to your github account and configure deployment.

### Visit your new app!
Once you've set up deployment and seen that it's successful, your new web site should be available at `http://WebSiteNameYouPicked.azurewebsites.net`. Nice!
