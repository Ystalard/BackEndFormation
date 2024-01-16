# BackEndFormation

This project will follow the udemy formation at https://www.udemy.com/course/maitriser-web-api-rest-avec-aspnet-core-dotnet-50-full

This is a wep api rest project in asp.net.

REST uses http
![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/ef40d4da-0587-43d7-9b30-74c713fadd68)


the TDD principle
![TDD_Global_Lifecycle](https://github.com/Ystalard/BackEndFormation/assets/58308727/249da9ef-ab6d-44e2-b893-aa5ffd55bab9)
It consists in generating the unitary test to validate the implementation (the unitary tests behaves like running the project in debug mode on a particular feature)

ORM for Object Relational Mapping
![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/45380884-de47-4a16-a8a3-4de46e7aadc1)
The ORM is like a translator between object of the application (in C#) to the database (DB).
The ORM is like a cache, if nothing is saved on the database before stopping the application then any cached modification would be lost 
The ORM needs a provider in order to understand the language used by the DB.
![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/6c43f5d9-6826-41d8-a730-1104dcffd44c)

Creation of the Database

1.Install SQl Server Developer https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads

2.Install SQL Server Management Studio (SSMS)

3.Open SSMS (it must propose to connect to your sql server express which must be running, otherwise open SQL Server and configure it)

4.Create a new DB:

![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/6cf6c604-f9f7-4dee-8151-a133601b537d)

5.Insert the DB name and press Ok

![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/e1580e9a-3ead-415d-94ca-a305bf8065af)

Create a new table

1. Create the table

![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/22b6a39e-bee7-4d3c-93c3-5c49842cce49)

2.Add the Id row and set it as primary key

![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/4753723a-cb8d-4bed-9cfe-393232fa2980)

3.Change Identity Specification property of Id so that it is Identity

![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/1af52533-9ad3-49bf-b5c8-3295e52a4695)

4.Name and save the table

![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/d70d92d4-71ff-4a58-8e3a-02716d6fe74e)

5.Repeat the step until you  created both Selfie and Wookie table and inserted some rows

  a.The Selfie table:
  
![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/834a2f83-82dc-46f6-852d-10c56e032cb9)

  b.The Wookie table:

![image](https://github.com/Ystalard/BackEndFormation/assets/58308727/e21d8147-9717-42fd-8e3b-01e94d513243)




