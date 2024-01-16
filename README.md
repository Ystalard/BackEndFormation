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

