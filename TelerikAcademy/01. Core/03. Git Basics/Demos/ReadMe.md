# Overview
---

# Getting Started with GitLab

This tutorial explains how to create a GitLab project, clone it locally, make changes and push them back to the GitLab server. 

Table of Content  
* [Step 1 - Remove previous GitLab authentications](#step-1)
* [Step 2 - Authenticating with GitLab](#step-2)
* [Step 3 - Create GitLab project](#step-3)
* [Step 4 - Clone a GitLab project locally](#step-4)
* [Step 5 - Making local changes](#step-5)
* [Step 6 - Synchronizing local changes with GitLab](#step-6)
---  

# Step 1
## Remove previous GitLab authentications

The steps below show how to remove any existing previous GitLab authentications.

> Don't worry, this will not delete your GitLab account if you have one.

Go to `Control Panel > User Accounts`

![Credentials #0](Images/user-credentials-0.png)

![Credentials #0](Images/user-credentials-1.png)

--- 

# Step 2
## Authenticating with GitLab

### Create GitLab user

Go to the [GitLab sign in page](https://gitlab.com/users/sign_in) and either create a new GitLab account or use one of the other options to log in. In this tutorial I am using a Google account to log into GitLab.

![Sign In #0](Images/sign-in-0.png)

![Sign In #1](Images/sign-in-1.png)

![Sign In #2](Images/sign-in-2.png)

### Create a GitLab password

You have to create a GitLab password which will be used for when you `push` source code from Visual Studio to GitLab.

Go to [Settings of your GitLab account](https://gitlab.com/profile)

![Sign In #3](Images/sign-in-2.5.png)

![Sign In #4](Images/sign-in-3.png)

From the menu on the left, select `Password` to create your unique GitLab password.

![Sign In #5](Images/sign-in-4.png)

![Sign In #6](Images/sign-in-5.png)

### Log into GitLab

Go to the [GitLab sign in page](https://gitlab.com/users/sign_in) and use your newly created GitLab password.

![Sign In #7](Images/sign-in-6.png)

GitLab will redirect you to the home page of your account and prompt you to create a project.

![New Project](Images/new-project-0.png)

---  

# Step 3
## Create GitLab project

Click the `Create a project` button.

![New Project](Images/new-project-1.png)

Select `Create from template` and use the .NET Core template.

![New Project](Images/new-project-2.png)

Give your application a name, set its `Visibility` to `Private` and click `Create project`.

![New Project](Images/new-project-3.png)

GitLab will generate a repository containing the files necessary for new .NET Core Console Application plus few additional ones. 

Notice that GitLab also generated `.gitignore` and `ReadMe.md` files. Take some time to familiarize yourself with the user interface of GitLab. 

![New Project](Images/new-project-4.png)

# Step 4
## Clone GitLab project locally

To start making changes to the Console Application that GitLab created, you have to download (clone) it locally on your computer.

Start by obtaining the clone address for the project.

![Clone Project](Images/clone-0.png)

In the copy/paste clipboard you should have an address similar to the one below. 

```
https://gitlab.com/f5ko.netkoff/my-console-app.git
```

**Save it somewhere because we will need later.**

Open Visual Studio 2019 and select `Clone or check out code`.

![Clone Project](Images/clone-1.png)

Paste the GitLab clone address into `Repository location` and choose a local folder where the repository will be cloned.

> The local folder **MUST** be empty!

![Clone Project](Images/clone-2.png)

Click the `Clone` button.

Visual Studio will prompt you to enter your GitLab credentials.

![Clone Project](Images/clone-3.png)

If you have authenticated correctly, Visual Studio will clone the project.

![Clone Project](Images/clone-4.png)

Right-click on the `my-console-app` folder and choose `Open Folder in File Explorer`.

![Clone Project](Images/clone-5.png)

![Clone Project](Images/clone-6.png)

Double-click the `dotnetcore.csproj` file to load it in Visual Studio.

![Clone Project](Images/clone-7.png)

> Note that cloning a GitLab repository does not automatically load it in Visual Studio.

![Clone Project](Images/clone-8.png)

You are now ready to start making changes to the project.

# Step 5
## Making local changes

To confirm that you can synchronize your local changes with the GitLab server, make a small modification in the `Main` method. For example, change `Hello World!` to `GitLab says Hi!`. Rebuild the project to make sure that it compiles successfully.

```csharp
using System;

namespace dotnetcore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GitLab says Hi!");
        }
    }
}
```

![Make Changes](Images/changes-0.png)

Do you notice the little red tick on the left side of `Program.cs`? It means that the file has been modified locally. 

![Make Changes](Images/changes-1.png)

Details about the changes you make to a project can be viewed in the `Team Explorer` panel (`View > Team Explorer`)

Click the `Changes` button.

![Make Changes](Images/changes-2.png)


![Make Changes](Images/changes-3.png)

As you can see `Program.cs` is in the list of modified files. 

Sometimes Visual Studio might add files that should not be pushed to the GitLab server. In this case, Visual Studio has created a `.vs` folder which we don't want to upload to the GitLab server.

![Make Changes](Images/changes-4.png)

To exclude the `.vs` folder from the synchronization, right click on it and choose `Ignore these local items`

![Make Changes](Images/changes-5.png)

This is update the `.gitignore` file and Visual Studio will no longer sync the `.vs` folder with GitLab.

![Make Changes](Images/changes-6.png)

> Both `Program.cs` and `.gitignore` should be synchronized with GitLab.

Before pushing the changes to GitLab, they have to be committed locally. To do that enter a meaningful, descriptive and relatively short commit message and click the `Commit All` button.

![Make Changes](Images/changes-7.png)

Visual Studio might ask you to save the parent solution file where the `dotnetcore.csproj` project has been residing.

![Make Changes](Images/changes-8.png)

Click the `Save` button and save the solution file in the folder project.

![Make Changes](Images/changes-9.png)

Upon clicking `Save` Visual Studio will commit `.gitignore` and `Program.cs` and will add `dotnetcore.sln` to the list of changed files.

![Make Changes](Images/changes-10.png)

On the image above `Commit dc3bfa83` is the commit for the `.gitignore` and `Program.cs` files. Before synchronizing with the GitLab server, you have to commit `dotnetcore.sln` as well.
As before, add a short message and click `Commit All`.

![Make Changes](Images/changes-11.png)

The solution file will be committed locally (`Commit 7ccee1f2`) and no further changes will be present.

![Make Changes](Images/changes-12.png)

# Step 6
## Synchronizing local changes with GitLab

The final step is to synchronize the 2 local commits (`Commit dc3bfa83` and `Commit 7ccee1f2`) with the GitLab server. To do that, click the little house icon ![Make Changes](Images/sync-house.png) located at the top of the `Team Explorer` panel. After that click the `Sync` button.

![Make Changes](Images/sync-0.png)

Verify that the commits you want to push are present and click the `Push` button.

![Make Changes](Images/sync-1.png)

Visual Studio should present you with the following message.

![Make Changes](Images/sync-2.png)

If you want to verify that the commits have reached the GitLab server, examine the project's GitLab page (`https://gitlab.com/f5ko.netkoff/my-console-app`)

![Make Changes](Images/sync-3.png)

Click the `Program.cs` file and check the message.

![Make Changes](Images/sync-final.png)

---
