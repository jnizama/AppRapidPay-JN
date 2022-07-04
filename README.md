# RapidPay
Payment provider API for coding challenge at BairesDev

Technology used in RapidPay project:
* Microsoft NetCore 5
* SQL Server Express 2019
* EntityFramework 5
* Microsoft Visual Studio 2019
* Swagger

### Before continue
Please download the repo and build the solution to restore de Nuget Packages and validate the application compile without issues 

## Migrations
Before run the application, please run the migration tool for create and initiale the database
1. Change the connection string in the file `RapidPay.Persistency / Context / RapidPayContextFactory.cs`
~~~
  optionsBuilder.UseSqlServer(
    "Server=localhost;Database=RapidPay;User Id=sa;Password=YOUR-PASSWORD;");
~~~
2. Open the PM Console in `Tools / Nuget Package Manager / Package Manager Console`
3. Execute the following migrations command:
~~~
update-database -p RapidPay.Persistency -s RapidPay.Persistency
~~~
Now the RapidPay database is created and initialized in your SQL Server

## Configurations
In the file `RapidPay.Api / appsetting.json` you can customize the configuration of the services

* __Database connection__ 

Change the connection string to access to your database
~~~
"ConnectionStrings": {
    "RapidPay": "Server=localhost;Database=RapidPay;User Id=sa;YOUR-PASSWORD;"
  },
~~~

* __Universal Fee Exchange (UFE)__ Service

Change the UFE values accoriding to the policy
~~~
"UFE": {
    "MinValue": 0,  // MIN value for randomly select the fee
    "MaxValue": 2,  // MAX value for randomly select the fee
    "Decimals": 2,  // decimals to use for fee
    "IntervalInMinutes": 60 // Time in minutes for the interval to calculate the next fee
  },
~~~

## Testing 
For testing purposes there is a user created 
~~~
  UserName: stivens.morgan
  Password: 123
~~~
