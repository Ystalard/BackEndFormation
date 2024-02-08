# BackEndFormation

This project will follow the udemy formation [maîtriser les web api rest avec aspnet core dotnet](https://www.udemy.com/course/maitriser-web-api-rest-avec-aspnet-core-dotnet-50-full)

This is a wep api rest project in asp.net.
## Introduction
### REST uses http
![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/ef40d4da-0587-43d7-9b30-74c713fadd68)


### the TDD principle
![TDD_Global_Lifecycle](https://github.com/Ystalard/BackEndFormation/assets/58308727/249da9ef-ab6d-44e2-b893-aa5ffd55bab9)
It consists in generating the unitary test to validate the implementation (the unitary tests behaves like running the project in debug mode on a particular feature)

### ORM for Object Relational Mapping
![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/45380884-de47-4a16-a8a3-4de46e7aadc1)
The ORM is like a translator between object of the application (in C#) to the database (DB).
The ORM is like a cache, if nothing is saved on the database before stopping the application then any cached modification would be lost 
The ORM needs a provider in order to understand the language used by the DB.
![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/6c43f5d9-6826-41d8-a730-1104dcffd44c)

## Creation of the Database

1. Install [SQl Server Developer](https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads)
2. Install SQL Server Management Studio (SSMS)
3. Open SSMS (it must propose to connect to your sql server express which must be running, otherwise open SQL Server and configure it)
4. Create a new DB:<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/6cf6c604-f9f7-4dee-8151-a133601b537d)
5. Insert the DB name and press Ok<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/e1580e9a-3ead-415d-94ca-a305bf8065af)

### Create a new table
1. Create the table<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/22b6a39e-bee7-4d3c-93c3-5c49842cce49)
2. Add the Id row and set it as primary key<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/4753723a-cb8d-4bed-9cfe-393232fa2980)
3. Change Identity Specification property of Id so that it is Identity<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/1af52533-9ad3-49bf-b5c8-3295e52a4695)
4. Name and save the table<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/d70d92d4-71ff-4a58-8e3a-02716d6fe74e)
5. Repeat the step until you created both Selfie and Wookie table and inserted some rows
   - The Selfie table:<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/834a2f83-82dc-46f6-852d-10c56e032cb9)
   - The Wookie table:<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/e21d8147-9717-42fd-8e3b-01e94d513243)

## Migration

Instead of creating the DB in order to fit the context of our code, we can consider the context to be the reference and migrate it to the DB. This avoid to be dependent of the type of DB(MongoDB, Microsoft SQL server, Oracle, etc...)
For this, we can use the dotnet tool cli (command line interface). All the packages are referenced [here](https://www.nuget.org/packages?packagetype=dotnettool).<br/>
When it comes to migration we shall think of [dotnet ef](https://www.nuget.org/packages/dotnet-ef)
* Install dotnet ef: ```dotnet tool install --global dotnet-ef --version 8.0.1```<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/3ffc1307-1bf5-481e-ac7a-3fa8e7fe11dd)

### troubleshooting
You will notice an issue when trying to list the available migrations through `dotnet eg migrations list` command:<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/06d95f27-a5af-471b-b987-362e3ae916b5)
So, adding the `Microsoft.entityFrameWorkCore.Design` to the Migration projet is required. You can add it in the `BackendFormation.Core.Selfies.Data.Migration` through nuget package interface on Visual Studio 2022.
Then, if you get the below issue it means you are trying to access the `DbContext` on the migration project:<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/72d24d9e-6c42-4dae-bae6-0b907aaea0f8)
But it can't be done in the migration project as the `DbContext` is defined in the Infrastructures project. we created two project to split the code properly:
1. Migration project: to handle the migration of the infrastructure into the DB
2. Infrasctructures project: to set up the context manipulated by the ORM. It is this project which handle the DB context.

When executing the `dotnet eg migrations list` command in Infrastructures project you should get the below issue:<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/ef67b75f-7a02-4102-ac1b-c05b67bf472f)

This will be handled on the next commit by implementing the `IDesignTimeDbContextFactory` interface. For more details, you can check [this topic](https://learn.microsoft.com/fr-fr/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#from-a-design-time-factory)

Once the design interface is created we can start the migration process first by initializing the migration: ```dotnet ef migrations add InitDatabase --project=..\BackEndFormation.Core.Selfies.Data.Migration```:
1. the infrastructure project must reference the migration project in order to the `dotnet ef` command line to be able to access this folder
2. but this reference of migration in infrastructure project can't be added as a reference as Migration already depends on it!
   - Yous must be changed the outpupath of migration to target the bin folder where the `dotnet ef` command will build the Infrastucture project
3. remove the table created in sql server management studio
5. generate the db from the migration:
   - ```cd BackEndFormation.Core.Selfies.Infrastructures```
   - ```dotnet ef database update```: if it can't find the assembly then check where is the folder where this command execute the build and past the dll directly in this folder
   
### Update a migration

When a new property is added to a `data.domain` class then it must be added to the migration with below command:<br />```dotnet ef migrations add AddDescription --startup-project . --project=..\BackEndFormation.Core.Selfies.Data.Migration```

## Run a dot net server
1. Go to the root directory of the application project: BackEndFormation
2. Open a console from there
3. Genere a dev certificate: ```dotnet dev-certs https```
4. Self trust the certificate: ```dotnet dev-certs https --trust```
   - click on yes:<br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/1afe663f-686a-44d9-bc0e-6aaa4f35807b)

6. In the launchSettings.json
   - in the profiles list, there should be the 'BackEndFormation' profile with commandName='Project':
     - set the applicationUrl to https://localhost:\<port\><br/>![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/7fa61afd-505a-4cdf-a745-2f9f71448839)

7. Start the server: ```dotnet run``` 
