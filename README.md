# CareHomeData

## Introduction

The things we do for friends, try 2.

## Getting Started

You need to download and install [the .Net Core SDK](https://dotnet.microsoft.com/download).

[VS Code](https://code.visualstudio.com/download) is the suggested minimum code editor but please feel free to use what ever editor you are comfortable with, most of the instructions here will be for compiling and running this application from the command line.

Start by cloning the repository and changing the working directory:

```batch
git clone https://github.com/ernonewman/CareHomeData.git
cd CareHomeData
```

## Build and Test

First ensure you have restored all the dependencies:

```batch
dotnet restore
```

The compile and build the solution.

```batch
dotnet build
```

Lastly, to run the project type:

```batch
dotnet run --project CareHomeData.Ui.Console
```

## Updating the ProviderDetail model

Just some quick instructions on making changes to the ProviderDetail model class in case you want to make updates.

01. Ensure you have the .NET EF Core global tool installed:

```batch
dotnet tool install --global dotnet-ef
```

02. Uncomment the property in the [ProviderDetail.cs](https://github.com/ernonewman/CareHomeData/blob/master/CareHomeData.Ui.Console/Models/ProviderDetail.cs) file.

03. Copy and paste one of the "if" statements in the UpdateIndividualDetails method in the [Worker.cs](https://github.com/ernonewman/CareHomeData/blob/master/CareHomeData.Ui.Console/Worker.cs) file and update with the property you uncommented.

04. Add an Entity Framework migration script using the below command, substituting the "NameOfMigration" value with something appropriate.

```batch
dotnet ef migrations add NameOfMigration
```

05. Update the database schema

```batch
dotnet ef database update
```

Now just re-run the program and the data should update.

Removing a property is basically the same instructions with you just needing to comment out the property and the existing "if" statement for it.

## Exporting the data to a CSV

So we're just using a work-around for this currently by using the [SQLite Manager for Google Chrome™](https://chrome.google.com/webstore/detail/sqlite-manager-for-google/aejlocbcokogiclkcfddhfnpajhejmeb/related?hl=en-GB) extension and then using the following instructions:

01. Open the Extension page by clicking on it's icon in the Chrome toolbar.

02. Click on/hover over the "File" button and select the "Open a Database" option.

03. Browse to the location of CareHomeData.Ui.Console source code and select "cqc.db" file.

04. Click on/hover over the "SQLite" button and from the "Querying Data" group, select the "Query all data from a table" option.

05. Change the query text from **SELECT * FROM table_name limit 100** to **SELECT * FROM ProviderDetails** and press the Enter/Return key.

06. You will then get a pop-up warning from SQLite Manager for Google Chrome™ stating "Printing a large table in this view could make your browser unresponsive for several minutes..." which you can just click "OK" for.

07. Depending on the table size, you might also get a pop-up warning from Chrome stating that "The Page has become unresponsive" for which you can just click on the "Wait" button for.

08. Eventually the query will finish running and you will be presented with a table listing all the data.

09. In the top, left-hand corner of the table there is a "Export" button which will create and download the data as a CSV file.

## Contribute

Seeing I just built this quickly for Edon, I haven't though contribution instructions through. 🤷🏽‍♂️
