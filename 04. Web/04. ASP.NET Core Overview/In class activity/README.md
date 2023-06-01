# REST Controllers - Create REST Controllers in ASP.NET Core

In this activity we will get to know REST Controllers in ASP.NET Core by writing some of them.
Before we start we need to understand the ASP.NET Core Overview Demo as we are going to use it as a foundation.

## 1. Download and run the ASP.NET Core Overview Demo

Check if the requests are working as expected.

## 2. Create User class in models

User should have an **id**, a **name**, and an **email**.

These fields should be validated.

## 3. Create UserController class in controllers

Use attributes to mark the class as REST controller and specify the route.
Routing for the controller should be **/api/users**

## 4. CRUD Operations on users

Create methods and annotate them properly to handle all CRUD requests.
We should be able to:

- get all users
- get user by id
- create **valid** user
- update user (name and email)
- delete user by id

All requests must return proper HTTP status codes.
