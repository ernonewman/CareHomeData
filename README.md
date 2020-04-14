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

02. Uncomment the property in the [ProviderDetail.cs](.\CareHomeData.Ui.Console\Models\ProviderDetail.cs) file.

03. Copy and paste one of the "if" statements in the UpdateIndividualDetails method in the [Worker.cs](.\CareHomeData.Ui.Console\Worker.cs) file and update with the property you uncommented.

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

## Contribute

Seeing I just built this quickly for Edon, I haven't though contribution instructions through. 🤷🏽‍♂️
