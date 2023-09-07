# Layers & IoC - Add layers for User

In this activity we will get to apply the layers architecture in ASP.NET Core by separating our application into the appropriate layers.
Before we start we need to understand the ASP.NET Core Overview In-Class Activity as this activity builds upon it.

## 1. Open the provided template

The solution for ASP.NET Core Overview in-class activity is the template for this activity.

## 2. Create a Data Access Logic layer.

Right now, all of our data, regarding the users of the application is stored and managed in the `UsersController` class. Move data access and management to its own layer.

Apply Dependency Inversion where needed.

## 3. Create a Business /Application layer.

Isolate the business logic of the application in its own layer.

Apply Dependency Inversion where needed.
